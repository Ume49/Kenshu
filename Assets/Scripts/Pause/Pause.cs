using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

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

    // ゲームを停止するのに必要なもの
    [SerializeField] ManagerScript      manager_;
    [SerializeField] EmitterScript      emitter_;
    [SerializeField] BackGroundScript[] backGrounds_;
    [SerializeField] AudioSource        bgm_;
    [Header("以下動的に確保するので入れなくていい")]
    [SerializeField] PlayerScript[]     players_;
    [SerializeField] SpaceShipScript[]  ships_;
    [SerializeField] EnemyScript[]      enemies_;
    [SerializeField] BulletScript[]     bullets_;
    // 物理と止める直前の速度。RigidBody2D.enabled = falseと書けなかったため速度を0にする
    [SerializeField] (Rigidbody2D R, Vector2 V)[]      rigidbodies;    

    // ゲーム停止処理
    void Freeze()
    {   Debug.Log("Pause.Freeze()");

        // 動的に変わるものを取得
        players_    = FindObjectsOfType<PlayerScript>();
        enemies_    = FindObjectsOfType<EnemyScript>();
        ships_      = FindObjectsOfType<SpaceShipScript>();
        bullets_    = FindObjectsOfType<BulletScript>();
        rigidbodies = FindObjectsOfType<Rigidbody2D>().Select(w => (w, Vector2.zero)).ToArray();

        // 動作を停止させる
        Time.timeScale = 0;

        manager_.enabled = false;
        emitter_.enabled = false;
        
        foreach(var w in ships_)        { w.enabled=false; }
        foreach(var w in bullets_)      { w.enabled=false; }
        foreach(var w in backGrounds_)  { w.enabled=false; }
        foreach(var w in enemies_)      { w.enabled=false; }
        foreach(var w in players_)      { w.enabled=false; }

        // BGMも一時停止
        bgm_.Pause();

        // 速度を0に
        // 直前の速度は保存しておく
        for(var i = 0; i<rigidbodies.Count(); i++){
            // もともとの速度を保存
            rigidbodies[i].V = rigidbodies[i].R.velocity;

            // 速度を0に
            rigidbodies[i].R.velocity = Vector2.zero;
        }
    }

    // ゲーム再開処理
    // 基本的に停止処理の逆をやる
    // 動的な確保はしない（ちゃんと停止されてるなら既に取った参照以上にオブジェクトが増えたり減ったりしてないはず）
    void UnFreeze()
    {   Debug.Log("Pause.UnFreeze()");
        
        // 動作を再開
        Time.timeScale = 1.0f;

        manager_.enabled = true;
        emitter_.enabled = true;

        foreach(var w in ships_)        { w.enabled = true; }
        foreach(var w in bullets_)      { w.enabled = true; }
        foreach(var w in backGrounds_)  { w.enabled = true; }
        foreach(var w in enemies_)      { w.enabled = true; }
        foreach(var w in players_)      { w.enabled = true; }

        // BGM再開
        bgm_.UnPause();

        // 速度をもとに戻す
        for(var i = 0; i<rigidbodies.Count(); i++){
            rigidbodies[i].R.velocity = rigidbodies[i].V;
        }

        // 再開したら弾の情報とかが変わるのでその辺の配列は消しておく
        players_    = null;
        enemies_    = null;
        ships_      = null;
        bullets_    = null;
        rigidbodies = null;
    }

    // ボタンで呼ぶ用のポーズ解除処理
    public void UnPause(){
        // ポーズ画面を非表示に
        pauseWindow.SetActive(false);

        // ゲーム再開
        UnFreeze();
    }
}
