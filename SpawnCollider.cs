using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SpawnCollider : MonoBehaviour
{
    public WorldSpawner worldSpawner;
    void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Car"))
        {
            worldSpawner.Spawn();
        }
    }
}
