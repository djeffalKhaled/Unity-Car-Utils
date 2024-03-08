using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldSpawner : MonoBehaviour
{
    public GameObject[] terrains;
    public GameObject currentTerrain;
    public void Spawn() {
        // Takes the most recent terrain and adds 279.9907f to set it at the new at the correct pos
        Vector3 spawnPosition = currentTerrain.transform.position + new Vector3(0, 0, 279.9907f);
        GameObject newTerrain = Instantiate(terrains[0], spawnPosition, Quaternion.identity);
        newTerrain.GetComponentInChildren<SpawnCollider>().worldSpawner = this; 

        GameObject oldTerrain = currentTerrain;
        StartCoroutine(DestroyIfFar(newTerrain, oldTerrain));

        currentTerrain = newTerrain;
        Debug.Log("Spawned New Terrain");
    }

    IEnumerator DestroyIfFar(GameObject newTerrain, GameObject oldTerrain) {
        while (true) {
            yield return null;
            if (transform.position.z >= newTerrain.transform.position.z) {
                Destroy(oldTerrain);
                Debug.Log("Destroyed Old Terrain");
                yield break;
            }
        }
    }

    /*IEnumerator SlowlyDestroy(GameObject oldTerrain) {
        yield return new WaitForSeconds(10);
        Destroy(oldTerrain);
        Debug.Log("Destroyed Old Terrain");
    }*/
}
