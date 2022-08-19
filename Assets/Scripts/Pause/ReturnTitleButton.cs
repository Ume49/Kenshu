using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnTitleButton : MonoBehaviour
{
    public void Pushed(){
        // タイトルシーンに戻る
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}
