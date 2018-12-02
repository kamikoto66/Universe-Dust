using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BossParams : CharacterParams {


    protected override void InitParams()
    {
        base.InitParams();
        maxHp = 100;
        curHp = maxHp;
        attackDmg = 10;
    }

    public override void GetHitEnemyAttack(int dmg)
    {

        BattleSoundManager.instance.SetMusic(8);
        base.GetHitEnemyAttack(dmg);
        if (isDead == true)
        {
            //GetComponent<Animator>().SetTrigger("isDead");
            BattleResultSave.instance.win = 1;
            SceneManager.LoadScene("EndScene");
        }
        GetComponent<BossAttack>().bossAttackDelay = 4 + (GetComponent<BossAttack>().bossAttackDelay - 4) / maxHp * curHp;
    }
}
