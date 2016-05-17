using UnityEngine;
using System.Collections;

public class TutorialSwitch : MonoBehaviour {
	public GameObject finger2;

	public GameObject Slide;
	public GameObject Slide2;
	public GameObject Slide3;
	public GameObject Tuto;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		 
			
			finger2.SetActive (false);
		Slide.SetActive (true);
		Slide2.SetActive (true);
		Slide3.SetActive (true);
		Tuto.SetActive( false);


	}
}
