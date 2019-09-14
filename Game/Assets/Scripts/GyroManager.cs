using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroManager : MonoBehaviour
{
    #region Instance
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
    #endregion

    private Gyroscope _gyro;
    private Quaternion _rotation;
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
            _rotation = _gyro.attitude;
        }
    }

    public Quaternion Rotation => _rotation;
}
