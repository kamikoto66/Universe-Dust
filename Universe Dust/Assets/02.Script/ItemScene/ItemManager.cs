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
                }

                _Instance.Init();
                DontDestroyOnLoad(_Instance);
            }

            return _Instance;
        }
    }

    private Dictionary<string, Sprite> _Mosaics;
    private Dictionary<string, Sprite> _ItemObjects;
    private bool IsInit = false;

    // Use this for initialization
    public void Init () {

        if(IsInit.Equals(false))
        {
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
            var objs = Resources.LoadAll("Item/ItemObject/");
            yield return objs;

            //var MosaicPath = string.Format("Item/Mosaic/{0}", e.Current.MosaicPath);
            //var Itempath = string.Format("Item/ItemObject/{0}", e.Current.ItemObjectPath);
            //var Mosaic = Resources.LoadAsync<GameObject>(MosaicPath);
            //var Item = Resources.LoadAsync<GameObject>(Itempath);

            //yield return Mosaic.isDone;
            //yield return Item.isDone;

            //_Mosaics.Add(e.Current.Id, Mosaic.asset as Sprite);
            //_ItemObjects.Add(e.Current.Id, Item.asset as Sprite);
        }

        Debug.Log("Done");

        //UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }

    public Sprite LoadItemObjectSprite(string id)
    {
        Sprite value;
        _ItemObjects.TryGetValue(id, out value);

        return value;
    }

    public Sprite LoadMosaicSprite(string id)
    {
        Sprite value;
        _Mosaics.TryGetValue(id, out value);

        return value;
    }
}
