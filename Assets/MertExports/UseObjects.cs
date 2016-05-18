using UnityEngine;
using System.Collections;

public class UseObjects : MonoBehaviour {
	/*RaycastHit hit;
	public GameObject doorright;
	public GameObject doorleft;
    */

	bool active=false;
	// Use this for initialization
	void Start () {



	}
	
	// Update is called once per frame
	void FixedUpdate () {


		if (!active) {

			transform.GetChild (0).gameObject.SetActive (false);
		
		
		
		}
		active = false;
		/*
		if(Physics.Raycast( transform.position, transform.right, out hit))
		{
//			Debug.Log (hit.collider.name);
			if (hit.collider.gameObject!= null) {
				//Debug.Log ("raycast fired");
				if (hit.collider.tag == "Lever") {
					Debug.Log ("interractable game object");
					if (Input.GetKeyDown (KeyCode.LeftAlt)) {
						Debug.Log ("door opened");
						hit.collider.GetComponent<Animator> ().SetTrigger ("playanim");
						doorright.GetComponent<opendoors> ().openit ();
						//doorleft.GetComponent<opendoors> ().openit ();
					}
				}

			}
		}
	*/}


	void OnTriggerStay(Collider other) {
		if (other.gameObject.tag == "Player") {
			active = true;
			transform.GetChild (0).gameObject.SetActive (true);
		}
	}

	/*void OnTriggerExit(Collider other) {
		transform.GetChild (0).gameObject.SetActive (false);
	}*/
}
