using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    private GameObject player;
    private GameObject boss;

	void Start()
    {
        player = GameObject.Find("Player");
        boss = GameObject.Find("Boss");
    }

    public void OnClickAttack()
    {
        // 플레이어가 공격하는 버튼.
        boss.GetComponent<CharacterParams>().GetHitEnemyAttack(player.GetComponent<CharacterParams>().attackDmg);
    }
}
