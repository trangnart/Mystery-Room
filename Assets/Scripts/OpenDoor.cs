using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public GameObject door;
    public string layer;
    public GameManager gameManager;
    private bool state = false;

    public void OnTriggerEnter (Collider other)
    {
        Debug.Log("here");
        if (state || other.gameObject.layer != LayerMask.NameToLayer(layer)) return;
        door.transform.position += new Vector3(0, 3, 0);
        state = true;
        gameManager.cluesFound += 1;
    }
}
