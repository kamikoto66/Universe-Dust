using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Chase : MonoBehaviour {

    public int dmg { get; set; }
    private float moveSpeed;
    [SerializeField] private GameObject player;

    private bool isChase = true;

    void Start()
    {
        dmg = 15;
        moveSpeed = 2f;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (!isChase)
            return;

        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, moveSpeed * Time.deltaTime);

        if(Vector3.Distance(transform.position, player.transform.position) < 2f)
        {
            Vector3 force = (player.transform.position - transform.position).normalized;
            GetComponent<Rigidbody2D>().velocity = force * moveSpeed;

            isChase = false;
        }
    }
}
