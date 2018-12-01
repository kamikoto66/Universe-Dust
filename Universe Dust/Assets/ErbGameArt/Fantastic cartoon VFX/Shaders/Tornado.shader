Shader "ErbGameArt/Tornado" {
    Properties {
		_MainTex ("Main Texture", 2D) = "white" {}
        [HDR]_TintColor ("color", Color) = (1,0.6,0,1)
        _FresnelStrench ("FresnelStrench", Float ) = 1
        [MaterialToggle] _Fresnel ("Fresnel", Float ) = 0
        _EmmisionStrench ("EmmisionStrench", Range(0, 8)) = 2
        _FresnelOutline ("FresnelOutline", Float ) = 1
        _U_Speed ("U_Speed", Float ) = -0.2
        _V_Speed ("V_Speed", Float ) = -0.5
        _FrenselColor ("FrenselColor", Color) = (1,1,1,1)
        _Numberofwawes ("Number of wawes", Float ) = 3
        _Sizeofwawes ("Size of wawes", Float ) = -0.07
        _DirectionSpeedofwawes ("Direction&Speed of wawes", Float ) = -0.5
        _Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
        _Reel ("Reel", Vector) = (1,0.1,5,0)
    }
    SubShader {
        Tags {
            "Queue"="AlphaTest"
            "RenderType"="TransparentCutout"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Cull Off
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            uniform float4 _TintColor;
            uniform float _FresnelStrench;
            uniform fixed _Fresnel;
            uniform float _EmmisionStrench;
            uniform float _FresnelOutline;
            uniform float _U_Speed;
            uniform float _V_Speed;
            uniform float4 _FrenselColor;
            uniform float _Numberofwawes;
            uniform float _Sizeofwawes;
            uniform float _DirectionSpeedofwawes;
            uniform float _Cutoff;
			uniform float4 _Reel;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 texcoord0 : TEXCOORD0;
                float4 vertexColor : COLOR;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float4 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                float4 vertexColor : COLOR;
				float height : TEXCOORD3;
                UNITY_FOG_COORDS(3)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.vertexColor = v.vertexColor;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                v.vertex.xyz += ((sin((_Numberofwawes*(mul( unity_WorldToObject, float4(mul(unity_ObjectToWorld, v.vertex).rgb,0) ).xyz.rgb.rgb.g+(_Time.g*_DirectionSpeedofwawes))*6.28318530718))*o.uv0.g)*v.normal*_Sizeofwawes);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
				float3 worldpos = mul(unity_ObjectToWorld, v.vertex).xyz;
				float height = o.uv0.g * _Reel.y;
				v.vertex.x += sin(_Time.y*_Reel.z + worldpos.y * _Reel.x) * height;
				v.vertex.z += sin(_Time.y*_Reel.z + worldpos.y * _Reel.x + 3.1415/2) * height;
				o.height = height;
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                i.normalDir = normalize(i.normalDir);
                i.normalDir *= faceSign;
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float2 ttt = ((_Time.g*float2(_U_Speed,_V_Speed))+i.uv0);
                float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(ttt, _MainTex));
                clip((_Cutoff*_MainTex_var.r*i.uv0.b) - 0.5);
                float3 uuu = (_TintColor.rgb*_MainTex_var.rgb*_EmmisionStrench*i.vertexColor.rgb);
                float3 vvv = (pow(1.0-max(0,dot(normalDirection, viewDirection)),_FresnelStrench)*_FrenselColor.rgb);
                float3 emissive = lerp( uuu, (uuu+saturate((vvv*vvv*_FresnelOutline))), _Fresnel );
                fixed4 finalRGBA = fixed4(emissive,1);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }      
    }
    FallBack "Diffuse"
}
