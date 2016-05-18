using UnityEngine;
using System.Collections;

public class UnitBackGround : Unit {
	public GameObject player;
	public float followSpeed=0.1f;
	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player");
		base.Start ();
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 temp = player.GetComponent<Unit> ().move;
		temp.x *= followSpeed;
		//temp.x = -temp.x;
		temp.y = 0;
		temp.z = 0;
		move = temp;
		base.Update ();
	
	}
}
