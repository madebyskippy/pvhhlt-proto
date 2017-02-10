using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour {
	//this script will keep track of score, and also spawn food, etc
	public GameObject foodPrefab;
	[SerializeField] GameObject belly;
	[SerializeField] GameObject robotRHand;
	[SerializeField] GameObject robotLHand;

	[SerializeField] TextMesh foodUI;
	[SerializeField] TextMesh scoreUI;
	[SerializeField] TextMesh wasteUI;

	//team stats
	int[] score;

	//for spawning food
	float spawnChance = 0.01f; //chance it'll spawn on a frame
	bool[] hasFood;

	//robo stats
	int[] foodCount; //food count of each team
	int wasteLevel;


	// Use this for initialization
	void Start () {
		//initialize and zero everything. empty robot
		score = new int[2]; //2 teams
		hasFood = new bool[2]; //2 teams
		foodCount = new int[2];
		wasteLevel = 0;
		for (int i=0; i<2; i++){
			score[i]=0;
			foodCount [i] = 0;
			hasFood[i]=false;
		}
	}
	
	// Update is called once per frame
	void Update () {
		//check if food in hands
		if (robotRHand.transform.childCount > 0)
			hasFood [0] = true;
		else
			hasFood [0] = false;
		if (robotLHand.transform.childCount > 0)
			hasFood [1] = true;
		else
			hasFood [1] = false;
		

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

	public void increaseFood(int team, int val){
		foodCount [team] += val;
		belly.GetComponent<BellyScript>().MakeFoodinBelly(team); //Spawn a food in the belly
		foodUI.text = "food count\nteam 1: " + foodCount [0] + "\nteam 2: " + foodCount [1];
	}

	public void increaseScore(int team, int val){
		score [team] += val;
		scoreUI.text = "score\nteam 1: " + score [0] + "\nteam 2: " + score [1];
	}

	public int getFood(int team){
		return foodCount [team];
	}

	public int getWasteLevel(){
		return wasteLevel;
	}

	public void incrementWaste(){
		wasteLevel++;
		wasteUI.text = "waste level: " + wasteLevel;
	}

	public void decrementWaste(){
		wasteLevel--;
		wasteUI.text = "waste level: " + wasteLevel;
	}

	public void clearWaste(){
		wasteLevel = 0;
		wasteUI.text = "waste level: " + wasteLevel;
	}
}
