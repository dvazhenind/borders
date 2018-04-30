using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleSmaller : MonoBehaviour {

    private float _currentScale;
    private float TargetScale;
    private float InitScale;
    private float FramesCount;
    private float AnimationTimeSeconds;
    private float _deltaTime;
    private float _dx;
    private bool _upScale = true;
    private Vector2 newTransform;
    private float timer = 0.0f;
    public float speed;
    private int scores;

    

    private void Start()
    {
        
            InitScale = gameObject.GetComponent<Transform>().localScale.x;
            TargetScale = Random.Range(0.30977f, InitScale - 0.6f);
            newTransform = new Vector2(TargetScale, TargetScale);
            _currentScale = InitScale;
            FramesCount = 160f;
            AnimationTimeSeconds = 0.25f;
            _deltaTime = AnimationTimeSeconds / FramesCount;
            _dx = (InitScale - TargetScale) / FramesCount;


        if (GameObject.Find("GameControll") != null) scores = GameObject.Find("GameControll").GetComponent<GameControll>().score;
        else scores = 0;

        if (scores < 5) speed = Random.Range(1.1f, 1.4f);
        else if (scores >= 5 && scores <= 10) speed = Random.Range(1.4f, 2f);
        else if (scores > 10 && scores < 15) speed = Random.Range(2f, 3f);
        else speed = Random.Range(3f, 4f);

        StartCoroutine(BreathSquare());
        
        

        


    }

    

    private void OnBecameInvisible()
    {
        Destroy(gameObject);

    }


    private IEnumerator BreathSquare()
    {
        while (true)
        {
            while (_upScale)
            {
                _currentScale -= _dx * speed;

                if (_currentScale < TargetScale)
                {
                    _upScale = false;
                    _currentScale = TargetScale;
                }
                transform.localScale = Vector3.one * _currentScale;
                yield return new WaitForSeconds(_deltaTime);
            }

            while (!_upScale)
            {
                _currentScale += _dx * speed;
                if (_currentScale > InitScale)
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
