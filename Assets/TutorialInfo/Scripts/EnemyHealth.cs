using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyHealth : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; }
    public PlayerHealth playerH;

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
            anim.SetTrigger("die");
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
            Debug.Log("Menang");
            if (resval.result >= 70f)
            {
                if (currentLevel >= PlayerPrefs.GetInt("levelsUnlocked"))
                {
                    PlayerPrefs.SetInt("levelsUnlocked",currentLevel + 1);
                }
                anim.SetTrigger("die");
                playerH.anim.SetTrigger("win");
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
                anim.SetTrigger("win");
                playerH.anim.SetTrigger("die");
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