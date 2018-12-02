using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemGetStart : UI {

    [SerializeField] private AudioSource _BgmSource;


	// Use this for initialization
	IEnumerator Start () {

        FindObjectOfType<Timer>().IsPause = true;
        GameObject.Find("Bgm").GetComponent<AudioSource>().Pause();

        yield return StartCoroutine(FadeIn(Vars["Ready"].GetComponent<Text>()));

        yield return StartCoroutine(FadeIn(Vars["Go!"].GetComponent<Text>()));

        yield return StartCoroutine(FadeOut(GetComponent<Image>()));

        FindObjectOfType<Timer>().IsPause = false;
        GameObject.Find("Bgm").GetComponent<AudioSource>().Play();

        Destroy(gameObject);
    }

    IEnumerator FadeOut(Graphic graphic)
    {
        Color color = graphic.color;

        while (color.a > 0.0f)
        {
            color.a -= 0.01f;
            graphic.color = color;

            yield return null;
        }
    }


    IEnumerator FadeIn(Graphic text)
    {
        Color color = text.color;

        while (color.a < 1.0f)
        {
            color.a += 0.01f;
            text.color = color;

            yield return null;
        }

        text.enabled = false;
    }
}
