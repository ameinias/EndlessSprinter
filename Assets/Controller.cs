using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Controller : MonoBehaviour {

    public List<GameObject> collection;
    public Text scoreText;
    public float numObject;
    public GameObject GameOverScreen;

    // Use this for initialization
    void Start()
    {
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("collectable"))
        {

            collection.Add(obj);
        }
        numObject = collection.Count;
        UpdateScore();
        GameOverScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))

        {
            CheckForClicks();
        }
    }

    void CheckForClicks()
    {

        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 100.0f))
        {
            //suppose i have two objects here named obj1 and obj2.. how do i select obj1 to be transformed 
            if (hit.transform != null)
            {
                Debug.Log("Hit" + hit.transform.name);
                if (collection.Contains(hit.transform.gameObject))
                {
                    Destroy(hit.transform.gameObject);
                    collection.Remove(hit.transform.gameObject);
                    UpdateScore();
                }
            }
        }


    }

    void UpdateScore() {
        float currentOBJ = numObject - collection.Count;
        scoreText.text = currentOBJ + " / " + numObject;

        if (currentOBJ >= numObject) {
            GameOverScreen.SetActive(true);
            Debug.Log("Done");
        }
    }


    public void GoNext(string scene) {
        SceneManager.LoadScene(scene);
    }



 




}
