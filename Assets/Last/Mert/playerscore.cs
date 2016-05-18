using UnityEngine;
using System.Collections;

public class playerscore : MonoBehaviour {
	public float score;
	// Use this for initialization
	void Start () {
		score = 20000f;
	}
	
	// Update is called once per frame
	void Update () {
	
		score = score - (Time.deltaTime * 250);
	}
}
