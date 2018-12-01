using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public int dmg { get; set; }

    void Start()
    {
        dmg = 15;
        Destroy(gameObject, 5f);
    }
}
