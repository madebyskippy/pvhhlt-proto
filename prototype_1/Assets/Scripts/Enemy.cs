using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour {
	

	GameObject head;
	public GameObject enemyManager;
	public float speed;
	// Use this for initialization
	Rigidbody2D rb;
	bool isGrounded;
	GameObject soundPlayer;

	void Start () {
		GameObject.Find ("XPManager");
		head = GameObject.Find ("Head");
		soundPlayer = GameObject.Find ("EnemyDeathSoundHolder");
		isGrounded = false;
		//enemyCtrl = GameObject.Find ("EnemyManager");
		rb = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (isGrounded) {
			transform.Translate (Vector2.right * speed * Time.deltaTime);
		}

	}

	void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.tag == "Foot" || coll.gameObject.tag == "Head") {
//			Destroy (coll.gameObject);	
			//SceneManager.LoadScene("game");
			//Application.LoadLevel (0);
		}

		if (coll.gameObject.tag == "Bullet") {
			//GameObject.Find("EnemyManager").SendMessage("SpawnEnemy");
			head.SendMessage ("ExpIncrease");
			soundPlayer.SendMessage ("PlaySound");
			Destroy (coll.gameObject);
			Destroy (gameObject);
		}

		//Vivi's original code that kills enemy upon landing
//		if (coll.gameObject.tag == "Wall") {
//			GameObject.Find("EnemyManager").SendMessage("SpawnEnemy");
//			Destroy (gameObject);
//		}

		//trying to move enemy.
		if (coll.gameObject.tag == "Wall") {
			Debug.Log ("Touched ground!");
			isGrounded = true; 
		}

		//kills the enemy when in contact with left or right walls
		if (coll.gameObject.name == "Wall_Left" || coll.gameObject.name == "Wall_Right") {
			speed *= -1f;
			//Destroy (gameObject);
		}
	}

	void Ultimate(){
		if(GameObject.Find("Head").GetComponent<XPManager>().isLevel2){
		soundPlayer.SendMessage ("PlaySound");
		head.SendMessage ("ExpIncrease");
		Destroy (gameObject);
		Debug.Log ("Player used ult!");
		}
	}


		
}

