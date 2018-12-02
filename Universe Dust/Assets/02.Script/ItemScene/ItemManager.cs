using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour {

    private static ItemManager _Instance;

    public static ItemManager Instance
    {
        get
        {
            if (_Instance == null)
            {
                _Instance = FindObjectOfType<ItemManager>();

                if (_Instance == null)
                {
                    GameObject obj = new GameObject("ItemManager");
                    _Instance = obj.AddComponent<ItemManager>();
                    _Instance.Init();
                }

                DontDestroyOnLoad(_Instance);
            }

            return _Instance;
        }
    }

    private Dictionary<string, Sprite> _Mosaics;
    private Dictionary<string, Sprite> _ItemObjects;
    private float MaxLoding;
    private float CurrentLoding;
    private bool IsInit = false;

    public float LodingCount
    {
        get
        {
            return CurrentLoding / MaxLoding;
        }
    }

    // Use this for initialization
    public void Init () {

        if(IsInit.Equals(false))
        {
            MaxLoding = TableLocator._ItemTabl.Size();
            CurrentLoding = 0f;

            _Mosaics = new Dictionary<string, Sprite>();
            _ItemObjects = new Dictionary<string, Sprite>();

            StartCoroutine(ImageLoad());

            IsInit = true;
        }
    }
	
    IEnumerator ImageLoad()
    {
        var e = TableLocator._ItemTabl.All().GetEnumerator();

        while(e.MoveNext())
        {
            var MosaicPath = string.Format("Item/Mosaic/{0}", e.Current.MosaicPath);
            var Itempath = string.Format("Item/ItemObject/{0}", e.Current.ItemObjectPath);
            var Mosaic = Resources.LoadAsync<Texture2D>(MosaicPath);
            var Item = Resources.LoadAsync<Texture2D>(Itempath);

            yield return Mosaic.isDone;
            yield return Item.isDone;


            _Mosaics.Add(e.Current.Id, GetSprite(Mosaic.asset as Texture2D));
            _ItemObjects.Add(e.Current.Id, GetSprite(Item.asset as Texture2D));

            CurrentLoding++;
        }
    }

    private Sprite GetSprite(Texture2D texture)
    {
        Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));

        return sprite;
    }

    public Sprite LoadItemObjectSprite(string id)
    {
        Sprite texture;

        _ItemObjects.TryGetValue(id, out texture);

        return texture;
    }

    public Sprite LoadMosaicSprite(string id)
    {
        Sprite texture;
        _Mosaics.TryGetValue(id, out texture);

        return texture;
    }
}
