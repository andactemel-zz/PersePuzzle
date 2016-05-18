using UnityEngine;
using System.Collections;

public class TutorialEnemy : MonoBehaviour {
	public GameObject finger2;
	public GameObject Joystick;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Projectile") {
			Joystick.SetActive (true);
			finger2.SetActive (false);
		
		}
	}
}
