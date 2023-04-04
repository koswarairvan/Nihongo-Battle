using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFX : MonoBehaviour
{
    public static SFX Instance {get; set;}

    public AudioSource[] sfxs;

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

    public void clickSound()
    {
        sfxs[0].Play();
    }

    public void SFXToggle()
    {
        if (sfxs[0].mute == false)
        {
            for (int i=0; i<=sfxs.Length;i++)
            {
                sfxs[i].mute = true;
            }
            
            
        }
        else
        {
            for (int i=0; i<=sfxs.Length;i++)
            {
                sfxs[i].mute = false;
            }
        }
    }
}
