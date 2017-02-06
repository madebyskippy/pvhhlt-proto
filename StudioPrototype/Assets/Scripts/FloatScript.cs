using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatScript : MonoBehaviour {

	public float floatStrength;
	public float counterForceTop;
	public float counterForceBottom;

	public float topOfScreen;
	public float bottomOfScreen;

	Rigidbody2D rb;

	void Start(){
		rb = GetComponent<Rigidbody2D> ();
		
	}

	void FixedUpdate () {


		if (transform.position.y >= topOfScreen) {
			rb.AddForce (Vector3.up * floatStrength * counterForceTop);
		} else if (transform.position.y <= bottomOfScreen) {
			rb.AddForce (Vector3.up * floatStrength * counterForceBottom);
		} else {
			rb.AddForce(Vector3.up * floatStrength);
		}
	}
}
