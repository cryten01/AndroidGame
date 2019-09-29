using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // External References
    private GameManager GameManager;
    public GameObject Player;
    public GameObject Platform;

    public bool canFollow = true;

    private Vector3 offsetToBall; // the distance between the ball and the camera at rest
    private Vector3 offsetToPlatform; // the distance between the platform and the camera at rest

    // Start is called before the first frame update
    void Start()
    {
        GameManager = FindObjectOfType<GameManager>();
        offsetToBall = transform.position - Player.transform.position;
        offsetToPlatform = transform.position - Platform.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (canFollow)
        {
            if (GameManager.ballMode)
            {
                ballCam1();
            }
            else
            {
                ballCam2();
            }
        }
    }

    private void ballCam1()
    {
        Debug.Log("BallCam1 activated");
        // weights determines how much influence the player position has on each of the axis
        Vector3 temp = new Vector3(Player.transform.position.x * 0.3f, Player.transform.position.y * 0.6f,
            Player.transform.position.z * 0.3f);
        transform.position = temp + offsetToBall;
    }

    private void ballCam2()
    {
        Debug.Log("BallCam2 activated");
        transform.transform.position = Player.transform.position + offsetToBall;
//        transform.SetParent(Player.transform);
    }

    private void staticCam()
    {
        Debug.Log("PlatforCam activated");
        transform.rotation = Platform.transform.localRotation * Quaternion.Euler(90.0f, 0, 0);
        transform.position = Platform.transform.position + Platform.transform.up * 12.0f + new Vector3(0, 0);
    }
}