using UnityEngine;
using System.Collections;

public class WallControl : MonoBehaviour {

	// Use this for initialization
	public GameObject top;
	public GameObject side;
	CameraMovement CM;
	void Start () {
	
		top = transform.GetChild (0).gameObject;
		side = transform.GetChild (1).gameObject;
		CM = Camera.main.gameObject.GetComponent<CameraMovement>();
	}
	
	// Update is called once per frame
	void Update () {
		if (CM.changing ) {
			if (CM.sideView) {
				top.SetActive (false);
				side.SetActive (true);
			} else {
				side.SetActive (false);
				top.SetActive (true);
			}
		
		}
	
	}
}
