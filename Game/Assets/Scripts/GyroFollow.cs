using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

public class GyroFollow : MonoBehaviour
{
    public Quaternion baseRotation = new Quaternion(0, 0, -1, 0);

    // Start is called before the first frame update
    void Start()
    {
        GyroManager.Instance.enableGyro();
    }

    // Update is called once per frame
    void Update()
    {
//        transform.localRotation = GyroManager.Instance.Rotation * baseRotation;

        Vector3 rotation = GyroManager.Instance.Rotation.eulerAngles;
        
        transform.localRotation = Quaternion.Euler(rotation.x, rotation.z, -rotation.y);

    }
}