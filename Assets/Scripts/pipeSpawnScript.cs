using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class pipeSpawnScript : MonoBehaviour
{
    //tamplate of pipes that we wanna apawn
    public GameObject pipe;
    //rate of spawning pipes, can be adjusted in the editor
    public float spawnRate = 4;
    //timer for spawning pipes
    private float timer = 0;
    //offset for the height of the pipes
    public float hightOffset =8;

    // Start is called before the first frame update
    void Start()
    {
        //spawn the first pipe in the beginnig 
        spawnPipe();
    }

    // Update is called once per frame
    void Update()
    {
        //if the timer is less than the spawn rate, increment the timer
        if(timer< spawnRate)
        {
            timer=timer + Time.deltaTime;
        }
        //if the timer is greater than the spawn rate, spawn a pipe and reset the timer
        else
        {
            spawnPipe();
            timer = 0;
        }
    }
    private void spawnPipe()
    {
        //get the lowest and highest point of the pipe
        float lowestPoint = transform.position.y - hightOffset;
        float highestPoint = transform.position.y + hightOffset;
        //spawn the pipe at a random height between the lowest and highest point
        Instantiate(pipe, new Vector3(transform.position.x, UnityEngine.Random.Range(lowestPoint, highestPoint), 0), transform.rotation);
    }
}
