using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadSpawner : MonoBehaviour {


    public GameObject road;
    public float dist;
   public float timer;
    public float timerlength;
    public float startOffset;
	// Use this for initialization
	void Start () {
      //  timer = timerlength+ startOffset;
	}
	
	// Update is called once per frame
	void Update () {
        timer -= Time.deltaTime;
        Vector3 me = transform.position;
        if (timer < 0) {
            Instantiate(road,new Vector3(me.x, 0, me.z+dist), Quaternion.identity);
            timer = timerlength;
        }
		
	}
}
