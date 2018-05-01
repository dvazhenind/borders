using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowRed : MonoBehaviour {

    public Sprite showRed;
    private Sprite initSprite;

   

	// Use this for initialization
	void Start () {
        initSprite = GameObject.Find("circle_F").GetComponent<SpriteRenderer>().sprite;
        
		
	}
	
	// Update is called once per frame
	void Update () {
        if (gameObject.GetComponent<DetectChildCollision>().hasEntered == true)
        {
            GameObject.Find("circle_F").GetComponent<SpriteRenderer>().sprite = showRed;
        }
        else
        {
            GameObject.Find("circle_F").GetComponent<SpriteRenderer>().sprite = initSprite;
        }
		
	}
}
