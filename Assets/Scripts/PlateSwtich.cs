using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateSwtich : MonoBehaviour
{
    public Light[] switchLights;

    public GameManager gameManager;

    public void OnTriggerEnter (Collider other)
    {
        if (!gameManager.plateState) return;

        foreach(Light light in switchLights)
        {
            light.enabled = !light.enabled;
        }
    }
}
