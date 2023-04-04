using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class QuizManager : MonoBehaviour
{

    [Header("Quiz")]
    public List<QuestionAndAnswer> QnA;
    public GameObject[] options;
    public Player_Score score;
    public Timer timer;
    public Text QuestionTxt;
    
    [Header("Health")]
    public PlayerHealth playerHealth;
    public EnemyHealth enemyHealth;

    [Header("Numbers")]
    public int currentQuestion;
    public float counter;
    public float c_counter;
    public float w_counter;
    public float crit;
    
    [Header("UI Object")]
    public GameObject answerPanel;
    public GameObject timeUp;
    public GameObject criticalHit;

    

    private void Start() {
        answerPanel.SetActive(true);
        counter=0;
        w_counter=0;
        c_counter=0;
        generateQuestion();
    }


    public void correct()
    {
        SFX.Instance.sfxs[1].Play();
        //QnA.RemoveAt(currentQuestion);
        c_counter = c_counter +1;
        score.ScoreChange();
        crit = Random.Range(0,1f);
        playerHealth.anim.SetTrigger("correct");
        if (crit < 0.3f)
        {
            StartCoroutine(CriticalHit());
            enemyHealth.TakeDamage(100);
        }
        else
        {
            enemyHealth.TakeDamage(50);
        }
        generateQuestion();
        timer.ResetTimer();
    }

    public void wrong()
    {
        SFX.Instance.sfxs[2].Play();
        //QnA.RemoveAt(currentQuestion);
        w_counter = w_counter + 1;
        score.ScoreChange();
        crit = Random.Range(0,1f);
        enemyHealth.anim.SetTrigger("correct");
        if (crit < 0.3f)
        {
            StartCoroutine(CriticalHit());
            playerHealth.TakeDamage(100);
        }
        else
        {
            playerHealth.TakeDamage(50);
        }
        generateQuestion();
        timer.ResetTimer();
    }

    public void timeup()
    {
        SFX.Instance.sfxs[2].Play();
        //QnA.RemoveAt(currentQuestion);
        enemyHealth.anim.SetTrigger("correct");
        StartCoroutine(TimeUp());
        w_counter = w_counter + 1;
        score.ScoreChange();
        playerHealth.TakeDamage(50);
        generateQuestion();
    }

    private IEnumerator TimeUp()
   {
    timeUp.SetActive(true);
    yield return new WaitForSeconds(0.5f);
    timeUp.SetActive(false);
   }

   private IEnumerator CriticalHit()
   {
    criticalHit.SetActive(true);
    yield return new WaitForSeconds(0.5f);
    criticalHit.SetActive(false);
   }

    void SetAnswer()
    {
        counter = counter +1;
        

        for (int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<AnswerScript>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<Text>().text = QnA[currentQuestion].Answers[i];

            if (QnA[currentQuestion].CorrectAnswer== i+1)
        {
            options[i].GetComponent<AnswerScript>().isCorrect = true;
        }
        }

        for (int i = 0; i < options.Length-1; i++)
        {
            Vector3 temp = options[i].transform.position;

            options[i].transform.position = options[i+1].transform.position;

            options[i+1].transform.position = temp;

        }

        
    }

    void generateQuestion()
    {
        if(QnA.Count > 0 )
        {
        Debug.Log($"QnA = {QnA}");
        Debug.Log("Answered: " + counter + "True : " + c_counter + "False : " + w_counter);
        currentQuestion = Random.Range(0,QnA.Count);
        QuestionTxt.text = QnA[currentQuestion].Question;

        SetAnswer();
        }
        else
        {
        Debug.Log("Out of Question");
        }
    }
}
