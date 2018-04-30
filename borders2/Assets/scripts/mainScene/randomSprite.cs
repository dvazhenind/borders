using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomSprite : MonoBehaviour {

    int randomSphereSprite;
    

    public Sprite sprite1, sprite2, sprite3, sprite4, sprite5, sprite6, sprite7, sprite8;
	// Use this for initialization
	void Start () {


        randomSphereSprite = Random.Range(0, 8);
        switch (randomSphereSprite)
        {
            case 0:
                gameObject.GetComponent<SpriteRenderer>().sprite = sprite1;
                break;
            case 1:
                gameObject.GetComponent<SpriteRenderer>().sprite = sprite2;
                break;
            case 2:
                gameObject.GetComponent<SpriteRenderer>().sprite = sprite3;
                break;
            case 3:
                gameObject.GetComponent<SpriteRenderer>().sprite = sprite4;
                break;
            case 4:
                gameObject.GetComponent<SpriteRenderer>().sprite = sprite5;
                break;
            case 5:
                gameObject.GetComponent<SpriteRenderer>().sprite = sprite6;
                break;
            case 6:
                gameObject.GetComponent<SpriteRenderer>().sprite = sprite7;
                break;
            case 7:
                gameObject.GetComponent<SpriteRenderer>().sprite = sprite8;
                break;




        }

    }
	
}
