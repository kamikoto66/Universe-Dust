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

    public List<PixelItemObject.Index> GetItems;

    private bool InitData;
    public float CameraScale { get; set; }

    public void Init()
    {
        if(InitData.Equals(false))
        {    
            GetItems = new List<PixelItemObject.Index>();
            CameraScale = 1f;

            InitData = true;
        }
    }

    public void ResetData()
    {
        InitData = false;
        GetItems.RemoveRange(0, GetItems.Count);
    }

    public void Add(PixelItemObject.Index index)
    {
        FindObjectOfType<ItemCount>().Add(index, GetItems.Count);
        GetItems.Add(index);
    }
}
