using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : UI {

    private Text TimerText;
    private float CurrentTime;

	// Use this for initialization
	void Start () {
        TimerText = Vars["Value"].GetComponent<Text>();

    }
	
	// Update is called once per frame
	void Update () {
        CurrentTime = float.Parse(System.DateTime.Now.ToString("ss"));

        Debug.Log(CurrentTime);
    }
}
