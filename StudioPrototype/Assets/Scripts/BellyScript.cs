using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BellyScript : MonoBehaviour {

	public GameObject foodinBelly;



	// Use this for initialization
	void Start () {

		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void MakeFoodinBelly(int team){
		// Gets info about food eaten and creates digestable food in belly

		Vector3 spawnPos = new Vector3 (transform.position.x,transform.position.y - 1f,0f);

//		Debug.Log ("Food Eaten");
		foodinBelly.GetComponent<FoodScript> ().setTeam (team);
		Instantiate (foodinBelly, spawnPos, Quaternion.identity) ;


	}






}
