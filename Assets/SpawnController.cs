using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour {
  public  List<GameObject> roadTypes;
   public GameObject nextRoad;
    int index;


	
	// Update is called once per frame
	void Update () {

    }

   

    void Start()
    {
        NewRoad();



    }

    public void NewRoad() {
        index = Random.Range(0, roadTypes.Count);
        nextRoad = roadTypes[index];
    }
}



