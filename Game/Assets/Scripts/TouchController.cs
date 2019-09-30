using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TouchController : MonoBehaviour
{
    // Blocks touch input
    private bool block = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            // Gets the first recognized touch
            Touch touch = Input.GetTouch(0);

//            Debug.Log("Touch pos on screen: x " + touch.position.x + " y " + touch.position.y);

            // Checks if touch is outside the UI area and not blocked
            if (touch.position.x > 350 && touch.position.y > 350 && !block)
            {
//                block = true;
//                StartCoroutine(jump());
            }
        }
    }
    

    private void FixedUpdate()
    {
        if (Input.touchCount > 0)
        {
            // Gets the first recognized touch
            Touch touch = Input.GetTouch(0);
            
            Rigidbody rb = GetComponent<Rigidbody>();
            
            

            
            if (touch.position.x <= 2280 / 2 && touch.position.y <= 1080 / 2)
            {
//                rb.AddForce(new Vector3(0,0,10));
            }
            else
            {
//                rb.velocity = new Vector3(0,0,0);
            }
        }
    }

    private IEnumerator jump()
    {
        Debug.Log("Player jumps");

        GetComponent<Rigidbody>().AddForce(0, 10, 0, ForceMode.Impulse);

        yield return new WaitForSeconds(1.0f);

        block = false;
    }

    private void strafe(Touch touch)
    {
        if (touch.position.x <= 2280 / 2 && touch.position.y <= 1080 / 2)
        {
            gameObject.GetComponent<Rigidbody>().velocity = new Vector3(-1.2f, 0, 0);
        }
        else
        {
            gameObject.GetComponent<Rigidbody>().velocity = new Vector3(1.2f, 0, 0);
        }
    }
}