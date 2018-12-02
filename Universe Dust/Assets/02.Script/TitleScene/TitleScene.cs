using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleScene : UI {

    [SerializeField] AudioSource StartEffect;
    Image _Slider;
    Text TouchToStart;

    private bool IsLodingSuccess;
    private bool IsStart;

	// Use this for initialization
	void Start () {
        IsStart = IsLodingSuccess = false;

        _Slider = Vars["LodingBar"].GetComponent<Image>();
        TouchToStart = Vars["TouchToStart"].GetComponent<Text>();

        TouchToStart.gameObject.SetActive(false);

        ItemManager.Instance.Init();
	}
	
	// Update is called once per frame
	void Update () {

        if(IsLodingSuccess.Equals(false))
        {
            _Slider.fillAmount = Mathf.Clamp(ItemManager.Instance.LodingCount, 0f, 1f);

            if(_Slider.fillAmount >= 1.0f)
            {
                IsLodingSuccess = true;
                _Slider.gameObject.SetActive(false);
                TouchToStart.gameObject.SetActive(true);
            }
        }
        else if(IsLodingSuccess.Equals(true))
        {
            if(Application.platform.Equals(RuntimePlatform.WindowsPlayer) || Application.platform.Equals(RuntimePlatform.WindowsEditor))
            {
                if(Input.GetMouseButtonDown(0))
                {
                    StartEffect.Play();
                    IsStart = true;
                    StartCoroutine(TouchToPlayAni());
                }
            }
            else if(Application.platform.Equals(RuntimePlatform.Android))
            {
                if(Input.touchCount > 0)
                {
                    StartEffect.Play();
                    IsStart = true;
                    StartCoroutine(TouchToPlayAni());
                }
            }

        }
    }

    IEnumerator TouchToPlayAni()
    {
        int Count = 0;
        float dir = -0.1f;
        Color color = TouchToStart.color;

        while (Count < 2)
        {
            if(color.a > 1.0f)
            {
                dir = -dir;
                Count++;
            }
            else if(color.a < 0.0f)
            {
                dir = -dir;
                Count++;
            }

            color.a += dir;
            TouchToStart.color = color;

            yield return null;
        }

        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }
}
