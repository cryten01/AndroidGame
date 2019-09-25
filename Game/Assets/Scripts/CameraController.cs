using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset; // the distance between the player and the platform at rest
    
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        // determines how much influence the player position has on each of the axis
        Vector3 temp = new Vector3(player.transform.position.x * 0.3f, player.transform.position.y * 0.6f, player.transform.position.z * 0.3f);
        
        transform.position = temp + offset;
    }
}
