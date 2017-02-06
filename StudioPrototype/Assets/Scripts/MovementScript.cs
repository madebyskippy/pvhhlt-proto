using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour {


	public float speed;

	public KeyCode moveLeft;
	public KeyCode moveRight;

	Rigidbody2D torso;


	// Use this for initialization
	void Start () {

		torso = GetComponent<Rigidbody2D> ();
	}

	// Update is called once per frame
	void Update () {

		if (Input.GetKey (moveRight)) {
			torso.AddForce (Vector3.right * speed * Time.deltaTime);		
		}

		if (Input.GetKey (moveLeft)) {
			torso.AddForce (Vector3.left * speed * Time.deltaTime);		
		}
	}

		
}
