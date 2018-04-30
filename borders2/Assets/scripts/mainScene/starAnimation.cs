using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class starAnimation : MonoBehaviour {

    private Vector2 direction;
    private SpriteRenderer star;

    private void Start()
    {
        star = GetComponent<SpriteRenderer>();
        Destroy(star, 4f);
        direction = new Vector2(Random.Range(-1f, 1f), Random.Range(-1, 1f));
        
    }

    private void Update()
    {
        if (star != null)
        {
            star.transform.Translate(direction * Time.deltaTime);
            star.color = new Color(star.color.r, star.color.g, star.color.b, Mathf.PingPong(Time.time / 2.5f, 1f));
        }

        
    }
}
