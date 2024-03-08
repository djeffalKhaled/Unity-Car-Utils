using System.Collections;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float sensitivity = 1f, smoothTime = 0.1f;
    public Vector3 position;
    public GameObject playerFollower;
    public GameObject player; 
    public new Camera camera; 
    private Vector3 mousePrePos; 
    private Quaternion OGrotation;
    private Vector3 OGposition;
    private Vector3 velocity = Vector3.zero;
    private int cameraType = 0;
    // Start is called before the first frame update
    void Start()
    {
        position = transform.position;
        playerFollower.transform.position = position; 

        OGrotation = transform.rotation;
        OGposition = transform.position;
        cameraType = 0;
    }

    // Update is called once per frame

    
    void Update()
    {
         // checks camera type
        if (Input.GetKeyDown(KeyCode.C)) {
            cameraType++;
            if (cameraType > 1) {
                cameraType = 0;
            }
        }

        
        if (cameraType == 0) {
            // Fixed camera movement
            transform.position = playerFollower.transform.position;
        }
        else if (cameraType == 1) {
            // Smooth camera movement
            transform.position = Vector3.SmoothDamp(transform.position, playerFollower.transform.position, ref velocity, smoothTime);
        }

        transform.rotation = playerFollower.transform.rotation;

        // Mouse rotation
        if (Input.GetMouseButtonDown(1))
        {
            mousePrePos = camera.ScreenToViewportPoint(Input.mousePosition);
        }
        
        else if (Input.GetMouseButton(1))
        {
            Vector3 direction = mousePrePos - camera.ScreenToViewportPoint(Input.mousePosition);
            playerFollower.transform.RotateAround(player.transform.position, Vector3.up, direction.x * sensitivity);
        }
        /* Doesn't work for now
        if (Input.GetMouseButtonDown(1)) {
            OGrotation = transform.rotation;
            OGposition = transform.position;
        }
        if (Input.GetMouseButtonUp(1)) {
            StartCoroutine(BackToOGRotation());
        }*/

    }

    // Brings back the camera to its default position after 5 seconds
    IEnumerator BackToOGRotation() {
        yield return null;
        yield return new WaitForSeconds(1);
        playerFollower.transform.rotation = OGrotation;
        playerFollower.transform.position = OGposition;
    }
}
