using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pipeMiddleScript : MonoBehaviour
{
    //get the logic script so i can add score
    public logicScript logic;
    //get the rimuru script so i can check if the bird is alive
    public rimuruScript rimuru;
    // Start is called before the first frame update
    void Start()
    {
        logic= GameObject.FindGameObjectWithTag("logic").GetComponent<logicScript>();
        rimuru = GameObject.FindGameObjectWithTag("rimuru").GetComponent<rimuruScript>();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        //if the bird pass the pipes, add score
        if(collision.gameObject.tag == "rimuru" && rimuru.birdIsAlive)
        {
            logic.addScore(1);
        }
    }
}
