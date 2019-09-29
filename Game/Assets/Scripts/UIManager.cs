using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI accValues;
    public TextMeshProUGUI touchCounts;

    public Accelerometer2 accelerometer;

    // Start is called before the first frame update
    void Start()
    {
        accelerometer = FindObjectOfType<Accelerometer2>();
    }

    // Update is called once per frame
    void Update()
    {
        // Diplays current xFilt and yFilt on UI
        accValues.text = "x: " + accelerometer.xFilt + " y: " + accelerometer.yFilt + " z: " + Input.acceleration.z;

        touchCounts.text = "Touch Counts: " + Input.touchCount;
    }
}