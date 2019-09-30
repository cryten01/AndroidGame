using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // External references

    // Internal references
    private Accelerometer2 _accelerometer2;
    private Rigidbody _rigidbody;

    // Params
    public float moveSpeed;
    public float xzRelation;

    // Private variables
    private Vector3 dir = Vector3.zero;
    private bool onGround = true;


    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _accelerometer2 = FindObjectOfType<Accelerometer2>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void FixedUpdate()
    {
        calculateDir();
        movePlayer();
        jump();
    }


    private void calculateDir()
    {
        // Determines the direction vector
        dir.x = _accelerometer2.xFilt * xzRelation;
        dir.z = 1 * (1 - xzRelation);

        if (dir.magnitude > 1)
        {
            dir.Normalize();
        }
    }

    public void movePlayer()
    {
        transform.position += transform.forward * 0.2f;
        transform.localRotation = Quaternion.Euler(0, _accelerometer2.xFilt * moveSpeed, 0);
    }

    private void jump()
    {
        if (Input.touchCount > 0)
        {
            // Gets the first recognized touch
            Touch touch = Input.GetTouch(0);

            // Checks if left side of the screen is touched
            if (touch.position.x <= 2280 / 2 && touch.position.y <= 1080 / 2)
            {

                if (onGround)
                {
                    float jumpspeed = 20.0f;

                    Debug.Log("Player jumps");
                    
                    // Adds constant force to the player
                    _rigidbody.AddForce(Vector3.up * jumpspeed, ForceMode.Impulse);
                    onGround = false;
                }
            }
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        onGround = true;
    }
}