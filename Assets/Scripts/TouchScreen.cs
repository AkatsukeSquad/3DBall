using UnityEngine;

public class TouchScreen : MonoBehaviour
{
	public GameObject ball_gameObj;
	public Rigidbody ball_rb;
    public bool Right = false;
    public bool Left = false;
    
    float clicked = 0;
    float clicktime = 0;
    float clickdelay = 0.5f;

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

    void OnMouseDown()
    {
        if (DoubleClick())
        {
            Physics.gravity = new Vector3(0, 0, 0);
        }
    }

    bool DoubleClick()
    {        
        if (Input.GetMouseButton(0))
        {
            clicked++;
            if (clicked == 1) clicktime = Time.time;
        }
        if (clicked > 1 && Time.time - clicktime < clickdelay)
        {
            clicked = 0;
            clicktime = 0;
            return true;
        }
        else if (clicked > 2 || Time.time - clicktime > 1) clicked = 0;
        return false;
    }
}

