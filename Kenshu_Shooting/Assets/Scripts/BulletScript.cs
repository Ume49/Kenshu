using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public int speed = 10;  //  弾の速さ

    public int power = 1;   // 攻撃力

    void Update()
    {
        GetComponent<Rigidbody2D>().velocity = transform.up.normalized * speed;
    }
}
