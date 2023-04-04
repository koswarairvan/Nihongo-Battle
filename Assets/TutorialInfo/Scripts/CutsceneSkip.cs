using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutsceneSkip : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
      SceneManager.LoadScene("MainMenu");  
    }
    public void Skip()
    {
      SceneManager.LoadScene("MainMenu");  
    }
}
