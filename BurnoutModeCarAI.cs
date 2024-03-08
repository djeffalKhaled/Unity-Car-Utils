using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurnoutModeCarAI : MonoBehaviour
{
    public float speed;

    // Update is called once per frame
    void FixedUpdate()
    {
        // Move front
        Vector3 newPos = new Vector3(0, 0, speed * Time.deltaTime);
        transform.position += newPos;
    }
}
