using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrongPlates : MonoBehaviour
{
    public string layer; // Specify the layer for the chair or object that can be dropped
    public GameManager gameManager; // Reference to the GameManager script

    private bool triggered = false; // Ensure the trigger only activates once

    public void OnTriggerEnter(Collider other)
    {
        // Check if the trigger has already been activated or if the object layer is not the expected one
        if (triggered || other.gameObject.layer != LayerMask.NameToLayer(layer))
            return;

        // Trigger the player's death
        gameManager.TriggerDeath();

        // Set the trigger as activated
        triggered = true;
    }
}
