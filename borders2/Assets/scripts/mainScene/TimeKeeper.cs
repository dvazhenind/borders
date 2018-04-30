using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeKeeper : MonoBehaviour {
    public float _currentScale;
    private float TargetScale;
    public float InitScale;
    private float FramesCount;
    private float AnimationTimeSeconds;
    private float _deltaTime;
    private float _dx;
    private bool _upScale = true;
    private Vector2 newTransform;
    private float timer = 0.0f;
    public float speed=3f;
    private int scores;
    private bool gameOver;
    GameControll gameControll;

    // Use this for initialization
    void Start () {

        InitScale = gameObject.GetComponent<Transform>().localScale.x;
        TargetScale = 0.0f;
        newTransform = new Vector2(TargetScale, TargetScale);
        _currentScale = InitScale;
        FramesCount = 360f;
        AnimationTimeSeconds = 12f;
        _deltaTime = AnimationTimeSeconds / FramesCount;
        _dx = (InitScale - TargetScale) / FramesCount;

        StartCoroutine(BreathSquare());
    }

    private void Update()
    {
        gameOver = GameObject.Find("GameControll").GetComponent<GameControll>().gameOver;

        
    }

    // Update is called once per frame



    private IEnumerator BreathSquare()
    {
        
        while (!gameOver)
        {
            
                _currentScale -= _dx * speed;
           

                if (_currentScale < TargetScale)
                {
                   
                    _currentScale = TargetScale;
                }
            transform.localScale =  new Vector3(_currentScale, transform.localScale.y, transform.localScale.z); 
                
                yield return new WaitForSeconds(_deltaTime);        

           
        }
    }
}
