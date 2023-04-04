using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Score : MonoBehaviour
{
    public Text playerScore;
    public Text enemyScore;
    public QuizManager quiz;

    // Update is called once per frame
    public void ScoreChange()
    {
        playerScore.text = "True : "+quiz.c_counter.ToString();
        enemyScore.text = "False : "+quiz.w_counter.ToString();
    }
}
