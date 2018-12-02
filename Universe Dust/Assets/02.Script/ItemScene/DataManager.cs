using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour {

    private static DataManager _Instance;
    
    public static DataManager Instance
    {
        get
        {
            if(_Instance == null)
            {
                _Instance = FindObjectOfType<DataManager>();

                if(_Instance == null)
                {
                    GameObject obj = new GameObject("DataManager");
                    _Instance = obj.AddComponent<DataManager>();
                }

                _Instance.Init();
                DontDestroyOnLoad(_Instance);
            }

            return _Instance;
        }
    }

    private bool InitData;
    private Transform SwordObject;
    public List<PixelItemObject.Index> GetItems;
    public float CameraScale { get; set; }

    public void Init()
    {
        if(InitData.Equals(false))
        {
            GetItems = new List<PixelItemObject.Index>();
            //SwordObject = GameObject.FindGameObjectWithTag("ItemGet").transform;
            CameraScale = 1f;

            InitData = true;
        }
    }

    public void ResetData()
    {
        InitData = false;
    }

    public void Add(PixelItemObject.Index index)
    {
        var obj = UIManager.OpenUI<ItemUI>("Prefab/ItemUI");
        obj.GetComponent<RectTransform>().parent = SwordObject;
        obj.GetComponent<RectTransform>().SetAsFirstSibling();
        obj.GetComponent<RectTransform>().anchoredPosition = new Vector2(0f, 90f + 40f * GetItems.Count);
        obj.Init(index);

        GetItems.Add(index);
    }
}
