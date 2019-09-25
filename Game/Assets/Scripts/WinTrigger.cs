using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinTrigger : MonoBehaviour
{
    private GameManager GameManager;
    private bool isColliding = false;
    private float countdown = 0;
    
    
    // Start is called before the first frame update
    void Start()
    {
        GameManager = FindObjectOfType<GameManager>();
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isColliding = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (isColliding)
        {
            countdown += Time.deltaTime;
            Debug.Log("Countdown " + countdown);

            if (countdown > 2.0f)
            {
                GameManager.CompleteLevel();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isColliding = false;
            countdown = 0;
        }
    }
}
