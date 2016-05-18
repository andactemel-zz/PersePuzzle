using UnityEngine;
using System.Collections;

public class guizzzzz : MonoBehaviour {

	void OnGUI() {
		if (GUI.Button (new Rect (0, Screen.height / 4+100, Screen.width, 100), "Run Again!!")) {
			Time.timeScale = 1.0f;
			Application.LoadLevel(1);


		}
		if (GUI.Button (new Rect (0, Screen.height / 4+200, Screen.width, 100), "Main Menu")) {
			Time.timeScale = 1.0f;
			Application.LoadLevel(0);


		}
	}
}