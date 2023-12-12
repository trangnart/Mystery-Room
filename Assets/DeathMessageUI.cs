using UnityEngine;

public class DeathMessageUI : MonoBehaviour
{
    public Transform playerCamera; // Reference to the player's camera or GameObject
    public float distanceFromCamera = 2f; // Adjust the value as needed
   
    void Update()
    {
        // Update the Canvas position to be in front of the player's camera
        if (playerCamera != null)
        {
            transform.position = playerCamera.position + playerCamera.forward * distanceFromCamera;
            transform.rotation = playerCamera.rotation;
        }
    }
}