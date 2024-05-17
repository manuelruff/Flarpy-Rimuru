using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography;
using UnityEngine;

public class pipeMoveScript : MonoBehaviour
{
    //speed of the pipe
    public float speed =5;
    //dead zone of the pipe, after the pipe passes this point it will be destroyed so we wont have unnessesary pipes in the scene
    public float deadZone = -50;

    // Update is called once per frame
    void Update()
    {
        //move the pipe to the left
        transform.position += Vector3.left * speed * Time.deltaTime;
        //if the pipe passes the dead zone, destroy it
        if (transform.position.x < deadZone)
        {
            UnityEngine.Debug.Log("Destroying pipe");
            Destroy(gameObject);
        }
    }
}
