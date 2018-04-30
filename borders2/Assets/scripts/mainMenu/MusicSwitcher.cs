using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSwitcher : MonoBehaviour {

 
    public Sprite musicOn;
    public Sprite musicOff;

    void Awake()
    {
        if (PlayerPrefs.GetInt("musicSwitcher", 1) > 0)
        {
            GameObject.Find("musi").GetComponent<AudioSource>().mute = false;
            gameObject.GetComponent<SpriteRenderer>().sprite = musicOn;
        }
        else
        {
            GameObject.Find("musi").GetComponent<AudioSource>().mute = true;
            gameObject.GetComponent<SpriteRenderer>().sprite = musicOff;
        }
    }

    private void OnMouseDown()
    {
        if (PlayerPrefs.GetInt("musicSwitcher", 1) > 0)
        {
            PlayerPrefs.SetInt("musicSwitcher", -1);
            gameObject.GetComponent<SpriteRenderer>().sprite = musicOff;
            GameObject.Find("musi").GetComponent<AudioSource>().mute = true;
        }
        else
        {
            PlayerPrefs.SetInt("musicSwitcher", 1);
            gameObject.GetComponent<SpriteRenderer>().sprite = musicOn;
            GameObject.Find("musi").GetComponent<AudioSource>().mute = false;
        }

      

    }
    
	
}
