using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	
	public Vector3 move=Vector3.zero;
	public float gravity=20f;
	protected CharacterController control;
	public GameObject player;
	public Vector3 playerFirstPos;
	public GameObject DeadMenu;
	public GameObject ControlMenu;
	public GameObject Timer;
	// Use this for initialization
	void Start () {
		control =GetComponent<CharacterController>();
		player = GameObject.FindGameObjectWithTag ("Player");
		playerFirstPos = player.transform.position;
		DeadMenu = GameObject.FindGameObjectWithTag ("DeadMenu");
		ControlMenu = GameObject.FindGameObjectWithTag ("ControlMenu");
		Timer = GameObject.FindGameObjectWithTag ("Timer");
	}
	
	// Update is called once per frame
	void Update () {
	
		//MoveEnemy ();
		//control.Move (move * Time.deltaTime);


	}

	void MoveEnemy(){

		//move.y -= gravity * Time.deltaTime;

	}
	void OnTriggerEnter(Collider other) {
		if (other.tag == "Projectile") {
			gameObject.GetComponent<Animator> ().SetTrigger ("killed");
			Destroy (other.gameObject);
			//Destroy (gameObject);


		
		} else if (other.tag == "Player") {
		
			other.transform.GetComponent<UnitPlayer> ().Die ();
			other.transform.GetComponent<UnitPlayer> ().enabled = false;
			other.transform.FindChild ("alien character").GetComponent<Animator> ().SetBool ("Die",true);
			StartCoroutine (ToStart ());
		
		}
	
	
	}

	IEnumerator ToStart()
	{

		yield return new WaitForSeconds (0.5f);
		for (int i = 0; i < DeadMenu.transform.childCount; i++) {

			DeadMenu.transform.GetChild (i).gameObject.SetActive (true);


		}
		for (int i = 0; i < Timer.transform.childCount; i++) {

			Timer.transform.GetChild (i).gameObject.SetActive (false);


		}
		for (int i = 0; i < ControlMenu.transform.childCount; i++) {

			ControlMenu.transform.GetChild (i).gameObject.SetActive (false);


		}




	}




}
