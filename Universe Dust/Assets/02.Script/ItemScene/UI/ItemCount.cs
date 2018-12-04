using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCount : UI {

    private RectTransform SwordObjects;
    private Text ItemCountText;

	// Use this for initialization
	void Start () {
        SwordObjects = Vars["ItemGet"].GetComponent<RectTransform>();
        ItemCountText = Vars["Value"].GetComponent<Text>();
    }

    public void Add(PixelItemObject.Index index, int Count)
    {
        var obj = UIManager.OpenUI<ItemUI>("Prefab/ItemUI");
        obj.GetComponent<RectTransform>().parent = SwordObjects;
        obj.GetComponent<RectTransform>().SetAsFirstSibling();
        obj.GetComponent<RectTransform>().anchoredPosition = new Vector2(0f, 90f + 40f * Count);
        obj.Init(index);

        ItemCountText.text = string.Format("{0}M", Count+1);
    }
	

}
