using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float currentTime;
    public float startingTime;
    [SerializeField] private Image startingtimeBar;
    [SerializeField] private Image currenttimeBar;
    public QuizManager quizManager;

    void Start()
    {
        currentTime = startingTime;
        startingtimeBar.fillAmount = startingTime;
    }

    void Update()
    {
        currentTime -= 1* Time.deltaTime;
        currenttimeBar.fillAmount = currentTime / startingTime;

        if (currentTime <=0)
        {
            currentTime = 0;
            quizManager.timeup();
            currentTime = startingTime;
        }

    }

    public void ResetTimer()
    {
        currentTime = startingTime;
    }
}
