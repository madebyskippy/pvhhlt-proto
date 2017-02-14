using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UltiSoundScript : MonoBehaviour {
	AudioSource ultiSound;
	// Use this for initialization
	void Start () {
		ultiSound = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void PlaySound(){
		ultiSound.Play ();
	}
}
