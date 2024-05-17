using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class BirdTest
{
    //Rimuru GameObject in the scene
    private GameObject rimuruObject;
    //rimuruScript component of the Rimuru GameObject
    private rimuruScript rimuru;
    [SetUp]
    public void Setup()
    {
        // Load the SampleScene
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainScene");
        
    }
    //we will activate after the scene was loaded to use those two objects
    private void CustomSetup()
    {
        // Find Rimuru GameObject in the scene
        rimuruObject = GameObject.FindGameObjectWithTag("rimuru");
        // Attempt to get the rimuruScript component
        rimuru = rimuruObject.GetComponent<rimuruScript>();
    }
    [UnityTest]
    public IEnumerator rimuru_outOfWindow_Dies()
    {
        // Call the CustomSetup method
        CustomSetup();
        // Record Rimuru's initial position
        Vector3 initialPosition = rimuruObject.transform.position;

        // Move Rimuru out of the window
        rimuruObject.transform.position = new Vector3(initialPosition.x, -27f, initialPosition.z);

        // Wait for a frame to allow Rimuru to fall out of the window
        yield return null;

        // Check if Rimuru is dead after falling out of the window
        Assert.IsFalse(rimuru.birdIsAlive);
    }
    [UnityTest]
    public IEnumerator rimuru_OutOfWindowUp_Die()
    {
        // Call the CustomSetup method
        CustomSetup();

        // Record Rimuru's initial position
        Vector3 initialPosition = rimuruObject.transform.position;

        // Move Rimuru out of the window
        rimuruObject.transform.position = new Vector3(initialPosition.x, 28f, initialPosition.z);

        // Wait for a frame to allow Rimuru to fall out of the window
        yield return null;

        // Check if Rimuru is dead after falling out of the window
        Assert.IsFalse(rimuru.birdIsAlive);
    }
    [UnityTest]
    public IEnumerator rimuru_NoInput_Falls()
    {
        // Call the CustomSetup method
        CustomSetup();
        // Record Rimuru's initial position
        Vector3 initialPosition = rimuruObject.transform.position;

        // Wait for a few frames to allow Rimuru to fall
        yield return new WaitForSeconds(0.5f); // Adjust time as needed

        // Record Rimuru's position after falling
        Vector3 finalPosition = rimuruObject.transform.position;

        // Check if Rimuru's position has changed after falling
        Assert.Greater(initialPosition.y, finalPosition.y);
    }
    [UnityTest]
    public IEnumerator rimuru_SimulatedJump_PositionChange()
    {
        // Call the CustomSetup method
        CustomSetup();
        // Set Rimuru's components
        rimuru.jumpForce = 15;

        // Record Rimuru's initial position
        Vector3 initialPosition = rimuruObject.transform.position;

        // Perform a simulated jump
        rimuru.MyRidgidBody.velocity = Vector3.up * rimuru.jumpForce;
        // Wait for a frame to allow Rimuru to ascend
        yield return new WaitForSeconds(0.5f); // Adjust time as needed

        // Record Rimuru's position after the jump
        Vector3 finalPosition = rimuruObject.transform.position;

        // Check if Rimuru's position has changed after the jump
        Assert.AreNotEqual(initialPosition, finalPosition);
    }
    [UnityTest]
    public IEnumerator rimuru_Bigjump_Die()
    {
        // Call the CustomSetup method
        CustomSetup();
        // Set Rimuru's jump force
        rimuru.jumpForce = 100;

        // Record Rimuru's initial position
        Vector3 initialPosition = rimuruObject.transform.position;

        // Set Rimuru's velocity to simulate jump
        rimuru.MyRidgidBody.velocity = Vector2.up * rimuru.jumpForce;

        // Wait for a frame to allow Rimuru to ascend
        yield return new WaitForSeconds(0.5f); // Adjust time as needed

        // Check if Rimuru is dead after 10 consecutive jumps
        Assert.IsFalse(rimuru.birdIsAlive);
    }
    [UnityTest]
    public IEnumerator rimuru_OutOfWindowDown_Die()
    {
        // Call the CustomSetup method
        CustomSetup();
        // Wait for a frame to allow Rimuru to descend
        yield return new WaitForSeconds(3); // Adjust time as needed

        // Check if Rimuru is dead after 10 consecutive jumps
        Assert.IsFalse(rimuru.birdIsAlive);
    }
    [UnityTest]
    public IEnumerator rimuru_StuckInPipe_die()
    {
        // Call the CustomSetup method
        CustomSetup();
        // Set Rimuru's jump force
        rimuru.jumpForce = 15;

        // Record Rimuru's initial position
        Vector3 initialPosition = rimuruObject.transform.position;

        // Perform multiple jumps to collide with the pipe
        for (int i = 0; i < 50; i++)
        {
            // Set Rimuru's velocity to simulate a jump
            rimuru.MyRidgidBody.velocity = Vector2.up * rimuru.jumpForce;

            // Wait for a short delay before the next jump
            yield return new WaitForSeconds(0.7f);

            // Check if Rimuru collided with the pipe
            if (!rimuru.birdIsAlive)
            {
                // If Rimuru collided with the pipe, end the test
                break;
            }
        }

        // Check if Rimuru is dead after 10 consecutive jumps
        Assert.IsFalse(rimuru.birdIsAlive);
    }
    [UnityTest]
    public IEnumerator rimuru_WhenPassingPipes_AddsScore()
    {
        // Call the CustomSetup method
        CustomSetup();
        // Find the middle part of the pipe GameObject in the scene
        GameObject middlePipeObject = GameObject.FindGameObjectWithTag("middle");

        // Wait for a frame to allow objects to settle
        yield return null;

        // Ensure Rimuru is alive before starting the test
        rimuru.birdIsAlive = true;

        // Move Rimuru to the middle part of the pipes
        rimuruObject.transform.position = middlePipeObject.transform.position;

        // Wait for a short delay to observe the movement
        yield return new WaitForSeconds(1.0f);

        // Check if the score has been incremented
        Assert.AreEqual(1, rimuru.logic.playerScore);
    }
}
