using UnityEngine;
using UnityEngine.SceneManagement;

public class BallMove : MonoBehaviour
{
	public float ball_speed = 5f;
	public Rigidbody ball_rb;	
	public bool isGrounded = false;
    public bool Restart = false;
    public bool BackToMenu = false;
    public Camera main_camera;
    public Camera restart_camera;

    // Use this for initialization
    void Start ()
    {
        ball_rb = GetComponent <Rigidbody>();
        main_camera.enabled = true;
        restart_camera.enabled = false;
    }
	// Update is called once per frame
	

    void OnMouseUp()
    {
        if (Restart)
            ReloadLevel();
        if (BackToMenu)
            SceneManager.LoadScene(0);
    }

	void OnMouseDrag()
	{
		Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        ball_rb.position = Vector3.MoveTowards(ball_rb.position, new Vector3(mousePos.x, ball_rb.position.y, ball_rb.position.z), ball_speed * Time.deltaTime);        
    }

	public void Move()
	{
        ball_rb.AddForce ((Vector3.up + Vector3.forward) * 200f);
	}

	void Stop()
	{
        ball_rb.Sleep();
        ball_rb.WakeUp();
	}

	void OnCollisionEnter (Collision touch)
	{
		if (touch.gameObject.tag == "Ground")
		{
			isGrounded = true;
		}
		if(isGrounded)
		{
			Stop();
			Move();
		}

        if (touch.gameObject.tag == "Finish")
        {
            main_camera.enabled = false;
            restart_camera.enabled = true;
        }            

		if (touch.gameObject.tag == "NextLevel")
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}

	void ReloadLevel ()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        main_camera.enabled = true;
        restart_camera.enabled = false;
    }

	void GameOverMenu()
	{
		SceneManager.LoadScene(3);
	}
    
    

}
