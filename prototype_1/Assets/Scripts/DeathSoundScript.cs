using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathSoundScript : MonoBehaviour {

	AudioSource deathSound;
	// Use this for initialization
	void Start () {
		deathSound = GetComponent<AudioSource> ();
	}

	void PlaySound(){
		deathSound.Play ();
	}
}
