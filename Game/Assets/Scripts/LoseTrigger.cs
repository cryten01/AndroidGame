using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseTrigger : MonoBehaviour
{
    private bool isColliding = true;
    private float countdown = 0;

    private CameraController MainCamera;
    private GameManager GameManager;
    
    // Start is called before the first frame update
    void Start()
    {
        MainCamera = FindObjectOfType<CameraController>();
        GameManager = FindObjectOfType<GameManager>();
    }
    
    private void OnTriggerExit(Collider other)
    {
//        if (other.CompareTag("Player"))
//        {
//            isColliding = false;
//            Debug.Log("Player falls from Platform");
//            GameManager.GameOver();
//            MainCamera.canFollow = false;
//        }
    }
    
//    private void OnTriggerStay(Collider other)
//    {
//        if (!isColliding)
//        {
//            countdown += Time.deltaTime;
//            Debug.Log("Countdown " + countdown);
//
//            if (countdown > 2.0f)
//            {
//                GameManager.EndGame();
//            }
//        }
//    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player has fallen from Platform");
            GameManager.GameOver();
            MainCamera.canFollow = false;
        }
    }
}
