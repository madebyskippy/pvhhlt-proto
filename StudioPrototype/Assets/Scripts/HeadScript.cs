using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadScript : MonoBehaviour {

	[SerializeField] float rotationSpeed;
	[SerializeField] Sprite mouthOpen;
	[SerializeField] Sprite mouthClosed;

	[SerializeField] GameObject manager;

	SpriteRenderer sr;
	Collider2D col;

	// Use this for initialization
	void Start () {
		sr = GetComponent<SpriteRenderer> ();
		col = GetComponent<Collider2D> ();
		openMouth ();
		//closeMouth();
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 rawMouse = Input.mousePosition;
		rawMouse.z = 10.0f;
		Vector3 mouseStuff = Camera.main.ScreenToWorldPoint (rawMouse);
		float AngleRad = Mathf.Atan2(1, mouseStuff.x - transform.position.x);
		Debug.Log (mouseStuff.x + ", " + transform.position.x);
		float AngleDeg = AngleRad * Mathf.Rad2Deg;
		this.transform.rotation = Quaternion.Euler(0, 0, AngleDeg-90);

		if (Input.GetMouseButtonDown (0)) {
			openMouth ();
		}
		if (Input.GetMouseButtonUp (0)) {
			closeMouth ();
		}
	}

	void openMouth(){
		sr.sprite = mouthOpen;
		col.enabled = true;
	}
	void closeMouth(){
		sr.sprite = mouthClosed;
		col.enabled = false;
	}

	void OnTriggerEnter2D(Collider2D col){
//		Debug.Log ("hit");
		if (col.gameObject.tag == "Respawn") {
			int team = 0;
			if (col.gameObject.tag == "Team1")
				team = 0;
			else if (col.gameObject.tag == "Team2")
				team = 1;
			manager.GetComponent<Manager> ().increaseFood (team, 1); //increase food of the team
			manager.GetComponent<Manager> ().increaseScore (team, 2); //increase score of the team by 2
			Destroy (col.gameObject);
		}
	}
}
