using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleBigger : MonoBehaviour {
    private float _currentScale;
    public float TargetScale;
    private float InitScale;
    private float FramesCount;
    private float AnimationTimeSeconds;
    private float _deltaTime;
    private float _dx;
    private bool _upScale = true;
    public float speed;
    private bool _speedUp = true;
    private int scores;

    private float initScaleColider;
    private float targetScaleColider;
    

    private void Start()
    {
        

        InitScale = gameObject.GetComponent<Transform>().localScale.x;
        if(TargetScale==0f) TargetScale = Random.Range(InitScale + 1f, 3 * InitScale);
        _currentScale = InitScale;

        FramesCount = 160;
        AnimationTimeSeconds = 0.25f;
        _deltaTime = AnimationTimeSeconds / FramesCount;
        _dx = (TargetScale - InitScale) / FramesCount;


        if (GameObject.Find("GameControll") != null) scores = GameObject.Find("GameControll").GetComponent<GameControll>().score;
        else scores = 0;
        if (scores < 5) speed = Random.Range(1.1f, 1.4f);
        else if (scores >= 5 && scores <= 10) speed = Random.Range(1.4f, 2f);
        else if (scores > 10 && scores < 15) speed = Random.Range(2f, 3f);
        else speed = Random.Range(3f, 4f);


        StartCoroutine(Breath());

        
    }

    //if scores more then n increase the random value
    private IEnumerator Breath()
{
    while (true)
    {

        while (_upScale)
        {
            _currentScale += _dx * speed;
            if (_currentScale > TargetScale)
            {
                _upScale = false;
                _currentScale = TargetScale;
            }
            transform.localScale = Vector3.one * _currentScale;
            //gameObject.GetComponent<Collider2D>().transform.localScale = Vector3.one * _currentScale;
            yield return new WaitForSeconds(_deltaTime);
        }

        while (!_upScale)
        {
            _currentScale -= _dx * speed;
            if (_currentScale < InitScale)
            {
                _upScale = true;
                _currentScale = InitScale;
            }
            transform.localScale = Vector3.one * _currentScale;
            yield return new WaitForSeconds(_deltaTime);
        }
    }
}

    
}
