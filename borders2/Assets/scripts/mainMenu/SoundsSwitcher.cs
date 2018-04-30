using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsSwitcher : MonoBehaviour {
    public Sprite soundOn, soundOff;

    void Awake()
    {
        if (PlayerPrefs.GetInt("soundSwitcher", 1) > 0) gameObject.GetComponent<SpriteRenderer>().sprite = soundOn;
        else gameObject.GetComponent<SpriteRenderer>().sprite = soundOff;
    }

    private void OnMouseDown()
    {
        
        if (PlayerPrefs.GetInt("soundSwitcher",1) > 0)
        {

            GameObject.Find("catchSound").GetComponent<AudioSource>().mute = true;
            GameObject.Find("looseSound").GetComponent<AudioSource>().mute = true;
            PlayerPrefs.SetInt("soundSwitcher",-1);
            gameObject.GetComponent<SpriteRenderer>().sprite = soundOff;

            

        }
        else
        {
            GameObject.Find("catchSound").GetComponent<AudioSource>().mute = false;
            GameObject.Find("looseSound").GetComponent<AudioSource>().mute = false;
            PlayerPrefs.SetInt("soundSwitcher", 1);
            gameObject.GetComponent<SpriteRenderer>().sprite = soundOn;

        }
        
    }
}
