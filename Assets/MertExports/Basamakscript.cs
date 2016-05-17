using UnityEngine;
using System.Collections;

public class Basamakscript : MonoBehaviour {

	public GameObject rightgate;
	public GameObject leftgate;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider other) {
		Debug.Log ("door opens");
		rightgate.GetComponent<Animator> ().SetTrigger ("opened");
		leftgate.GetComponent<Animator> ().SetTrigger ("opened");
	}
}
