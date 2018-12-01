using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour {

    PlayerParams playerParams;

	// Use this for initialization
	void Start () {
        playerParams = GetComponent<PlayerParams>();
	}
	
	void OnTriggerEnter2D(Collider2D col)
    {   // 운석 20, 총알 10, 
        if (playerParams.invincibility)
            return;

        Debug.Log("충돌 바깥");
        if (col.gameObject.tag == "bullet")
        {
            Debug.Log("충돌");
            playerParams.GetHitEnemyAttack(10);
            Destroy(col.gameObject);
        }
        else if(col.gameObject.tag == "Asteroid")
        {
            playerParams.GetHitEnemyAttack(30);
            col.gameObject.GetComponent<Bullet_Bamboo>().Bomb();
            Destroy(col.gameObject);
        }

        // 투사체 파괴될 때 이펙트 추가할거면 이곳에
    }
}
