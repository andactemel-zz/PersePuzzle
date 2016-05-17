using UnityEngine;
using System.Collections;

public class opendoors : MonoBehaviour {
	public AnimationClip door;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void openit()
	{
		GetComponent<Animator> ().SetTrigger("leverpushed");
		Debug.Log ("openit called");
	}
}
