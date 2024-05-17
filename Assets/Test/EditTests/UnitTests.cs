using UnityEngine;
using UnityEngine.UI;
using NUnit.Framework;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using System.Collections;
using UnityEditor.SceneManagement;

public class UnitTests
{
    public class rimuruTests
    {
        private rimuruScript rimuruScriptInstance;
        private logicScript logicScriptInstance;

        [SetUp]
        public void Setup()
        {
            // Create GameObjects for rimuru and logic
            GameObject rimuruObject = new GameObject("rimuru");
            GameObject logicObject = new GameObject("logic");

            // Add rimuruScript and logicScript components
            rimuruScriptInstance = rimuruObject.AddComponent<rimuruScript>();
            logicScriptInstance = logicObject.AddComponent<logicScript>();

            // Initialize rimuruScript properties
            rimuruScriptInstance.MyRidgidBody = rimuruObject.AddComponent<Rigidbody2D>();
            rimuruScriptInstance.jumpForce = 10f;
            rimuruScriptInstance.logic = logicScriptInstance;
            rimuruScriptInstance.birdIsAlive = true;

        }

        [Test]
        public void RimuruScript_InitializesProperly()
        {
            // Verify that rimuruScript properties are initialized correctly
            Assert.IsNotNull(rimuruScriptInstance.MyRidgidBody);
            Assert.AreEqual(10f, rimuruScriptInstance.jumpForce);
            Assert.AreEqual(logicScriptInstance, rimuruScriptInstance.logic);
            Assert.IsTrue(rimuruScriptInstance.birdIsAlive);
        }
    }

    public class LogicScriptTests
    {
        private logicScript logicScriptInstance;

        [SetUp]
        public void Setup()
        {
            // Create a GameObject for logic
            GameObject logicObject = new GameObject("Logic");

            // Add logicScript component
            logicScriptInstance = logicObject.AddComponent<logicScript>();

            // Initialize logicScript properties
            logicScriptInstance.playerScore = 0;

            // Create a Text component for scoreText
            GameObject scoreTextObject = new GameObject("ScoreText");
            Text scoreTextComponent = scoreTextObject.AddComponent<Text>();
            logicScriptInstance.scoreText = scoreTextComponent;

            // Create a GameObject for gameOverScreen
            GameObject gameOverScreenObject = new GameObject("GameOverScreen");
            logicScriptInstance.gameOverScreen = gameOverScreenObject;

            // Make sure gameOverScreen is inactive initially
            gameOverScreenObject.SetActive(false);
        }

        [Test]
        public void LogicScript_AddScore_IncreasesScore()
        {
            // Call addScore method with points = 10
            logicScriptInstance.addScore(10);

            // Verify that playerScore is increased and scoreText is updated
            Assert.AreEqual(10, logicScriptInstance.playerScore);
            Assert.AreEqual("10", logicScriptInstance.scoreText.text);
        }

        [Test]
        public void LogicScript_GameOver_ActivatesGameOverScreen()
        {
            // Call gameOver method
            logicScriptInstance.gameOver();

            // Verify that gameOverScreen is activated
            Assert.IsTrue(logicScriptInstance.gameOverScreen.activeSelf);
        }
    }


}
