using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Music : MonoBehaviour
{
    public static Music Instance {get; set;}

    public AudioSource[] musics;

    private void Awake() {
        
        DontDestroyOnLoad(this);
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        musics[0].Play();
    }

    public void battleStart()
    {
        musics[0].Stop();
        musics[1].Play();
    }

    public void menuMusic()
    {
        musics[1].Stop();
        musics[0].Play();
    }

    public void MenuToggle()
    {
        if (musics[0].mute == false)
        {
            for (int i=0; i<=musics.Length;i++)
            {
                musics[i].mute = true;
            }
            
            
        }
        else
        {
            for (int i=0; i<=musics.Length;i++)
            {
                musics[i].mute = false;
            }
        }
    }
}



