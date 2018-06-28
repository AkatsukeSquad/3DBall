using UnityEngine;
using System.Collections;

public class LeftCube : MonoBehaviour {


	public GameObject ball;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		transform.position = new Vector3 (24f,1f, ball.transform.position.z - 1f);
	}
}
