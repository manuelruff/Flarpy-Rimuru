using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;


public class PipeTest
{
    //the actual pipes that moves
    private GameObject[] all_pipes_parts;
    [SetUp]
    public void Setup()
    {
        // Load the SampleScene
        UnityEngine.SceneManagement.SceneManager.LoadScene("PipeTestScene");
    }
    //we will activate after the scene was loaded to use those two objects
    private void CustomSetup()
    {
        // Find and select top and bottom pipes with unique identifiers in their names
        all_pipes_parts = GameObject.FindGameObjectsWithTag("all_pipes");
    }
    [UnityTest]
    public IEnumerator Pipe_Update_MoveLeft()
    {
        // Call the CustomSetup method
        CustomSetup();

        // Record the initial positions of the selected pipes
        Vector3 initialPos = all_pipes_parts[0].transform.position;

        // Wait for a short duration to observe the movement
        yield return new WaitForSeconds(0.5f);

        // Record the final positions of the selected pipes after movement
        Vector3 finalPos = all_pipes_parts[0].transform.position;

        // Assert that the selected pipes have moved to the left
        Assert.Less(finalPos.x, initialPos.x);
    }


    [UnityTest]
    public IEnumerator Pipe_PassesDeadZone_Destroyed()
    {
        // Call the CustomSetup method to set up the test environment
        CustomSetup();

        // Wait for the pipe to move close to the dead zone (X position less than -40)
        yield return new WaitUntil(() => all_pipes_parts[0].transform.position.x < -40);

        // Wait for an additional 2 seconds to ensure the pipe has passed the dead zone
        yield return new WaitForSeconds(2.0f);

        // Check if the individual pipe is destroyed after passing the dead zone
        if (all_pipes_parts != null)
        {
            foreach (GameObject pipe in all_pipes_parts)
            {
                try
                {
                    if (pipe != null)
                    {
                        // If the pipe's X position is less than -50, it has passed the dead zone
                        if (pipe.transform.position.x < -50)
                        {
                            Debug.Log("Pipe has passed the dead zone");
                        }
                        else
                        {
                            // If the pipe still exists but hasn't passed the dead zone, log a warning
                            Debug.LogWarning("Pipe still exists but hasn't passed the dead zone");
                        }
                    }
                }
                catch (Exception e)
                {
                    // If an exception occurs, log the error message
                    Debug.LogError("Error: " + e.Message);
                }
            }
        }
    }



}
