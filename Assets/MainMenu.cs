﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public void GoNext(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void PleaseQuit()
    {
        Application.Quit();
    }
}
