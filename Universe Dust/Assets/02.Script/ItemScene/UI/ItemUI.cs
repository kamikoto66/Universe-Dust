using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemUI : UI {

    private PixelItemObject.Index Index;
    private Vector2 Target;
    private Image ItemImage;

	// Use this for initialization
	public void Init (PixelItemObject.Index index) {

        Index = index;

        ItemImage = GetComponent<Image>();

        ItemImage.sprite = ItemManager.Instance.LoadItemObjectSprite(Index.ToString());


        StartCoroutine(FadeIn());
    }
	
    IEnumerator FadeIn()
    {
        Color color = ItemImage.color;

        while (color.a < 1.0f)
        {
            color.a += 0.2f;

            ItemImage.color = color;

            yield return null;
        }

        yield return null;
    }
}
