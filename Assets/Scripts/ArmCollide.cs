using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmCollide : MonoBehaviour
{
    public GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision col) {
        if (col.gameObject.name == "correctDoll") {
            Debug.Log("collison");
            gameManager.cluesFound += 1;
            Destroy(col.gameObject);
            Destroy(gameObject);
            // Debug.Log(gameManager.cluesFound);

        }

    }
}
