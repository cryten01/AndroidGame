using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

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
   
    private Rigidbody _rigidbody;
    
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
        lowPassFilter(Input.acceleration.x, Input.acceleration.y, 0.1f);

        // Debug: diplays current xFilt and yFilt on UI
        accValues.text = "x: " + xFilt + " z: " + yFilt;
    }

    private void FixedUpdate()
    {
        if (!GameManager.ballMode)
        {
            platform.transform.localRotation = Quaternion.Euler(yFilt * moveSpeed, 0, -xFilt * moveSpeed);
//            Quaternion.Lerp(platform.transform.localRotation, Quaternion.Euler(yFilt, 0, -xFilt), Time.deltaTime);
        }
        else
        {
            _rigidbody.AddForce(Input.acceleration.x * moveSpeed, 0, Input.acceleration.y * moveSpeed);
        }
        
        lerpTest(gameObject);
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

    private void lowPassFilter(float accX, float accY, float alpha)
    {
        xFilt = alpha * accX + (1 - alpha) * xFilt;
        yFilt = alpha * accY + (1 - alpha) * yFilt;
    }
}