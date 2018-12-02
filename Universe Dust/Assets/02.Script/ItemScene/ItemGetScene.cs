using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGetScene : MonoBehaviour {

    [SerializeField] private Timer _Timer;

    private bool TimeOver;

	// Use this for initialization
	void Start () {

        TimeOver = false;


    }
	
	// Update is called once per frame
	void Update () {
		
        if(_Timer.IsTimeOver.Equals(true) && TimeOver.Equals(false))
        {
            UIManager.OpenUI<TimeOverUI>("Prefab/TimeOver");
            TimeOver = true;
        }
	}
}
