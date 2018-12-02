using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleResultSave : MonoBehaviour {

    public static BattleResultSave instance;
    public int win = 0;         // 1이면 유저가 이김, 2면 컴퓨터가 이김.

    void Awake()
    {
        if (instance == null)
            instance = this;
    }

	
}
