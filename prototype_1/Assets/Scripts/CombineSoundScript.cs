using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombineSoundScript : MonoBehaviour {

	AudioSource combineSound;
	// Use this for initialization
	void Start () {
		combineSound = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void PlaySound(){
		combineSound.Play ();
	}
}
