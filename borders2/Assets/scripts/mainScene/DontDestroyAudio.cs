using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyAudio : MonoBehaviour {

    private static DontDestroyAudio instance = null;
    public static DontDestroyAudio Instance
    {
        get { return instance; }
    }
    private void Awake()
    {
        if(instance!=null && instance != this)
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
