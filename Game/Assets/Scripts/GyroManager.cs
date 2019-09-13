using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroManager : MonoBehaviour
{
    private static GyroManager instance;

    public static GyroManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GyroManager>();

                if (instance == null)
                {
                    instance = new GameObject("Spawned Gyromanager", typeof(GyroManager)).GetComponent<GyroManager>();
                }
            }

            return instance;
        }
        set
        {
            instance = value;
        }
    }


    private Gyroscope _gyro;
    private Quaternion _gyroRotation;
    private bool gyroActive;

    public void enableGyro()
    {
        if (gyroActive)
        {
            return;
        }

        if (SystemInfo.supportsGyroscope)
        {
            _gyro = Input.gyro;
            _gyro.enabled = true;      
            gyroActive = _gyro.enabled;
        }
        else
        {
            Debug.Log("Gyro is not supported on this device");
        }
    }

    private void Update()
    {
        if (gyroActive)
        {
            _gyroRotation = _gyro.attitude;
//            Debug.Log("Rotation: " + _gyroRotation);
        }
    }

    public Quaternion GyroRotation => _gyroRotation;
}
