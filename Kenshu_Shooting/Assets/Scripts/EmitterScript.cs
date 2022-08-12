using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmitterScript : MonoBehaviour
{
    // WavePrefabを格納する変数
    public GameObject[] waves;

    // 現在のWave
    int currentWave;

    ManagerScript manager;

    // 小ルーチン
    IEnumerator Start()
    {   Debug.Log("EmitterScript.Start()");
        // Waveが存在しなければコルーチンを終了する
        if(waves.Length == 0) yield break;

        // Manager取得
        manager = FindObjectOfType<ManagerScript>();

        while(true){
            // タイトル中は待機する
            while(manager.isPlaying() == false) 
            {
                yield return new WaitForEndOfFrame();
            }

            // Waveを作成する
            GameObject wave = (GameObject)Instantiate(waves[currentWave], transform.position, Quaternion.identity);

            // WaveをEmitterの子要素にする
            wave.transform.parent = transform;

            // Waveの子要素のEnemyが全て削除されるまで待機する
            while(wave.transform.childCount != 0) yield return new WaitForEndOfFrame();

            // currentWaveの値をループさせる
            if(waves.Length <= ++currentWave) currentWave = 0;
        }
    }
}
