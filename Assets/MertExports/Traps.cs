using UnityEngine;
using System.Collections;

public class Traps : MonoBehaviour {
	public GameObject player;
	public Vector3 playerFirstPos;
	public GameObject DeadMenu;
	public GameObject ControlMenu;
	public GameObject Timer;
	public CameraMovement CM;
	// Use this for initialization
	void Start () {
		CM = Camera.main.GetComponent<CameraMovement> ();
		player = GameObject.FindGameObjectWithTag ("Player");
		playerFirstPos = player.transform.position;
		DeadMenu = GameObject.FindGameObjectWithTag ("DeadMenu");
		ControlMenu = GameObject.FindGameObjectWithTag ("ControlMenu");
		Timer = GameObject.FindGameObjectWithTag ("Timer");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider other) {
		if(!CM.changing){

			other.transform.GetComponent<UnitPlayer> ().Die ();
			other.transform.GetComponent<UnitPlayer> ().enabled = false;
			other.transform.FindChild ("alien character").GetComponent<Animator> ().SetBool ("Die",true);
		StartCoroutine (ToStart ());
		//Time.timeScale = 0;
		}

		}




	IEnumerator ToStart()
	{
		yield return new WaitForSeconds (4f);

		for (int i = 0; i < DeadMenu.transform.childCount; i++) {
		
			DeadMenu.transform.GetChild (i).gameObject.SetActive (true);

		
		}
		for (int i = 0; i < Timer.transform.childCount; i++) {

			Timer.transform.GetChild (i).gameObject.SetActive (false);


		}
		for (int i = 0; i < ControlMenu.transform.childCount; i++) {

			ControlMenu.transform.GetChild (i).gameObject.SetActive (false);


		}

		/*player.transform.position = playerFirstPos;
		player.transform.GetComponent<UnitPlayer> ().enabled = true;
		player.transform.GetComponent<Animator> ().SetBool ("Walking", false);*/


	}
}
