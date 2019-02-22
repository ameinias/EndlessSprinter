using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseEndless : MonoBehaviour {

    public bool pause;
    public GameObject pauseScreen;


	// Use this for initialization
	void Start () {
        pauseScreen.SetActive(false);

    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetButtonDown("Cancel")) {
            Pause();

        }
		
	}

    public void Pause()
    {
        
        Debug.Log(pause);
        if (!pause)
        {
            pauseScreen.SetActive(true);
            pause = true;
            Debug.Log("Pause Should Be True");
        }
        else {
            pauseScreen.SetActive(false);
            pause = false;
            Debug.Log("Pause Should Be False");
        }
    }

    public void GoNext(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void PleaseQuit()
    {
        Application.Quit();
    }
}
