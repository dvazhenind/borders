using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dont2 : MonoBehaviour {

    private static Dont2 instance = null;
    public static Dont2 Instance
    {
        get { return instance; }
    }
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }

        DontDestroyOnLoad(this.gameObject);
    }
}
