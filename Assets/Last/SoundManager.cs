using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {
	public bool mute;
	public AudioClip button;
	public AudioClip jump;
	public AudioClip fire;
	public AudioClip dead;
	public AudioClip perspective;
	public AudioClip win;
	// Use this for initialization
	void Start () {
		if (PlayerPrefs.HasKey ("mute")) {
		
			if (PlayerPrefs.GetInt ("mute") == 1) {
			
				mute = true;
			
			} else {
				mute = false;
			
			}
		
		} else {
		
			mute = false;
		
		}
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ButtonSound()
	{
		if (!mute) {
			
			AudioSource.PlayClipAtPoint (button, Camera.main.transform.position);
		
		}

	}
	public void JumpSound()
	{
		if (!mute) {

			AudioSource.PlayClipAtPoint (jump, Camera.main.transform.position);

		}

	}
	public void FireSound()
	{
		if (!mute) {

			AudioSource.PlayClipAtPoint (fire, Camera.main.transform.position);

		}

	}

	public void DeadSound()
	{
		if (!mute) {

			AudioSource.PlayClipAtPoint (dead, Camera.main.transform.position);

		}

	}

	public void PerspectiveSound()
	{
		if (!mute) {

			AudioSource.PlayClipAtPoint (perspective, Camera.main.transform.position);

		}

	}
	public void WinSound()
	{
		if (!mute) {

			AudioSource.PlayClipAtPoint (win, Camera.main.transform.position);

		}

	}

}
