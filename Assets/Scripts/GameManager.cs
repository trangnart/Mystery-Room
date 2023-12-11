using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Light[] lights;

    public GameObject endDoor;

    public bool plateState = true;

    public int cluesFound = 0;

    public int maxClues = 2;

    public string gameState = "Start";

    void Start()
    {
        foreach(Light light in lights)
        {
            light.enabled = false;
        }
    }

    void Update()
    {
        if (gameState == "gameOver")
        {
            return;
        }
        if (cluesFound == maxClues)
        {
            endDoor.transform.position += new Vector3(0, 3, 0);
            gameState = "cluesFound";
        }
    }
}
