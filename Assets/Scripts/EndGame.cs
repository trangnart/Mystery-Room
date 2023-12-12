using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{

    public GameManager gameManager;

    public void OnTriggerEnter (Collider other)
    {
        Debug.Log("HERE");
        Debug.Log(gameManager.gameState);
        if (gameManager.gameState == "cluesFound") gameManager.gameState = "You escape";
        Debug.Log(gameManager.gameState);
    }
}
