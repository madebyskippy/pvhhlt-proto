using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour {
	[SerializeField] GameObject manager;
	Manager managerScript;

	public float speed;

	public KeyCode moveLeft;
	public KeyCode moveRight;
	public KeyCode squat;

	Rigidbody2D torso;

	int currentToilet; //-1 if not on a toilet

	// Use this for initialization
	void Start () {
		currentToilet = -1;
		torso = GetComponent<Rigidbody2D> ();
		managerScript = manager.GetComponent<Manager> ();
	}

	// Update is called once per frame
	void Update () {

		if (Input.GetKey (moveRight)) {
			torso.AddForce (Vector3.right * speed);	
		}			

		if (Input.GetKey (moveLeft)) {
			torso.AddForce (Vector3.left * speed);	

		}

		if (Input.GetKeyDown (squat)) {
			GetComponent<SpriteRenderer> ().color = Color.gray;
			if (currentToilet > -1 && managerScript.getWasteLevel()>0) {
				//you're squatting and on a toilet and have stuff in your system, poop
				managerScript.clearWaste();
				managerScript.increaseScore(currentToilet,2);

			}
		}if (Input.GetKeyUp (squat)) {
			GetComponent<SpriteRenderer> ().color = Color.white;
		}
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "toilet") {
			currentToilet = col.gameObject.GetComponent<ToiletScript> ().getTeam ();
		}
	}
	void OnTriggerExist2D(Collider2D col){
		if (col.gameObject.tag == "toilet") {
			currentToilet = -1;
		}
	}

		
}
