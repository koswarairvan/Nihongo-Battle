using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Result : MonoBehaviour
{
    public Text res;
    public float result;
    public QuizManager quiz;

    public void SetResult()
    {
        result = quiz.c_counter / quiz.counter * 100; 
        res.text = result.ToString("0.00") + " %";
    }
}
