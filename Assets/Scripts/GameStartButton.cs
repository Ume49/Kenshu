using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStartButton : MonoBehaviour
{
    public void Pushed()
    {   Debug.Log("GameStartButton.Pushed()");
    
        // Mainシーンに遷移させる
        UnityEngine.SceneManagement.SceneManager.LoadScene("Main");
    }
}
