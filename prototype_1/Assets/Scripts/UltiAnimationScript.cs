using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UltiAnimationScript : MonoBehaviour {

	public float animDuration = 1f;
	// Use this for initialization
	void Start () {
			}
	
	// Update is called once per frame
	void Update () {
		
	}

	void DelayedStop(){
		Invoke ("StopAnimation", animDuration);
	}

	void StopAnimation(){
		gameObject.SetActive (false);
	}
		



}

