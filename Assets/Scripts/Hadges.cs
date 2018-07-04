using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hadges : MonoBehaviour {

    public Rigidbody ball_rb;
    public bool isOnTheLeftWall = false;
    public bool isOnTheRightWall = false;
    public bool Platform = false;
    public float platformSpeed = 0.05f;

    // Use this for initialization
    void Start ()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (ball_rb.position.z > transform.position.z - 2.5 && ball_rb.position.z < transform.position.z + 2.5)
        {
            Vent();
        }
        if (Platform)
            PlatformMoving();      
    }

    void Vent()
    {
        if(isOnTheRightWall)
            ball_rb.MovePosition(ball_rb.position + Vector3.left * 1f * Time.deltaTime);
        if (isOnTheLeftWall)
            ball_rb.MovePosition(ball_rb.position + Vector3.right * 1f * Time.deltaTime);
    }

    void PlatformMoving()
    {
        if (transform.position.x > 3f)
            platformSpeed = -0.05f;
        if (transform.position.x < 1f)
            platformSpeed = 0.05f;
        transform.position = new Vector3(transform.position.x + platformSpeed, transform.position.y, transform.position.z);
    }
}
