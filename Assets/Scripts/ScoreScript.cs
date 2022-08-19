using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public int score;   
    public int highscore;

    public Text scoreText;
    public Text highScoreText;

    void Start()
    {   Debug.Log("ScoreScript.Start()");

        // スコア初期化
        score     = 0;
        highscore = 0;

        scoreText.text = "SCORE:\n" + score;
        UpdateHighScore();
    }

    void Update()
    {
        // ハイスコア更新
        if (score > highscore){
            UpdateHighScore();
        }
    }

    public void AddScore(int scoreToAdd){ Debug.Log("ScoreScript.AddScore()");
        score += scoreToAdd;
        scoreText.text = "SCORE:\n" + score;    // スコアの表示
    }

    void UpdateHighScore(){ Debug.Log("ScoreScript.UpdateHighScore()");

        // ハイスコアの表示と更新
        highScoreText.text = "HIGHSCORE:\n" + score;
    }
}
