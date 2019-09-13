using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroFollow : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
     GyroManager.Instance.enableGyro();   
    }

    // Update is called once per frame
    void Update()
    {
        transform.localRotation = GyroManager.Instance.GyroRotation * new Quaternion(0, 0, 1, 0);
    }
}
