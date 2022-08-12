using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipScript : MonoBehaviour
{
    // 移動スピード
    public float speed;

    // 弾を撃つ間隔
    public float shotDelay;

    // 弾のPrefab
    public GameObject bullet;

    // 弾を撃つかどうか
    public bool canShot;

    // 爆発のPrefab
    public GameObject explosion;

    public Animator animator;

    void Start(){
        Debug.Log("SpaceShipScript.Start()");

        animator = GetComponent<Animator>();
    }

    public Animator GetAnimator(){
        return this.animator;
    }

    // 弾の作成
    public void Shot(Transform origin){
        Debug.Log("SpaceShipScript.Shot()");

        Instantiate(bullet, origin.position, origin.rotation);
    }

    // 機体の移動
    public void Move(Vector2 direction){
        GetComponent<Rigidbody2D>().velocity = direction * speed;
    }

    public void Explosion(){
        Instantiate(explosion, transform.position, transform.rotation);
    }
}
