using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSwordSetting : MonoBehaviour {

    [SerializeField] private Transform PlayerSword;

	// Use this for initialization
	void Start () {

        SettingSword();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void SettingSword()
    {
        var e = DataManager.Instance.GetItems.GetEnumerator();
        float count = 0;
        while(e.MoveNext())
        {
            var index = e.Current;
            var sprite = ItemManager.Instance.LoadItemObjectSprite(index.ToString());
            var obj = new GameObject(index.ToString());
            obj.AddComponent<SpriteRenderer>().sprite = sprite;
            obj.transform.position = new Vector3(1 + 0.5f*count, 0, 0);
            obj.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            obj.transform.SetParent(PlayerSword, false);

            count++;
        }
    }
}
