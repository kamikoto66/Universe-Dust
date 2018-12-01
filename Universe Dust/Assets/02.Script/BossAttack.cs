using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossAttack : MonoBehaviour {

    public CharacterParams characterParams { get; set; }

    public float bossAttackDelay { get; set; }

    private Transform playerPos;

    public Transform[] AttackPos;
    public Transform AttackPos2;

    public GameObject[] bullet;

    private Vector3 lastPlanetPos;

    private Animator anim;

    private int num;

    public Sprite[] textBullet;

    int random;

    // Use this for initialization
    void Start () {
        characterParams = GetComponent<CharacterParams>();
        bossAttackDelay = 6f;           // 체력에 따라 바꿔줌.
        playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        anim = GetComponent<Animator>();
        Invoke("AttackChoice", 2f);
	}
	
	void AttackChoice()
    {
        int num = Random.Range(1, 4);

        switch (num)
        {
            case 1:
                Attack_Pattern1();
                break;
            case 2:
                Attack_Pattern2();
                break;
            case 3:
                Attack_Pattern3();
                break;
            case 4:
                Attack_Pattern4();
                break;
        }

        if (!characterParams.isDead)
            Invoke("AttackChoice", bossAttackDelay);
    }

    void Attack_Pattern1()  // 폭탄 던지기 -> 폭탄 터지면 총알 흩어짐.
    {
        Debug.Log("패턴1 실행");
        num = Random.Range(0, 3);

        StartCoroutine(Pattern1_Coroutine());
    }

    IEnumerator Pattern1_Coroutine()
    {
        anim.SetInteger("aniNumber", 1);
        yield return new WaitForSeconds(0.5f);
        random = Random.Range(0, 10);
        if (random < 5)
            Instantiate(bullet[0], AttackPos[num]);
        else
            Instantiate(bullet[3], AttackPos[num]);

        anim.SetInteger("aniNumber", 0);
    }

    public void AfterAttack_1(Transform pos)  // pos는 행성 터진곳 받아오는거
    {
        Vector3 offset = Vector2.up;
        float angle = 0f;
        GameObject bul;
        for (int i = 0; i < 12; i ++)
        {
            
            if (random < 5)
                bul = Instantiate(bullet[1], pos.position, Quaternion.identity);
            else
                bul = Instantiate(bullet[4], pos.position, Quaternion.identity);
            
            Vector2 newDirection = new Vector2(offset.x * Mathf.Cos(angle * Mathf.Deg2Rad) + offset.y * Mathf.Sin(angle * Mathf.Deg2Rad),
                                        -1 * offset.x * Mathf.Sin(angle * Mathf.Deg2Rad) + offset.y * Mathf.Cos(angle * Mathf.Deg2Rad)).normalized;

            Debug.Log(newDirection);
            bul.GetComponent<Rigidbody2D>().AddForce(newDirection * 3f, ForceMode2D.Impulse);
            angle += 30f;
        }
    }

    void Attack_Pattern2()
    {
        Debug.Log("패턴2 실행");
        StartCoroutine(Pattern2_Coroutine());
    }

    IEnumerator Pattern2_Coroutine()
    {
        anim.SetInteger("aniNumber", 2);
        Vector3 offset = Vector2.left + new Vector2(0, Random.Range(-1f, 1f)); // 너무 왼쪽 딱 고정되면 쉬우니 위아래 랜덤값 줘서.
        for(int i=0; i<5; i++)
        {
            float angle = -45f;
            for(int j=0; j<7; j++)
            {
                GameObject bul = Instantiate(bullet[1], AttackPos2);
                Vector2 newDirection = new Vector2(offset.x * Mathf.Cos(angle * Mathf.Deg2Rad) + offset.y * Mathf.Sin(angle * Mathf.Deg2Rad),
                                        -1 * offset.x * Mathf.Sin(angle * Mathf.Deg2Rad) + offset.y * Mathf.Cos(angle * Mathf.Deg2Rad)).normalized;
                bul.GetComponent<Rigidbody2D>().AddForce(newDirection * 3f, ForceMode2D.Impulse);
                angle += 15f;
            }
            
            yield return new WaitForSeconds(0.2f);

            
        }
        anim.SetInteger("aniNumber", 0);

    }

    void Attack_Pattern3()              // 현재 유저위치 방향으로 쏘기.
    {
        Debug.Log("패턴3 실행");
        StartCoroutine(Pattern3_Coroutine());
    }

    IEnumerator Pattern3_Coroutine()
    {
        anim.SetInteger("aniNumber", 1);
        for(int i=0; i<3; i++)
        {
            Vector3 targetPos = playerPos.position;
            for(int j=0; j<8; j++)
            {
                if (j == 0)
                    Instantiate(bullet[2]);
                else
                {
                    GameObject bul = Instantiate(bullet[5]);
                    Vector3 power = (targetPos - bul.transform.position).normalized;
                    bul.GetComponent<Rigidbody2D>().AddForce(power * 5f, ForceMode2D.Impulse);
                    
                }
                yield return new WaitForSeconds(0.1f);
            }
            yield return new WaitForSeconds(0.2f);
        }


    }

    void Attack_Pattern4()
    {
        Debug.Log("패턴4 실행");
    }


}
