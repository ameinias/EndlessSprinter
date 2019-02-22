using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTrigger : MonoBehaviour {
    public GameObject road;
    public float dist;
    SpawnController roadSpawner;
    // Use this for initialization
    void Start () {
        roadSpawner = FindObjectOfType<SpawnController>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        Vector3 me = transform.position;
        if (other.tag == "Player")
        {
            GameObject thisroad = roadSpawner.nextRoad;
            GameObject newRoad = Instantiate(thisroad, new Vector3(me.x, 0, me.z + dist), Quaternion.identity);
            newRoad.transform.parent = transform.parent.parent;
            roadSpawner.NewRoad();


        }
    }
}
