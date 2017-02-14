using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;


public class XPManager : MonoBehaviour {

	private const float EXP_INCREASE = 0.2f;
	private const float EXP_MAX = 1f;
	public Image expImage; 
	public UnityEvent OnLevelUp = new UnityEvent();
	//public Text expText;
	public float exp = 0f; 
	public bool isLevel2 = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (exp >= EXP_MAX) {
			OnLevelUp.Invoke ();
			exp = 0f;
			isLevel2 = true;
		}

		expImage.fillAmount = exp;

		//expText.text = exp.ToString ("###"); 
	}

	void ExpIncrease ()
	{
		exp += EXP_INCREASE;
	}
		
}
