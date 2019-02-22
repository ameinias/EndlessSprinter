using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public float speed;
    public float jumpPower;
    public List<Transform> lanes;
    public float currentLane = 1;
    public bool dead;
    public bool grounded;

    GameController game;
    PauseEndless pauseScript;

    // Use this for initialization
    void Start()
    {
        game = FindObjectOfType<GameController>();
        if (game == null) {
            Debug.Log("can't find game controller");
        }
        pauseScript = FindObjectOfType<PauseEndless>();
    }

    // Update is called once per frame
    void Update()
    {


        if (!dead && !pauseScript.pause)
        {
            Move();
            if (Input.GetButtonDown("Vertical") || Input.GetButtonDown("Jump"))
            {

                Jump();

            }


            if (Input.GetAxisRaw("Horizontal") != 0)
            {
                ChangeLanes();

            }
        }
    }

    void Move()
    {
         if (!game.pause) { 
        transform.parent.Translate(0, 0, speed*Time.deltaTime);
        }


    }

    void Jump() {
        if (grounded)
        {
            GetComponent<Animator>().SetTrigger("Jump");
            GetComponent<Rigidbody>().AddForce(new Vector3(0, jumpPower, 0), ForceMode.Impulse);
            grounded = false;
        }

    }



    public void ChangeLanes() {

        if (Input.GetButtonDown("Horizontal")) {
        
        if (Input.GetAxisRaw("Horizontal") > 0) // right
        {
            if (currentLane == 0) { transform.position = new Vector3( lanes[1].position.x, transform.position.y, transform.position.z); currentLane = 1; }
            else if (currentLane == 1) {  transform.position =  new Vector3(lanes[2].position.x, transform.position.y, transform.position.z); currentLane = 2; }
            else { Debug.Log("NoMoreMoveRight"); }
        } //end right 
        else if (Input.GetAxisRaw("Horizontal") < 0) { // left
            if (currentLane == 0) {  Debug.Log("NoMoreLeft"); }
           else if (currentLane == 1) { transform.position =  new Vector3(lanes[0].position.x, transform.position.y, transform.position.z); currentLane = 0; }
               else if (currentLane == 2) { transform.position = new Vector3(lanes[1].position.x, transform.position.y, transform.position.z); currentLane = 1;  }
                else { Debug.Log("Else"); }
        } //left
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "Obstical")
        {
            dead = true;
            game.Die();
        }
        else if (collision.gameObject.tag == "collectable")
        {
            game.AddPoints(collision.gameObject.GetComponent<Points>().points);
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "ground") { 
            grounded = true;
        }
    }


}
