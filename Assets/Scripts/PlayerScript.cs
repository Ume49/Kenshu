using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    SpaceShipScript spaceShip;

    IEnumerator Start(){
        Debug.Log("PlayerScript.Start()");

        spaceShip = GetComponent<SpaceShipScript>();

        while(true){
            // 弾をプレイヤーと同じ位置/角度で作成
            spaceShip.Shot(transform);

            // ショット音を鳴らす
            GetComponent<AudioSource>().Play();

            // 0.05秒待つ
            yield return new WaitForSeconds(spaceShip.shotDelay);
        }
    }

    void Update()
    {
        // 移動の入力を受け取る
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        // 移動方向を決定する
        Vector2 direction = new Vector2(x, y).normalized;

        // 移動速度を代入する
        Move(direction);
    }

    void Move(Vector2 direction){
        Debug.Log("PlayerScript.Move()");

        // 画面左下のワールド座標を取得
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0,0));

        // 画面右上のワールド座標を取得
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1,1));

        // プレイヤーの座標を取得
        Vector2 pos = transform.position;

        // 移動量を加える
        pos += direction * spaceShip.speed * Time.deltaTime;

        // 変更後の座標に制限をかける
        pos.x = Mathf.Clamp(pos.x, min.x, max.x);
        pos.y = Mathf.Clamp(pos.y, min.y, max.y);

        // 変更した座標を代入
        transform.position = pos;
    }

    //ぶつかった瞬間よびだされる
    void OnTriggerEnter2D (Collider2D c){
        Debug.Log("PlayerScript.OnTriggerEnter2D()");

        // Managerを探してGameOverを呼び出す
        FindObjectOfType<ManagerScript>().GameOver();

        Destroy(c.gameObject);//弾の削除

        spaceShip.Explosion();//爆発する
        
        Destroy(gameObject);//プレイヤーの削除
    }
}
