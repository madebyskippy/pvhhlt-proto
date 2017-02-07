using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelScript : MonoBehaviour {
	public float fuel;
	public TextMesh fuelText;

	GameObject torso;
	FloatScript floatingRobot;

	void Start () {

		// Deplete fuel ever second
		InvokeRepeating ("FuelLoss", 1f, 1f);
		torso = GameObject.Find ("RoboTorso");
		floatingRobot = torso.GetComponent<FloatScript> ();
	}

	void Update () {
		
//		Debug.Log ("Fuel: " + fuel);
//		Debug.Log ("Fuel Strength: " + floatingRobot.floatStrength);

		// Display Fuel Text
		if (fuel >= 0) {
			fuelText.text = "Fuel: " + fuel.ToString ();
		} else {
			fuelText.text = "Fuel: 0";
		}


		if (fuel == 0) {
			floatingRobot.floatStrength = 0;
		}
	}

	public void FuelLoss(){
		fuel--;
	}
}
