using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour {
	//this script will keep track of score, and also spawn food, etc
	public GameObject foodPrefab;
	[SerializeField] GameObject robotRHand;
	[SerializeField] GameObject robotLHand;

	int[] score;

	//for spawning food
	float spawnChance = 0.01f; //chance it'll spawn on a frame
	bool[] hasFood;

	// Use this for initialization
	void Start () {
		score = new int[2]; //2 teams
		hasFood = new bool[2]; //2 teams
		for (int i=0; i<2; i++){
			score[i]=0;
			hasFood[i]=false;
		}
	}
	
	// Update is called once per frame
	void Update () {
		//check if food in hands
//		if (robotRHand.transform.childCount > 0)
//			hasFood [0] = true;
//		else
//			hasFood [0] = false;
//		if (robotLHand.transform.childCount > 0)
//			hasFood [1] = true;
//		else
//			hasFood [1] = false;
		

		//spawn food stuff
		float probability = Random.Range (0f, 1f);
		if (probability < spawnChance) {
			//spawn a food
			int randomTeam = Random.Range(0,2); //will generate random int between 0-2, aka, will generate either 0 or 1.
			if (!hasFood [randomTeam]) {
				hasFood [randomTeam] = true;
				GameObject food = Instantiate (foodPrefab) as GameObject;
				//the position im using in the above statement was determined trial and error
				//it just puts the food at the end of the forarm
				if (randomTeam == 0) {
					food.transform.SetParent (robotRHand.transform,false);
				} else {
					food.transform.SetParent (robotLHand.transform,false);
				}
				food.GetComponent<FoodScript> ().setTeam (Random.Range (0, 2));
			}
		}
	}
}
