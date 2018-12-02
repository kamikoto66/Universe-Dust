using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Chase : MonoBehaviour
{

    public int dmg { get; set; }
    private float moveSpeed;
    private float rotSpeed = 100f;
    [SerializeField] private GameObject player;

    private bool isChase = true;

    void Start()
    {
        dmg = 15;
        moveSpeed = 2f;
        player = GameObject.FindGameObjectWithTag("Player");
        Destroy(gameObject, 20f);


    }

    void Update()
    {
        if (!isChase)
            return;



        //float rotDeg = Mathf.Atan2(player.transform.position.x - transform.position.x, player.transform.position.y - transform.position.y)
        //                    * Mathf.Rad2Deg;
        //transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.Euler(0f, 0f, rotDeg), rotSpeed * Time.deltaTime);

        //transform.rotation = Quaternion.Lerp(transform.rotation, player.transform.rotation, Time.time * rotSpeed);

        Vector3 dir = player.transform.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);


        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, player.transform.position) < 2f)
        {
            Vector3 force = (player.transform.position - transform.position).normalized;
            GetComponent<Rigidbody2D>().velocity = force * moveSpeed;

            isChase = false;
        }

    }
}

