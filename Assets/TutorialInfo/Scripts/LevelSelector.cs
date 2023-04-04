using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{
    public int level;
    int levelsUnlocked;
    int star;
    public Text levelName;
    public Text starAmount;
    public Button[] buttons;

    private void Start() 
    {
        levelsUnlocked = PlayerPrefs.GetInt("levelsUnlocked",1);
        star = PlayerPrefs.GetInt("Star"+level.ToString(),0);
        levelName.text = "L" + level.ToString();
        starAmount.text = star.ToString();
        

        for (int i= 0; i <buttons.Length;i++)
        {
            buttons[i].interactable = false;
        }

        for (int i= 0; i < levelsUnlocked ;i++)
        {
            buttons[i].interactable = true;
        }

    }
    public void OpenScene()
    {
        Music.Instance.battleStart();
        SceneManager.LoadScene(level.ToString());
    }
}
