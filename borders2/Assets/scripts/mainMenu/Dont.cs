using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dont : MonoBehaviour {
    private static Dont instance = null;
    public static Dont Instance
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
