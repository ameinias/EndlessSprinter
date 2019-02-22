﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour {

    public Vector3 pz;
    public Vector3 StartPos;

    public int moveModifier;

    // Use this for initialization
    void Start()
    {
        StartPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pz = Camera.main.ScreenToViewportPoint(Input.mousePosition);
        pz.z = -10;
        gameObject.transform.position = pz;
        //Debug.Log("Mouse Position: " + pz);

        transform.position = new Vector3(StartPos.x + (pz.x * moveModifier), StartPos.y + (pz.y * moveModifier), pz.z);
        //move based on the starting position and its modified value.
    }

}