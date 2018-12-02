using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public int dmg { get; set; }
    GameObject player;

    void Start()
    {
        if (gameObject.tag != "bullet_2")
        {
            player = GameObject.FindGameObjectWithTag("Player");
            Vector3 dir = player.transform.position - transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        }

        dmg = 15;
        Destroy(gameObject, 5f);
    }

    void Update()
    {

    }
}
