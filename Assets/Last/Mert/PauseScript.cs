using UnityEngine;
using System.Collections;

public class PauseScript : MonoBehaviour {
	public GameObject PauseGUI;
	public bool paused ;
	// Use this for initialization
	void Start () {
		PauseGUI = GameObject.FindGameObjectWithTag ("PauseGUI");
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape) & !paused) {
			Time.timeScale = 0.0f;

			Pause ();


		} else if (Input.GetKeyDown (KeyCode.Escape) & !paused) {
		
		
			ResumeGamee ();
		
		}

			
	
	}

	public void ResumeGamee()
	{
		for (int i = 0; i < PauseGUI.transform.childCount; i++) {

			PauseGUI.transform.GetChild (i).gameObject.SetActive (false);



		}
		Time.timeScale = 1.0f;
		paused = false;

	}

	public void Pause()
	{
		if (!paused) {
			Time.timeScale = 0.0f;

			Debug.Log ("paused bitch");
			for (int i = 0; i < PauseGUI.transform.childCount; i++) {

				PauseGUI.transform.GetChild (i).gameObject.SetActive (true);



			}

		}
	}
}
