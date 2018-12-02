using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShowWinner : MonoBehaviour {

    public Sprite[] winnerImage;
    public Text[] canvasText;
    public Image backGround;

	// Use this for initialization
	void Start () {
		
        if(BattleResultSave.instance.win == 2) // 패배
        {
            canvasText[0].text = "GAME OVER";
            canvasText[1].text = "새로운 용사는 나 팬더맨이 물리쳤으니\n안심하라고!";
            backGround.sprite = winnerImage[1];
        }
        else if (BattleResultSave.instance.win == 1) // 승리
        {
            canvasText[0].text = "GAME CLEAR";
            canvasText[1].text = "탄)축(생\n세기말우주구세주!";
            backGround.sprite = winnerImage[0];
        }

    }
	

    public void OnClickRetry()
    {
        SceneManager.LoadScene("TitleScene");
    }
}
