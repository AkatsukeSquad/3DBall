using UnityEngine;

public class TouchScreen : MonoBehaviour
{
	public GameObject ball_gameObj;
	public Rigidbody ball_rb;
    public bool Right = false;
    public bool Left = false;

    // Use this for initialization
    void Start() { }
	
	// Update is called once per frame
	void Update ()
    {
        if (Left)
            transform.position = new Vector3 (1f,2f, ball_gameObj.transform.position.z - 1f);
        if (Right)
            transform.position = new Vector3(3f, 2f, ball_gameObj.transform.position.z - 1f);
    }

	  void OnMouseDrag()
    {        
        if (ball_rb.position.x > 0.5 && ball_rb.position.x < 3.5)
        {
            if(Left)
                ball_rb.MovePosition(ball_rb.position + Vector3.left * 3f * Time.deltaTime);
            if(Right)
                ball_rb.MovePosition(ball_rb.position + Vector3.right * 3f * Time.deltaTime);
        }

        else if (ball_rb.position.x <= 0.5)
            ball_rb.AddForce(Vector3.right * 1f);

        else if (ball_rb.position.x >= 3.5)
            ball_rb.AddForce(Vector3.left * 1f);
    }
}

