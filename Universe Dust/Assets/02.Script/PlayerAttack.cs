using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {
    
    private GameObject boss;
    private Animator animator;
    public bool isAttack;

    void Start()
    {
        boss = GameObject.Find("Boss");
        animator = GetComponent<Animator>();
        isAttack = false;
    }

    public void OnClickAttack()
    {
        if (isAttack)
            return;

        // 플레이어가 공격하는 버튼.
        boss.GetComponent<CharacterParams>().GetHitEnemyAttack(GetComponent<CharacterParams>().attackDmg);

        //animator.SetInteger("aniNumber", 1);            //  어택 애니메이션으로 바꿔줌

         StartCoroutine(BasicAttack());
    }

    
    IEnumerator BasicAttack()
    {
        animator.SetInteger("aniNumber", 1);            //  어택 애니메이션으로 바꿔줌

        yield return new WaitForSeconds(1.0f);

        animator.SetInteger("aniNumber", 0);
    }
    
    
}
