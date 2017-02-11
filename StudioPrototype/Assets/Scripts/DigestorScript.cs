using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DigestorScript : MonoBehaviour {

	[SerializeField] GameObject prefab;
	[SerializeField] GameObject manager;

	[SerializeField] Color color1;

	public KeyCode digest;
	public Collider2D col;

	SpriteRenderer sr;


	// Use this for initialization
	void Awake () {
		sr = GetComponent<SpriteRenderer> ();
		sr.color = Color.black;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (digest)) {
			//Digestor only works when Waste level is greater than zero, depletes waste level when pressed
			if (manager.GetComponent<Manager> ().getWasteLevel () > 0) {				
				manager.GetComponent<Manager> ().decrementWaste (); // Reduce waste level 
				sr.color = color1;
				col.enabled = true;
			} else {
				sr.color = Color.black;
				col.enabled = false;
			}

		}
		else{
			sr.color = Color.black;
			col.enabled = false;
		}

	}

	public void OnTriggerEnter2D(Collider2D col){
		//		Debug.Log ("hit");

			
			
			if (col.gameObject.tag == "BellyFood") {
				int team = col.gameObject.GetComponent<FoodScript> ().team;

				manager.GetComponent<Manager> ().increaseScore (team, 1); //increase score of the team by 1
				Destroy (col.gameObject);
			}
	}
}
