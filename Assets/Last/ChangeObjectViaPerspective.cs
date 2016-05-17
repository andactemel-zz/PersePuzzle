using UnityEngine;
using System.Collections;

public class ChangeObjectViaPerspective : MonoBehaviour {
	public CameraMovement CM;
	bool change=false;
	// Use this for initialization
	void Start () {
		CM = Camera.main.GetComponent<CameraMovement> ();

	}
	
	// Update is called once per frame
	void Update () {
		if (CM.sideView) {
			transform.GetChild (0).gameObject.SetActive (true);
			transform.GetChild (1).gameObject.SetActive (false);
		
		} else {
			transform.GetChild (0).gameObject.SetActive (false);
			transform.GetChild (1).gameObject.SetActive (true);
		}
	}
}
