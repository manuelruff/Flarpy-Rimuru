using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rimuruScript : MonoBehaviour
{
    public Rigidbody2D MyRidgidBody;
    //the jump force of the bird
    public float jumpForce;
    public logicScript logic;
    public bool birdIsAlive = true;
    //wing used for animation
    public GameObject wing;

    // Start is called before the first frame update
    void Start()
    {
        //get the logic script so i can get to the game over window
        logic = GameObject.FindGameObjectWithTag("logic").GetComponent<logicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        //if the key that was pressed is the space key and the bird is alive
        if (Input.GetKeyDown(KeyCode.Space) && birdIsAlive)
        {
            //move the bird up
            MyRidgidBody.velocity = Vector2.up * jumpForce;
            //play the wing animation
            wing.GetComponent<Animator>().Play("wingAnimation");
        }
        //if the bird goes out of the screen the game is endded
        if (transform.position.y > 27 || transform.position.y < -26)
        {
            logic.gameOver();
            birdIsAlive = false;
        }
    }
    //if the bird hits the pipes the game is endded
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //activate game over window
        logic.gameOver();
        //kill the bird
        birdIsAlive = false;
    }
}
