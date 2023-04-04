using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; }
    public EnemyHealth enemyH;

    [Header("Animator")]
    public Animator anim;

    [Header("UI Object")]
    public GameObject answerPanel;
    public GameObject questionText;
    public GameObject winPanel;
    public GameObject losePanel;
    public GameObject nextBut;
    public GameObject retryBut;
    public GameObject result;
    public GameObject pauseBut;
    public GameObject mainBut;

    [Header("Result")]
    public Result resval;
    public Stars star;

    [Header("Level Manager")]
    int currentLevel;
    
    private void Awake()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
    }
    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

        if (currentHealth > 0)
        {
            anim.SetTrigger("hurt");
            //iframes
        }
        else
        {
            
            //GetComponent<PlayerMovement>().enabled = false;
            
            answerPanel.SetActive(false);
            questionText.SetActive(false);
            result.SetActive(true);
            resval.SetResult();
            star.SetStar();
            currentLevel = SceneManager.GetActiveScene().buildIndex;
            if (star.starCount >= PlayerPrefs.GetInt("Star"+currentLevel))
            {
                PlayerPrefs.SetInt("Star"+currentLevel.ToString(),star.starCount);
            }
            Debug.Log("Kalah");
            if (resval.result >= 70f)
            {
                if (currentLevel >= PlayerPrefs.GetInt("levelsUnlocked"))
                {
                    PlayerPrefs.SetInt("levelsUnlocked",currentLevel + 1);
                }
                anim.SetTrigger("win");
                enemyH.anim.SetTrigger("die");
                winPanel.SetActive(true);
                nextBut.SetActive(true);
                retryBut.SetActive(true);
                nextBut.GetComponent<RectTransform>().localPosition = new Vector3(94.3f,-131,0f);
                retryBut.GetComponent<RectTransform>().localPosition = new Vector3(-94.3f,-131,0f);
                pauseBut.SetActive(false);
                mainBut.SetActive(true);
                mainBut.GetComponent<RectTransform>().localPosition = new Vector3(0f,-176,0f);
            }
            else
            {
                anim.SetTrigger("die");
                enemyH.anim.SetTrigger("win");
                losePanel.SetActive(true);
                retryBut.SetActive(true);
                pauseBut.SetActive(false);
                mainBut.SetActive(true);
                mainBut.GetComponent<RectTransform>().localPosition = new Vector3(0f,-176,0f);
            }
        }
    }
    public void AddHealth(float _value)
    {
        currentHealth = Mathf.Clamp(currentHealth + _value, 0, startingHealth);
    }
}