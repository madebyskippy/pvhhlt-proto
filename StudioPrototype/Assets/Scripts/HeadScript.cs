using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadScript : MonoBehaviour {

	[SerializeField] float rotationSpeed;
	[SerializeField] Sprite mouthOpen;
	[SerializeField] Sprite mouthClosed;

	SpriteRenderer sr;
	Collider2D col;

	// Use this for initialization
	void Start () {
		sr = GetComponent<SpriteRenderer> ();
		col = GetComponent<Collider2D> ();
		col.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		float AngleRad = Mathf.Atan2(Input.mousePosition.y - transform.position.y, Input.mousePosition.x - transform.position.x);
		float AngleDeg = AngleRad * Mathf.Rad2Deg;
//		this.transform.rotation = Quaternion.Euler(0, 0, AngleDeg);
		//WHY WON'T THIS ROTATION WORK CORRECTLY
		//extra note: i did not try super hard to get it to work correctly. i will ask around later

		if (Input.GetMouseButtonDown (0)) {
			sr.sprite = mouthOpen;
			col.enabled = true;
		}
		if (Input.GetMouseButtonUp (0)) {
			sr.sprite = mouthClosed;
			col.enabled = false;
		}
	}

	void OnTriggerEnter2D(Collider2D col){
		Debug.Log ("hit");
		int team;
		if (col.gameObject.tag == "Team1")
			team = 0;
		else if (col.gameObject.tag == "Team2")
			team = 1;
	}
}
