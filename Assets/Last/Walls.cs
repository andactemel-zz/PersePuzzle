using UnityEngine;
using System.Collections;

public class Walls : MonoBehaviour {
	public CameraMovement CM;
	// Use this for initialization
	void Start () {
		CM = Camera.main.gameObject.GetComponent<CameraMovement>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	/*void OnTriggerStay(Collider other) {

		if (CM.changing) {
			if (other.gameObject.tag == "Player") {
			

				//other.gameObject.transform.position = Vector3.Lerp (other.gameObject.transform.position, other.transform.position + Vector3.left, 1f);
		
			}
		}
	}*/
}
