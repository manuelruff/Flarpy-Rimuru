using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class logicScript : MonoBehaviour
{
    //we will keep the score of the player here
    public int playerScore;
    //we will updadte the score text here
    public Text scoreText;
    //game over screen
    public GameObject gameOverScreen;

   
    [ContextMenu("increase score")]
    public void addScore(int points)
    {   
        playerScore += points;
        scoreText.text = playerScore.ToString();
    }

    //after the game is over we will reset the game when pressed play again
    public void resetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    //if the game is over we will activate the game over screen
    public void gameOver()
    {
        gameOverScreen.SetActive(true);
    }
}
