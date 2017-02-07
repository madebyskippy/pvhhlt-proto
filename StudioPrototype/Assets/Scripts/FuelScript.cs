using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelScript : MonoBehaviour {
	public float fuel;
	public TextMesh fuelText;

	public KeyCode bellyInput;

	[SerializeField] GameObject manager;
	Manager managerScript;

	GameObject torso;
	FloatScript floatingRobot;

	void Start () {

		// Deplete fuel ever second
		InvokeRepeating ("FuelLoss", 1f, 1f);
		torso = GameObject.Find ("RoboTorso");
		floatingRobot = torso.GetComponent<FloatScript> ();

		managerScript = manager.GetComponent<Manager> ();
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

		if (Input.GetKeyDown(bellyInput)){
			//process food into fuel
			if (managerScript.getFood (0) > managerScript.getFood (1) && managerScript.getFood (0) > 0) {
				//if team 1 has more food than team 2, and it's more than 0 food
				managerScript.increaseFood(0,-1);
				managerScript.increaseScore (0, 1);
				fuel += 10;

			}else if (managerScript.getFood (1) > managerScript.getFood (0) && managerScript.getFood (1) > 0){
				//if team 2 has more food than team 1, and it's more than 0 food
				managerScript.increaseFood(1,-1);
				managerScript.increaseScore (1, 1);
				fuel += 10;
			}
		}
	}

	public void FuelLoss(){
		fuel--;
	}
}
