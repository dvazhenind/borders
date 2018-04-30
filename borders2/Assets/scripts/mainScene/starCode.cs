using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class starCode : MonoBehaviour {


    public GameObject star;
	// Use this for initialization
	void Start () {
        StartCoroutine(spawn());
		
	}

    IEnumerator spawn()
    {
        while (true)
        {
            Vector3 pos = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(0, Screen.width), Random.Range(0, Screen.width), Camera.main.farClipPlane / 2));
            Instantiate(star, pos, Quaternion.identity);
            yield return new WaitForSeconds(0.5f); 
        }
    }
	
	
}
