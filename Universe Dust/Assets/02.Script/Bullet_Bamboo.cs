using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Bamboo : MonoBehaviour {

    public int dmg { get; set; }
    private float moveSpeed;
    [SerializeField] private GameObject player;
    Vector3 destinationPos;
    public GameObject explosion;        // 펑 터지는 게임오브젝트? 스프라이트?

    private float boundary_horizon = 8.2f;
    private float boundary_vertical = 4.3f;


    void Start()
    {
        dmg = 15;
        moveSpeed = 4f;
        player = GameObject.FindGameObjectWithTag("Player");
        destinationPos = player.transform.position + new Vector3(0, Random.Range(0, 5f), 0);
        destinationPos *= 5f;

        Invoke("Bomb", 2f);
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, destinationPos, moveSpeed * Time.deltaTime);

        if (transform.position.x > boundary_horizon) Bomb();
        if (transform.position.x < -boundary_horizon) Bomb();
        if (transform.position.y > boundary_vertical) Bomb();
        if (transform.position.y < -boundary_vertical) Bomb();


        //if(Vector3.Distance(transform.position, player.transform.position) < 3f)
        //{
        //    // 펑 터지는 스프라이트로 바꾸고 오기
        //    Instantiate(explosion, transform.position, Quaternion.identity);

        //    GameObject.FindGameObjectWithTag("Boss").GetComponent<BossAttack>().AfterAttack_1(transform);

        //    Destroy(gameObject);
        //}
    }

    public void Bomb()
    {
        //CancelInvoke("Bomb");
        // 펑 터지는 스프라이트로 바꾸고 오기
        Instantiate(explosion, transform.position, Quaternion.identity);

        GameObject.FindGameObjectWithTag("Boss").GetComponent<BossAttack>().AfterAttack_1(transform);

        Destroy(gameObject);
    }
}