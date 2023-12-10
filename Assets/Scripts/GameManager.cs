using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Light[] lights;

    public GameObject endDoor;

    public bool plateState = true;

    public int cluesFound = 0;

    public int maxClues = 5;

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
}
