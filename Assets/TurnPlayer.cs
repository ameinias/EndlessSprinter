using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnPlayer : MonoBehaviour
{
    public bool left;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Turn();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            // other.gameObject.GetComponent<MovePlayer>().Turn(left);
            Turn();
        }
    }

    public void Turn()
    {
        Debug.Log("TURN");
        Animator anim = GetComponentInParent<Animator>();

        anim.SetTrigger("RoadRight");

    }
}
