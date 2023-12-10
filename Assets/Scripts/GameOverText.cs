using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverText : MonoBehaviour
{

    public GameManager gameManager;

    private Text text;

    void Start()
    {
        text = gameObject.GetComponent<Text>();
        text.enabled = false;
    }
    
    // Update is called once per frame
    void Update()
    {
        if (gameManager.gameState == "gameOver")
        {
            text.enabled = true;
        }
    }
}
