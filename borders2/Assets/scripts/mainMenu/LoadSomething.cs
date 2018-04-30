using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class LoadSomething : MonoBehaviour {

   

   

    private void OnMouseDown()
    {
        PlayerPrefs.DeleteKey("firstTime");

        if(PlayerPrefs.GetInt("firstTime", 0)==0)
        {           
            PlayerPrefs.SetInt("firstTime", PlayerPrefs.GetInt("firstTime")+1);
            SceneManager.LoadScene("tutorial");
        }
        else  SceneManager.LoadScene("main");
        

        

    }
}
