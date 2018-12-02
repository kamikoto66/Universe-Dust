using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordSpon : MonoBehaviour {

	// Use this for initialization
	void Start () {
        DataManager.Instance.Add(PixelItemObject.Index.Item_1);
        DataManager.Instance.Add(PixelItemObject.Index.Item_2);
        DataManager.Instance.Add(PixelItemObject.Index.Item_3);
        DataManager.Instance.Add(PixelItemObject.Index.Item_Ball);
        DataManager.Instance.Add(PixelItemObject.Index.Item_Bone);
        DataManager.Instance.Add(PixelItemObject.Index.Item_Bone_2);
        DataManager.Instance.Add(PixelItemObject.Index.Item_Bool);
        DataManager.Instance.Add(PixelItemObject.Index.Item_Bool_2);
        DataManager.Instance.Add(PixelItemObject.Index.Item_Box);
        DataManager.Instance.Add(PixelItemObject.Index.Item_Cat);
        DataManager.Instance.Add(PixelItemObject.Index.Item_Egg_1);
        DataManager.Instance.Add(PixelItemObject.Index.Item_Egg_2);
        DataManager.Instance.Add(PixelItemObject.Index.Item_Fire);


    }

    private void Spon()
    {
        var e = DataManager.Instance.GetItems.GetEnumerator();

        while(e.MoveNext())
        {

        }
    }

 //   // Update is called once per frame
 //   void Update () {
		
	//}
}
