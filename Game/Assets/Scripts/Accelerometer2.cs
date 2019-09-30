using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

/**
 * Responsible for processing accelerometer data
 */

public class Accelerometer2 : MonoBehaviour
{
    // External References
    private GameManager GameManager;
    private Rigidbody rigidbody;
    private GameObject MainCamera;

    // Public params
    public float moveSpeed = 50;
    public GameObject BallContainer;
    
    // Filtered values of the accelerometer
    public float xFilt = 0.0f;
    public float yFilt = 0.0f;
    public float zFilt = 0.0f;


    // Start is called before the first frame update
    void Start()
    {
        GameManager = FindObjectOfType<GameManager>();
        MainCamera = GameObject.Find("Main Camera");
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // Filters acceleration values for smoother movements
        lowPassFilter(Input.acceleration.x, Input.acceleration.y, Input.acceleration.z, 0.2f);
    }

    private void FixedUpdate()
    {
//        rigidbody.AddForce(xFilt,0,0);
    }

    private void lowPassFilter(float accX, float accY, float accZ, float alpha)
    {
        xFilt = alpha * accX + (1 - alpha) * xFilt;
        yFilt = alpha * accY + (1 - alpha) * yFilt;
        zFilt = alpha * accY + (1 - alpha) * zFilt;
    }

    private void moveBall()
    {
        transform.localRotation *= Quaternion.Euler(0.0f, xFilt * 10.0f, 0.0f);
        transform.position += transform.forward * 50.0f * Time.deltaTime;
    }

    private void moveCam()
    {
        MainCamera.transform.localRotation = Quaternion.Euler(0,0,xFilt * -40);
    }
}