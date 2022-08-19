using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public int hp = 1;
    public int point;

    SpaceShipScript spaceShip;
    ScoreScript scoreScript;

    IEnumerator Start(){
        Debug.Log("EnemyScript.Start()");
    
        // コンポーネント取得
        spaceShip   = GetComponent<SpaceShipScript>();
        scoreScript = GameObject.FindWithTag("GameController").GetComponent<ScoreScript>();

        // ローカル座標のY軸のマイナス方向に移動する
        Move(transform.up * -1);

        while(true){
            // 撃っていいか確認
            if(spaceShip.canShot){
                // 子要素をすべて取得する
                for ( int i = 0; i < transform.childCount; i++){
                    Transform shotPosition = transform.GetChild(i);
                    
                    // ShotPositionの位置/角度で弾を撃つ
                    spaceShip.Shot(shotPosition);
                }
            }

            // shotDelay秒待つ
            yield return new WaitForSeconds(spaceShip.shotDelay);
        }
    }

    void Move(Vector2 direction){ Debug.Log("EnemyScript.Move()");
        GetComponent<Rigidbody2D>().velocity = direction * spaceShip.speed;
    }

    void OnTriggerEnter2D (Collider2D c){ Debug.Log("EnemyScript.OnTriggerEnter2D()");

        // レイヤー名を取得
        string layerName = LayerMask.LayerToName(c.gameObject.layer);

        // レイヤー名がBullet(Player)以外のときは何もやらない
        if(layerName != "Bullet (Player)") return;

        // 衝突したオブジェクトのタグがPlayerBulletの時のみ処理を続行
        if (c.gameObject.CompareTag("PlayerBullet") == false) return;

        Transform playerbulletTransform = c.transform.parent;
        // PlayerBulletのコンポーネントを取得
        BulletScript bullet = playerbulletTransform.GetComponent<BulletScript>();

        Destroy(c.gameObject);//弾の削除

        // ダメージ処理
        hp = hp - bullet.power;

        // 死んでたら追加処理
        if(hp<=0){
            spaceShip.Explosion();//爆発する
            
            Destroy(gameObject);//プレイヤーの削除

            // 敵を倒したのでスコア加算
            scoreScript.AddScore(point);
        }
        else{
            spaceShip.GetAnimator().SetTrigger("Damage");
        }
    }
}
