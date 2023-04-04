using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    [Header("Game Play")]
    public GameObject gamePanel;
    public GameObject tutorialPanel;

    [Header("Pause Control")]
    public GameObject pause;
    public GameObject resume;
    public GameObject mainMenu;
    public GameObject pausedText;


    [Header("Tutorial")]
    public GameObject menuPanel;
    public GameObject tutorPanel;



    public void GameStart()
    {
        click();
        gamePanel.SetActive(true);
        tutorialPanel.SetActive(false);
    }

    public void Play()
    {
        click();
        SceneManager.LoadScene("Select");
    }

    public void Next()
    {
        click();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
    }
    public void Retry()
    {
        click();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Pause()
    {
        click();
        pausedText.SetActive(true);
        pause.SetActive(false);
        resume.SetActive(true);
        mainMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void Resume()
    {
        click();
        pausedText.SetActive(false);
        pause.SetActive(true);
        resume.SetActive(false);
        mainMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void MainMenu()
    {
        click();
        Time.timeScale = 1;
        Music.Instance.menuMusic();
        SceneManager.LoadScene("MainMenu");
    }

    public void SelectLevel()
    {
        click();
        Music.Instance.menuMusic();
        SceneManager.LoadScene("Select");
    }

    public void QuitGame()
    {
        click();
        Application.Quit();
    }

    public void toTutor()
    { 
        click();
        tutorPanel.SetActive(true);
        menuPanel.SetActive(false);
    }

    public void toMenu()
    {   
        click();   
        menuPanel.SetActive(true);
        tutorPanel.SetActive(false);
    }

    public void click()
    {
        SFX.Instance.clickSound();
    }

    public void Skip()
    {
      SceneManager.LoadScene("MainMenu");  
    }

}
