using UnityEngine;
using System.Collections;

public class BackGroundController : MonoBehaviour {

	public GameObject Cam;
	public GameObject[] BackGrounds;
	public GameObject player;


	// Use this for initialization
	void Start () {
		Cam = Camera.main.gameObject;
		BackGrounds=new GameObject[GameObject.FindGameObjectsWithTag ("Backgrounds").Length] ;
		BackGrounds = GameObject.FindGameObjectsWithTag ("Backgrounds");
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 camPos = Cam.transform.position;
		transform.position = new Vector3 (camPos.x, 0f, 19.37f);
	
	}



}
