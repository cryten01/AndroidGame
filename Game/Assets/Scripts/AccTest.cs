using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

/**
 * Responsible for processing accelerometer data
 */

public class AccTest : MonoBehaviour
{
    // References
    private GameManager GameManager;
    public TextMeshProUGUI accValues;
    public GameObject Camera;
    
    // Public params
    public float moveSpeed = 50;
    
    // Filtered values of the accelerometer
    public float xFilt = 0.0f;
    private float yFilt = 0.0f;
    private float zFilt = 0.0f;
   
    private Rigidbody _rigidbody;

    public Vector3 defaultAcc;


    private float lastX;
    public float relativeX;
    
    // For lerp test only
    private Vector3 newPosition = new Vector3(0, 0, 0);


    // Start is called before the first frame update
    void Start()
    {
        GameManager = FindObjectOfType<GameManager>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // Filters acceleration values for smoother movements
        // y change need because device is held flat
        // needs to remove default position
        lowPassFilter(Input.acceleration.x - defaultAcc.x, Input.acceleration.y - defaultAcc.y, Input.acceleration.z - defaultAcc.z, 0.2f);

        // Diplays current xFilt and yFilt on UI
        accValues.text = "x: " + xFilt + " y: " + yFilt + " z: " + Input.acceleration.z;


        moveBall();

    }

    private void FixedUpdate()
    {
        if (!GameManager.ballMode)
        {
//            platform.transform.localRotation = Quaternion.Euler(yFilt * moveSpeed, 0, -xFilt * moveSpeed);
//            Quaternion.Lerp(platform.transform.localRotation, Quaternion.Euler(yFilt, 0, -xFilt), Time.deltaTime);
//              platform.transform.localRotation = Quaternion.Euler(0,0,-xFilt * (2 + xFilt));              
//              Camera.transform.localRotation = Quaternion.Euler(0,0,-xFilt * 90);
//              platform.transform.localRotation = Quaternion.Euler(0,0,-xFilt * 10);
              
//             transform.position += new Vector3(xFilt * 0.6f,0,0);
//             transform.position = new Vector3(Mathf.Clamp(transform.position.x, -3.5f, +3.5f), transform.position.y, transform.position.z);

             
        }
        else
        {
            _rigidbody.AddForce(xFilt * moveSpeed, 0, yFilt * moveSpeed);
        }
    }

    private void lowPassFilter(float accX, float accY, float accZ, float alpha)
    {
        xFilt = alpha * accX + (1 - alpha) * xFilt;
        yFilt = alpha * accY + (1 - alpha) * yFilt;
        zFilt = alpha * accY + (1 - alpha) * zFilt;
    }

    private void moveBall()
    {
        transform.localRotation = Quaternion.Euler(0.0f, xFilt * 100, 0.0f);
        transform.position += transform.forward * 20.0f * Time.deltaTime;

//          _rigidbody.AddTorque(0,xFilt * 10.0f,0);
//        _rigidbody.AddForce(transform.forward * 10.0f);


//        float temp = transform.position.z + 10.0f * Time.deltaTime;
//        transform.position = new Vector3(transform.position.x, transform.position.y, temp);
    }
}