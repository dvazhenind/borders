using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;


public class RestartScene : MonoBehaviour {

    

    private void OnMouseDown()
    {
        print("I work");

        Application.LoadLevel(Application.loadedLevel);
    }
}
