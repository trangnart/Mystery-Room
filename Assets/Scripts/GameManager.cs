using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public Light[] lights;
    public GameObject endDoor;
    public PlayerMovement playerMovement; // Reference to the PlayerMovement script
    public GameObject deathMessageUI; // Assign a UI GameObject with the "You Died" message
    public Transform startingPoint; // Assign the starting point Transform

    public bool plateState = true;
    public int cluesFound = 0;
    public int maxClues = 5;
    public string gameState = "Start";

    void Start()
    {
        foreach (Light light in lights)
        {
            light.enabled = false;
        }
        deathMessageUI.SetActive(false); // Make sure the death message is not shown at start
    }

    void Update()
    {
        if (gameState == "gameOver")
        {
            // If the game is over, do nothing
            return;
        }

        // Your existing game logic...
        
        if (plateState && lights[0].enabled && lights[1].enabled && lights[2].enabled && lights[3].enabled && lights[4].enabled)
        {
            plateState = false;
            cluesFound += 1;
        }

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
    }
}
