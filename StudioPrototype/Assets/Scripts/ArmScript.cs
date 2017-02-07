using UnityEngine;
using System.Collections;

public class ArmScript: MonoBehaviour {

	[SerializeField]
	float rotationSpeed;

	public KeyCode topPartInput;
	public KeyCode bottomPartInput;

	[SerializeField]
	GameObject ArmTop;
	GameObject ArmBottom;

	Rigidbody2D rbTop;
	Rigidbody2D rbBottom;


	// Use this for initialization
	void Start () {
		
		rbTop = ArmTop.GetComponent<Rigidbody2D> ();
		rbBottom = ArmBottom.GetComponent<Rigidbody2D> ();
	}

	// Update is called once per frame
	void Update () {

		if (transform.tag == "Team2"){
			MoveArms (1);
		}

		if (transform.tag == "Team1"){
			MoveArms (-1);
		}


//		if (Input.GetButton ("Hold")) 
//		{
//			rb.freezeRotation = true;
//		} 
//		else 
//		{
//			rb.freezeRotation = false;
//		}
	}
		

	void MoveArms(int dir){
		if (Input.GetKey(topPartInput)){
			rbTop.angularVelocity = rotationSpeed*60*dir; 
		}

		if (Input.GetKey(bottomPartInput)){
			rbBottom.angularVelocity = rotationSpeed*60*dir; 
		}
	}
}
