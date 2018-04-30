using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckForEntering : MonoBehaviour {    

    private void OnBecameInvisible()
    {

        Destroy(gameObject);
    }

    

}
