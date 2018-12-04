using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : UI {

    public bool IsTimeOver { get; private set; }
    public bool IsPause { get; set; }

    private Text TimerText;
     public float CurrentTime { get; private set; }
  
	// Use this for initialization
	void Start () {
        TimerText = Vars["Value"].GetComponent<Text>();
        CurrentTime = 10.0f;
        IsPause = false;
        IsTimeOver = false;
    }
	
	// Update is called once per frame
	void Update () {

        if(IsPause.Equals(false) && IsTimeOver.Equals(false))
        {
            CurrentTime -= Time.deltaTime;
            TimerText.text = string.Format("Time \r\n{0}", (int)CurrentTime);

            if (CurrentTime < 0.0f)
                IsTimeOver = true;
        }
    }
}
