using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatScript : MonoBehaviour {

	public float floatStrength;

	public float topOfScreen;
	public float bottomOfScreen;

	Rigidbody2D rb;

	void Start(){
		rb = GetComponent<Rigidbody2D> ();
		
	}


	void Update () {


		if (transform.position.y >= topOfScreen) {
			rb.AddForce (Vector3.up * floatStrength * 0.6f);
		} else if (transform.position.y <= bottomOfScreen) {
			rb.AddForce (Vector3.up * floatStrength * 1.4f);
		} else {
			rb.AddForce(Vector3.up * floatStrength);
		}
	}
}
