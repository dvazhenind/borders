using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class ToMainMenu : MonoBehaviour {



    private void OnMouseDown()
    {
        
        SceneManager.LoadScene("main_01");

    }
}
