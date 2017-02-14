using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextHide : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void DelayedHideText(){
		Invoke ("Hide", 2.5f);
		Debug.Log ("I was called!");
	}

	void Hide(){
		gameObject.SetActive (false);
	}
}
