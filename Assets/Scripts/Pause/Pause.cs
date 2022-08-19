using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    [SerializeField] KeyCode pauseKey_ = KeyCode.Escape;
    [SerializeField] GameObject pauseWindow;

    void Update()
    {
        // ポーズチェック
        if(Input.GetKeyDown(pauseKey_)){
            // ゲームを一時停止する
            Freeze();

            // ポーズ画面を表示する
            pauseWindow.SetActive(true);
        }
    }

    [SerializeField] MonoBehaviour[] freezeComponent_;

    // ゲーム停止処理
    void Freeze()
    {   Debug.Log("Pause.Freeze()");

        foreach(var w in freezeComponent_){
            w.enabled = false;
        }
    }

    // ゲーム再開処理
    void UnFreeze()
    {   Debug.Log("Pause.UnFreeze()");

        foreach(var w in freezeComponent_){
            w.enabled = true;
        }
    }

    // ボタンで呼ぶ用のポーズ解除処理
    public void UnPause(){
        // ポーズ画面を非表示に
        pauseWindow.SetActive(false);

        // ゲーム再開
        UnFreeze();
    }
}
