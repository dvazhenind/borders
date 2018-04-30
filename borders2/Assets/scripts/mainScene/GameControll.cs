using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEditor.SceneManagement;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;

public class GameControll : MonoBehaviour {

    public GameObject squareCombination, circleCombination, timer, catchSound, looseSound, firstCanvas, secondCanvas;
    public Text scores, finalScores, gameOverText, highScore;
    public bool hasEntered, gameOver, acceptable = true;    
    public int score = 0;

    private GameObject prefab;
    private TimeKeeper timeKeeper;
    private Vector2 randomPosition, direction;
    private bool spawnOrNot = true;
    private int  randomSphereSprite;
    private static int advCount = 0;



    void Start () {
        if (Advertisement.isSupported)
        {
            Advertisement.Initialize("1648855", false);
        }
        else Debug.Log("Platform is not supported00");

        catchSound = GameObject.Find("catchSound");
        looseSound = GameObject.Find("looseSound");

        timeKeeper = GameObject.Find("Cube").GetComponent<TimeKeeper>();
             
    }


    void Update () {
        
        if (Input.GetMouseButtonDown(0)) SendMessage("OnMouseDown");

        if (gameOver != true)
        {
            randomPosition = Random.insideUnitSphere * 2.1f + transform.position; //Generating new position

            if (spawnOrNot)                                                       // If spawn is avaliable
            {
                prefab = Instantiate(circleCombination, randomPosition, Quaternion.identity);
                spawnOrNot = false;
                timeKeeper._currentScale = timeKeeper.InitScale;                  // Refresh TimeKeeper
                prefab.GetComponent<Rigidbody2D>().gravityScale = 0;
                turnOnColliders(prefab);

            }


            if (timeKeeper._currentScale == 0) GameOver();
        }
    }
   
    private void OnMouseDown()
    {          
          if (hasEntered)
          {
               catchSound.GetComponent<AudioSource>().Play();
               score++;
               scores.text = score.ToString();

               prefab.GetComponent<Rigidbody2D>().gravityScale = 3;  // Falling object           
               prefab.GetComponent<RandomMovement>().enabled = false;
               turnOffColliders(prefab);


               spawnOrNot = true;
               direction = new Vector2(Random.Range(-1f, 1f) * Time.deltaTime, Random.Range(-1f, 1f) * Time.deltaTime);

          }
          else if(hasEntered==false && gameOver!=true)
          {                    
              GameOver();
          }
    }

    public void GameOver()
    {
        gameOver = true;
        looseSound.GetComponent<AudioSource>().Play();
        Destroy(prefab);

        firstCanvas.SetActive(false);
        secondCanvas.SetActive(true);


        if(score>PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", score);
        }
        finalScores.text = finalScores.text + " " + score.ToString();
        highScore.text = highScore.text+" "+PlayerPrefs.GetInt("HighScore", 0).ToString();

        advCount++;
        if (Advertisement.IsReady() && advCount % 5 == 0)
        {
            Advertisement.Show();
        }
        
    }

    public void turnOffColliders(GameObject respawn)
    {
        foreach (Collider2D c in respawn.GetComponentsInChildren<Collider2D>())
        {
            c.enabled = false;
        }
    }

    public void turnOnColliders(GameObject respawn)
    {
        foreach (Collider2D c in respawn.GetComponentsInChildren<Collider2D>())
        {
            c.enabled = true;
        }
    }

    

    



}
