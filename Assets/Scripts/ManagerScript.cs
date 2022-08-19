using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerScript : MonoBehaviour
{
    // プレイヤーのPrefab
    public GameObject player;

    void Start()
    {   Debug.Log("ManagerScript.Start()");
        Debug.Log("<color=#ff0000>HelloWorld!!</color>");
    }

    void Update()
    {
        
    }

    public void GameOver(){
        Debug.Log("ManagerScript.GameOver()");

        // TODO: 後でコンテニューとかの処理を実装
    }

    // 一応残す
    public bool isPlaying(){
        Debug.Log("ManagerScript.isPlaying()");

        Debug.LogWarning("ダミーコード");

        return true;
    }
}
