using UnityEngine;

public class TouchScreen : MonoBehaviour
{
    public Ball ball = new Ball();
	public GameObject ball_gameObj;
    public Transform energy_capsule;
	public Rigidbody ball_rb;
    
    float clicked = 0;
    float clicktime = 0;
    float clickdelay = 0.5f;

    // Use this for initialization
    void Start()
    {
        ball.TimerStart();
    }
	
	// Update is called once per frame
	void Update ()
    {
        transform.position = new Vector3 (2f,2f, ball_gameObj.transform.position.z - 1f);
        energy_capsule.position = new Vector3(2f, 2.2f, ball_gameObj.transform.position.z - 1f);
        energy_capsule.localScale = new Vector3(0.05f, 1.25f * (ball.Energy / ball.MaxEnergy), 0.05f);            
    }

	void OnMouseDrag()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 1.0f;
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);
        if (ball_rb.position.x > 0.5 && ball_rb.position.x < 3.5)
        {
            if(worldPos.x < transform.localScale.x / 2)
                ball_rb.MovePosition(ball_rb.position + Vector3.left * 3f * Time.deltaTime);
            if(worldPos.x > transform.localScale.x / 2)
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
            ball.Energy = 50;
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

