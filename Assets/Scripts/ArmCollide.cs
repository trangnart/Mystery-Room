using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmCollide : MonoBehaviour
{
    public string targetLayer = "Mannequin";
    public GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.layer == LayerMask.NameToLayer(targetLayer))
        {
            Debug.Log("Collided with object on the '" + targetLayer + "' layer");
            gameManager.TriggerDeath();
            // Optionally, you might want to destroy the arm or perform other actions here.
            Destroy(col.gameObject);
        }
        else if (col.gameObject.name == "correctDoll")
        {
            Debug.Log("Collided with 'correctDoll'");
            gameManager.cluesFound += 1;
            Destroy(col.gameObject);
            Destroy(gameObject);
        }
    }
}
