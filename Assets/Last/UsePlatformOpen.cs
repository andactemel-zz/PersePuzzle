using UnityEngine;
using System.Collections;

public class UsePlatformOpen : Use {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		base.Update ();
	}

	public virtual void UseMe()
	{
		GetComponent<Animator> ().SetBool ("Open", true);
		base.UseMe ();
	}
}
