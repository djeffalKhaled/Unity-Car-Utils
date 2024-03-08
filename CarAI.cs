using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CarAI : MonoBehaviour
{
    public Collider leftCollider, rightCollider, backCollider, frontCollider;
    public float speed;
    private float[] positions = new float[4];
    private bool isDiving;
    // Start is called before the first frame update
    void Start()
    {
        isDiving = false;
        SetPositions();
        StartCoroutine(ChoosePosition());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Move front
        Vector3 newPos = new Vector3(0, 0, speed * Time.deltaTime);
        transform.position += newPos;
    }

    IEnumerator ChoosePosition() {
        while (true) {
            yield return null;
            yield return new WaitForSeconds(10);
            // Choose randomaly either diving right or left
            int randomIndex = UnityEngine.Random.Range(0, 2); // 0 for right 1 for left
            if (isDiving != true) {
                switch (randomIndex) {
                    case 0: 
                        DiveRight();
                        break;
                    case 1:
                        DiveLeft();
                        break;
                }
            }
            
        }
    }
    void DiveRight() {
        Debug.Log("Checking diving right posibility...");
        // if it's not in the farthest right position
        if (transform.position.x < positions[3]) {

            int currentPosition = GetCurrentPosition();
            int randomIndex = currentPosition + 1;

            Debug.Log("Diving right to position: " + randomIndex);
            isDiving = true;
            StartCoroutine(slowlyDiveRight(randomIndex));
        }
        else {
            Debug.Log("Cannot dive right, will dive left");
            DiveLeft();
        }
    }

    IEnumerator slowlyDiveRight(int index) {
        
        while (true) {
            yield return null;
            if (transform.position.x < positions[index]) {
                Vector3 changeLane = new Vector3(1f * Time.deltaTime, 0, 0);
                transform.position += changeLane;
            }
            if(transform.position.x >= positions[index]) {
                Debug.Log("Finished diving right to position " + index);
                isDiving = false;
                yield break;
            }
        }
    }

    void DiveLeft() {
        Debug.Log("Checking diving left posibility...");
        // if it's not in the farthest left position
        if (transform.position.x > positions[0]) {

            int currentPosition = GetCurrentPosition();
            int randomIndex = currentPosition - 1;

            Debug.Log("Diving left to position: " + randomIndex);
            isDiving = true;
            StartCoroutine(slowlyDiveLeft(randomIndex));
        }
        else {
            Debug.Log("Cannot dive left, will dive right");
            DiveRight();
        }
    }

    IEnumerator slowlyDiveLeft(int index) {
        
        while (true) {
            yield return null;
            if (transform.position.x > positions[index]) {
                Vector3 changeLane = new Vector3(1f * Time.deltaTime, 0, 0);
                transform.position -= changeLane;
            }
            if(transform.position.x <= positions[index]) {
                Debug.Log("Finished diving left to position " + index);
                isDiving = false;
                yield break;
            }
        }
    }

    void chooseRandomLeftLane() {
        // For now disabled, add it at line 87 to randomally choose left lanes
        // choose a random lane and dive left to get there
        int randomIndex = UnityEngine.Random.Range(0, positions.Length);
        while (positions[randomIndex] > transform.position.x) {
            // Reroll as long as lower than the current position
            randomIndex = UnityEngine.Random.Range(0, positions.Length);
        }
    }
    void chooseRandomRightLane() {
        // For now disabled, add it at line 51 to randomally choose right lanes
        // choose a random lane and dive right to get there
        int randomIndex = UnityEngine.Random.Range(0, positions.Length);
        while (positions[randomIndex] < transform.position.x) {
            // Reroll as long as higher than the current position
            randomIndex = UnityEngine.Random.Range(0, positions.Length);
        }
    }

    void SetPositions() {
        // sets the possible x axis positions to change the lanes
        float sum = 62.5f;
        for (int i = 0; i < positions.Length; i++) {
            positions[i] = sum;
            sum += 5;
        }
    }

    private int GetCurrentPosition() {
        Debug.Log("Getting current position...");
        float tolerance = 3f;
        for (int i = 0; i < positions.Length; i++) {
            if (Mathf.Abs(transform.position.x - positions[i]) < tolerance) {
                return i;
            }
        }
        Debug.Log("Cannot get current position!");
        return -1;
    }
}
