using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour
{
    //public Light[] lights;
    public GameObject endDoor;
    public PlayerMovement playerMovement; // Reference to the PlayerMovement script
    public GameObject deathMessageUI; // Assign a UI GameObject with the "You Died" message
    public GameObject chairPic;
    public Transform startingPoint; // Assign the starting point Transform

    public bool plateState = true;
    public int cluesFound = 0;
    public int maxClues = 2;
    public string gameState = "Start";

    void Start()
    {
        //foreach (Light light in lights)
        //{
        //    light.enabled = false;
        //}
        deathMessageUI.SetActive(false); // Make sure the death message is not shown at start
	chairPic.SetActive(false);// Make sure the picture is not shown at start
	// Set the starting point position
    	//startingPoint.position = new Vector3(0.34f, 0.84f, -55.49f);
    }

    void Update()
    {
        if (gameState == "gameOver")
        {
            // If the game is over, do nothing
            return;
        }

        // Your existing game logic...

        if (cluesFound == maxClues)
        {
            endDoor.transform.position += new Vector3(0, 3, 0);
            gameState = "cluesFound";
        }
    }

    // Call this method when the player fails a puzzle
    public void TriggerDeath()
    {
        StartCoroutine(HandleDeath());
    }

    private IEnumerator HandleDeath()
    {
        playerMovement.DisableControl(); // Disable player controls
        deathMessageUI.SetActive(true); // Show "You Died" message
        yield return new WaitForSeconds(3); // Wait for 3 seconds
        deathMessageUI.SetActive(false); // Hide "You Died" message
        playerMovement.transform.position = startingPoint.position; // Teleport player to start
        playerMovement.EnableControl(); // Re-enable player controls
	chairPic.SetActive(true);//display picture
    }
}
