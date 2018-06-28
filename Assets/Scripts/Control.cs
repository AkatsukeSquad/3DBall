using UnityEngine;
using System.Collections;


public class Control : MonoBehaviour
{

	
	public Transform ball;
	public GameObject bal;
	[SerializeField]
	public float speed = 10f;

	void OnMouseDrag()
	{
		Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		Debug.Log(Camera.main.ScreenToWorldPoint(Input.mousePosition));
		ball.position = new Vector3 (mousePos.x, ball.position.y, ball.position.z);
	}


	
	void Update () {
		
		transform.position = new Vector3 (25f,1f, bal.transform.position.z - 1f);
	}

	
}
