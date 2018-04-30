using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public  class DetectChildCollision : MonoBehaviour {
    
    public  bool hasEntered;
    private GameObject gameControll;

    private void Start()
    {
        gameControll = GameObject.Find("GameControll");
        
    }

    private  void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ghostTouch")
        {
            hasEntered = true;
            gameControll.GetComponent<GameControll>().hasEntered = hasEntered;           
        }       
    }


    private  void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ghostTouch")
        {
            hasEntered = false;
            gameControll.GetComponent<GameControll>().hasEntered = hasEntered;
        }

    }

    



}
