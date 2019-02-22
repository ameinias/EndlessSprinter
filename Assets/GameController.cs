using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public Text timerText;
    public Text scoreText;

    public float score;
   
    public static float timer;
    public static bool timeStarted = false;
    public GameObject GameOver;
    public GameObject player;
    public bool started = false;
    public bool dead;
    public bool pause;
    PauseEndless pauseScript;

    // Use this for initialization
    void Start () {
        GameOver.SetActive(false);
        player = GameObject.FindGameObjectWithTag("Player");
        pause = true;
        pauseScript = FindObjectOfType<PauseEndless>();

    }

    // Update is called once per frame
    void Update() {


        if (!started) {
            pause = true;
            if (pause && Input.anyKey)
            {
                pause = false;
                started = true;
            }
        } else
        { if (!dead && !pauseScript.pause)
            {
                timer += Time.deltaTime;
                int minutes = Mathf.FloorToInt(timer / 60F);
                int seconds = Mathf.FloorToInt(timer - minutes * 60);
                float fraction = timer * 1000;
                fraction = Mathf.FloorToInt(fraction % 1000);
                string niceTime = string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, fraction);
                timerText.text = niceTime;
            }
        }

    }

    public void AddPoints(float points)
    {
        score += points;
        scoreText.text = score.ToString();


    }

    public void Die() {
        pause = true;
        GameOver.SetActive(true);
        dead = true;
    }

    public void Restart() {
  
        GameOver.SetActive(false);

        player.transform.parent.position = Vector3.zero;
        player.GetComponent<MovePlayer>().dead = false;

        timer = 0;
        score = 0;

        dead = false;
        started = false;
        pause = false;


        scoreText.text = score.ToString();
        timerText.text = timer.ToString();
        string sceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(sceneName);

    }






}
