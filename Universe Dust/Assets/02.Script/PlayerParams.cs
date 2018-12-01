using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerParams : CharacterParams {

    public bool invincibility;

    protected override void InitParams()
    {
        base.InitParams();
        maxHp = 100;
        curHp = maxHp;
        attackDmg = 10;
        invincibility = false;
    }

    public override void GetHitEnemyAttack(int dmg)
    {
        if (invincibility)
            return;

        base.GetHitEnemyAttack(dmg);

        if (isDead == true)
            GetComponent<Animator>().SetTrigger("isDead");

        invincibility = true;
        GetComponent<Animator>().SetBool("getHit", true);
        StartCoroutine(invincibilityCoroutine());
    }


    // 맞았을 때 1초동안 무적됬다가 풀리게.
    IEnumerator invincibilityCoroutine()
    {
        // 맞았다는 표시로 반짝이는 애니메이션

        yield return new WaitForSeconds(1.0f);
        invincibility = false;
        GetComponent<Animator>().SetBool("getHit", false);
    }

}
