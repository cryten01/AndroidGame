using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // References
    private GameManager GameManager;  
    public GameObject Player;
    public GameObject Platform;

    public bool canFollow = true;

    private Vector3 offset; // the distance between the player and the platform at rest
    private Vector3 offsetToPlatform;
    
    // Start is called before the first frame update
    void Start()
    {
        GameManager = FindObjectOfType<GameManager>();
        offset = transform.position - Player.transform.position;
        offsetToPlatform = transform.position - Platform.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (canFollow)
        {
            if (GameManager.ballMode)
            {       
                followCam();
            }
            else
            {
//                staticCam();
            }
        }
    }

    private void followCam()
    {
        Debug.Log("Cam Ball mode");
        // determines how much influence the player position has on each of the axis
        Vector3 temp = new Vector3(Player.transform.position.x * 0.3f, Player.transform.position.y * 0.6f,Player.transform.position.z * 0.3f);            
        transform.position = temp + offset;
    }

    private void staticCam()
    {
        Debug.Log("Cam Platform mode");
        transform.rotation = Platform.transform.localRotation * Quaternion.Euler(90.0f,0,0);
        transform.position = Platform.transform.position + Platform.transform.up * 12.0f + new Vector3(0,0);
    }
    
    
}
