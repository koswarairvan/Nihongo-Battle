using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerScript : MonoBehaviour
{
    public bool isCorrect = false;
    public QuizManager quizManager;
    public GameObject truePanel;
    public GameObject wrongPanel;
   public void Answer()
   {
    SFX.Instance.clickSound();
    if (isCorrect)
    {
        //Debug.Log("Correct Answer");
        StartCoroutine(CorrectAns());
        quizManager.correct();
    }
    else
    {
        //Debug.Log("Wrong Answer");
        StartCoroutine(WrongAns());
        quizManager.wrong();
    }
   }
   private IEnumerator CorrectAns()
   {
    truePanel.SetActive(true);
    yield return new WaitForSeconds(0.5f);
    truePanel.SetActive(false);
   }
   private IEnumerator WrongAns()
   {
    wrongPanel.SetActive(true);
    yield return new WaitForSeconds(0.5f);
    wrongPanel.SetActive(false);
   }
}
