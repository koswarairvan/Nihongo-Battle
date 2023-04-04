using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public Text soundTog;
    string soundTogText ;
    
    

    void Start()
    {
        soundTog = GetComponentInChildren<Text>();
        if (Music.Instance.musics[0].mute == false)
        {
            soundTogText ="Music:ON";
        }
        else
        {
            soundTogText  ="Music:OFF";
        }
        soundTog.text = soundTogText;
    }

    public void SoundToggle()
    {
        if (soundTog.text =="Music:OFF")
        {
            soundTogText ="Music:ON";
            soundTog.text = soundTogText;
        }
        else
        {
            soundTogText  ="Music:OFF";
            soundTog.text = soundTogText;
        }
        SFX.Instance.clickSound();
        Music.Instance.MenuToggle();
    }
}
