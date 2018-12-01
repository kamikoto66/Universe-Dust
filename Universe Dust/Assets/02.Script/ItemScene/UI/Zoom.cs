using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Zoom : UI {

    [SerializeField] private Camera PlayerFollowCam;
    private Text ScaleText;

    private float Delta;
    private float CameraScale;
    public bool IsMaxScale { get; private set; }

    private float PrevCameraScale;

    // Use this for initialization
    void Start () {
        ScaleText = Vars["Value"].GetComponent<Text>();
        ScaleText.text = ScaleText.text = string.Format("Zoom\r\nx{0}", 1);

        PrevCameraScale = PlayerFollowCam.orthographicSize;

        CameraScale = 1.0f;
        IsMaxScale = false;
        Delta = 0.0f;

        DataManager.Instance.CameraScale = CameraScale;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

#if UNITY_EDITOR || UNITY_STANDALONE_WIN

        var t = Input.GetAxis("Mouse ScrollWheel");

        if (Mathf.Abs(t) > 0.0f)
        {
            PlayerFollowCam.orthographicSize += t * 25.0f * Time.deltaTime;
            PlayerFollowCam.orthographicSize = Mathf.Clamp(PlayerFollowCam.orthographicSize, 2.0f, 10.0f);

            CameraScale = 10.0f / PlayerFollowCam.orthographicSize;

            ScaleText.text = string.Format("Zoom\r\nx{0}", CameraScale.ToString("N1"));

            if (CameraScale >= 5.0f)
                IsMaxScale = true;
            else if (CameraScale < 5.0f)
                IsMaxScale = false;

            if (DataManager.Instance.CameraScale != CameraScale)
                DataManager.Instance.CameraScale = CameraScale;
        }

#elif UNITY_ANDROID
        if (Input.touchCount == 2)
        {
            var TouchZero = Input.GetTouch(0);
            var TouchOne = Input.GetTouch(1);

            Vector2 touchZeroPrevPos = TouchZero.position - TouchZero.deltaPosition;
            Vector2 touchOnePrevPos = TouchOne.position - TouchOne.deltaPosition;

            float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float TouchDeltaMag = (TouchZero.position - TouchOne.position).magnitude;

            float deltaMagnitudeDiff = prevTouchDeltaMag - TouchDeltaMag;

            if (PlayerFollowCam.orthographic)
            {
                PlayerFollowCam.orthographicSize += deltaMagnitudeDiff * 0.01f;
                PlayerFollowCam.orthographicSize = Mathf.Clamp(PlayerFollowCam.orthographicSize, 2f, 10f);

                CameraScale = 10.0f / PlayerFollowCam.orthographicSize;

                ScaleText.text = string.Format("Zoom\r\nx{0}", CameraScale.ToString("N1"));

                if (CameraScale >= 5.0f)
                    IsMaxScale = true;
                else if (CameraScale < 5.0f)
                    IsMaxScale = false;

                if (DataManager.Instance.CameraScale != CameraScale)
                    DataManager.Instance.CameraScale = CameraScale;
            }
        }
#endif

    }
}
