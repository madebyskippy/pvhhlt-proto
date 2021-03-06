﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodScript : MonoBehaviour {

	public int team; //0 or 1
	[SerializeField] Color color1;
	[SerializeField] Color color2;

	// Use this for initialization
	void Start () {
		if (gameObject.tag == "Respawn") {
			setTeam (team);
			Invoke ("killSelf", 5f);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void setTeam(int t){
		team = t;
		if (team == 0) {
			GetComponent<SpriteRenderer> ().color = color1;
		} else if (team == 1) {
			GetComponent<SpriteRenderer> ().color = color2;
		}
	}
		
	void killSelf(){
		Destroy (gameObject);
	}
}
