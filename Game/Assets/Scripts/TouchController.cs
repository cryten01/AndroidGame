using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TouchController : MonoBehaviour
{
    public TextMeshProUGUI TouchCounts;
    public GameObject target;
    
    private bool block = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            // Gets the first recognized touch
            Touch touch = Input.GetTouch(0);
            
            Debug.Log("Touch pos on screen: x " + touch.position.x + " y " + touch.position.y);
            
            // Checks if touch is outside the UI area and not blocked
            if (touch.position.x > 350 && touch.position.y > 350 && !block)
            {
                block = true;
                TouchCounts.text = "Touch Counts: " + Input.touchCount;
//            target.transform.position = Vector3.Lerp(target.transform.position, new Vector3(0, 4, 0), Time.deltaTime);
                StartCoroutine(jump());
            }
        }
    }

    private IEnumerator jump()
    {
        Debug.Log("Player jumps");
        target.GetComponent<Rigidbody>().AddForce(0, 200, 0);
        yield return new WaitForSeconds(1.0f);
        block = false;
    }
}
