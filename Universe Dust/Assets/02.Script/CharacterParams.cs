using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterParams : MonoBehaviour {

    public int maxHp;
    public int curHp;
    public int attackDmg { get; set; }
    public bool isDead { get; set; }
    [SerializeField] private Image hpBar;


    void Start()
    {
        InitParams();
    }


    virtual protected void InitParams()
    {
        isDead = false;
    }

    protected void UpdateAfterReceiveAttack()
    {
        hpBar.rectTransform.localScale = new Vector3((float)curHp / (float)maxHp, 1f, 1f);
    }

    virtual public void GetHitEnemyAttack(int dmg)
    {
        curHp -= dmg;

        if (curHp <= 0)
        {
            isDead = true;
            curHp = 0;
        }

        UpdateAfterReceiveAttack();
    }
}
