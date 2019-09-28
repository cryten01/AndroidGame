using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class Accelerometer : MonoBehaviour
{
    // References
    private GameManager GameManager;
    public GameObject platform;
    public TextMeshProUGUI accValues;
    
    // Public params
    public float moveSpeed = 50;
    
    // Filtered values of the accelerometer
    private float xFilt = 0.0f;
    private float yFilt = 0.0f;
    private float zFilt = 0.0f;
   
    private Rigidbody _rigidbody;

    private Vector3 defaultAcc;
       
    
    // For lerp test only
    private Vector3 newPosition = new Vector3(0, 0, 0);
    
    private float[] avgZ = new float[10];
    private int count = 0;
    


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
        lowPassFilter(Input.acceleration.x - defaultAcc.x, Input.acceleration.y - defaultAcc.y, Input.acceleration.z - defaultAcc.z, 0.2f);
    }

    private void FixedUpdate()
    {
        if (!GameManager.ballMode)
        {
            platform.transform.localRotation = Quaternion.Euler(-averaging(avgZ, Input.acceleration.z) * 40,0,-xFilt * moveSpeed);
        }
        else
        {
//            _rigidbody.AddForce(xFilt * moveSpeed, 0, yFilt * moveSpeed);
        }
    }


    private void lerpTest(GameObject target)
    {
        Vector3 posA = new Vector3(0, 0, 0);
        Vector3 posB = new Vector3(0, 4, 0);

        if (Input.GetKeyDown(KeyCode.I))
        {
            newPosition = posA;
            Debug.Log("I Pressed");
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            newPosition = posB;
        }

        target.transform.position = Vector3.Lerp(target.transform.position, newPosition, Time.deltaTime);
    }


    private float averaging(float[] input, float raw)
    {
        input[count] = raw;
       
        count++;
        
        if (count > input.Length - 1)
        {
            count = 0;
        }

        float totalAvg = 0;
        
        foreach (var avg in input)
        {
            totalAvg += avg;
        }

        totalAvg = totalAvg / avgZ.Length;

        return totalAvg;
    }

    private void lowPassFilter(float accX, float accY, float accz, float alpha)
    {
        // Flat (x,y needed)
        // Eyes (x,z needed)
        
        xFilt = alpha * accX + (1 - alpha) * xFilt;
        yFilt = alpha * accY + (1 - alpha) * yFilt;
        zFilt = alpha * accY + (1 - alpha) * zFilt;
        
        // Diplays current xFilt and yFilt on UI
//        accValues.text = "x: " + xFilt + " y: " + yFilt + " z: " + zFilt;
        accValues.text = "x: " + Input.acceleration.x + " y: " +  Input.acceleration.y + " z: " +  Input.acceleration.z;

    }
    
    // Calibrates default resting position of device
    public void calibrateDevicePos()
    {
        defaultAcc.x = Input.acceleration.x;
        defaultAcc.y = Input.acceleration.y;
        defaultAcc.z = Input.acceleration.z;
    }
}