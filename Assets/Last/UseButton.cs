using UnityEngine;
using System.Collections;

public class UseButton : MonoBehaviour {
	public GameObject usedObject;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnMouseDown() {
	
		Debug.Log ("Tıklandım");
		GetComponent<SpriteRenderer> ().color = Color.black;
	
	}
	void OnMouseUp(){
	
		Debug.Log ("Bıraktım");
		GetComponent<SpriteRenderer> ().color = Color.white;
		usedObject.GetComponent<UsePlatformOpen> ().UseMe();
	
	}


}
