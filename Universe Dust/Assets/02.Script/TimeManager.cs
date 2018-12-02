using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeManager : MonoBehaviour {

    public Text timeText;
    float curTime;

	// Use this for initialization
	void Start () {
        curTime = 60f;
	}
	
	// Update is called once per frame
	void Update () {
        curTime -= Time.deltaTime;

        timeText.text = ((int)curTime).ToString();



        if(curTime < 0.1f)      // 게임 종료
        {
            BattleResultSave.instance.win = 2;
            SceneManager.LoadScene("EndScene");
        }
	}
}
