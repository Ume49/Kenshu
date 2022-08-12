using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerScript : MonoBehaviour
{
    // プレイヤーのPrefab
    public GameObject player;
    [SerializeField] GameObject title;

    void Start()
    {
        Debug.Log("<color=#ff0000>HelloWorld!!</color>");

        // Titleゲームオブジェクトを検索し取得する
        title = GameObject.Find("Canvas");
    }

    void Update()
    {
        // ゲームが始まってない時だけ動く
        if(isPlaying() == true) return;
        if(Input.GetKeyDown(KeyCode.X)){   // xキーを押したらゲーム開始
            GameStart();
        }
    }

    void GameStart(){
        Debug.Log("ManagerScript.GameStart()");

        // ゲームスタート時にタイトルを非表示にしてプレイヤーを作成する
        title.SetActive(false);
        Instantiate(player, player.transform.position, player.transform.rotation);
    }

    public void GameOver(){
        Debug.Log("ManagerScript.GameOver()");

        title.SetActive(true);  // ゲームオーバーになったらタイトル表示
    }

    public bool isPlaying(){
        Debug.Log("ManagerScript.isPlaying()");

        // ゲーム中かどうかはタイトルの表示/非表示で判断
        return title.activeSelf == false;
    }
}
