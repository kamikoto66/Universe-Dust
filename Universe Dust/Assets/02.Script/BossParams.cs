using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        base.GetHitEnemyAttack(dmg);
        GetComponent<BossAttack>().bossAttackDelay = 4 + (GetComponent<BossAttack>().bossAttackDelay - 4) / maxHp * curHp;
    }
}
