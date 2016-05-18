using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class TutorialManager : MonoBehaviour {
	public GameObject SlideArea1;
	public GameObject SlideArea2;
	public GameObject SlideArea3;
	public GameObject Joystick;
	public GameObject Buttons; 
	public Sprite[] tutorials;
	public int tc=0;
	public GameObject tutorialUI;
	public GameObject finger;
	public GameObject fingerShadow;
	public GameObject player;
	// Use this for initialization
	void Start () {
		//tutorialUI.GetComponent<Image> ().sprite = tutorials [4];
	}
	
	// Update is called once per frame
	void Update () {
	


		if (tc == 7) {
		
			if (player.transform.position.x > -4f) {
			
				NextTutorialImage ();
			
			
			
			}
		
		
		
		}


		if (tc == 6) {
		
			if (SlideArea1.GetComponent<PerpectiveSlideAndac> ().tutorial || SlideArea2.GetComponent<PerpectiveSlideAndac> ().tutorial || SlideArea3.GetComponent<PerpectiveSlideAndac> ().tutorial) {

				NextTutorialImage ();


			}
		
		
		
		
		}



		if (tc == 5) {
		
			if (Joystick.GetComponent<VirtualJoystickAndac> ().tutorial) {

				NextTutorialImage ();


			}
		
		
		}
	

		if (tc == 4) {

			if (Joystick.GetComponent<VirtualJoystickAndac> ().tutorial2) {
			
				NextTutorialImage ();
			
			
			}
		}


		if (tc == 3) {
		
			if (SlideArea1.GetComponent<PerpectiveSlideAndac> ().tutorial || SlideArea2.GetComponent<PerpectiveSlideAndac> ().tutorial || SlideArea3.GetComponent<PerpectiveSlideAndac> ().tutorial) {
			
				NextTutorialImage ();
			
			
			}
		
		
		}


		if (tc == 2) {
		
		
			if (Joystick.GetComponent<VirtualJoystickAndac> ().tutorial) {
			
				NextTutorialImage ();
			
			}
		
		}

		if (Input.GetMouseButtonDown (0)) {
		
			if (tc < 2) {
			
				NextTutorialImage ();
			
			} 
		}


		
	}

	void NextTutorialImage()
	{
		
		tc++;
		tutorialUI.GetComponent<Image> ().sprite = tutorials [tc];
		if (tc == 2) {
		
		
			Joystick.SetActive (true);
		}

		if (tc == 3) {
		
			SlideArea1.SetActive (true);
			SlideArea2.SetActive (true);
			SlideArea3.SetActive (true);
			finger.SetActive (true);
			fingerShadow.SetActive (true);
		
		}
		if (tc == 4) {
		
			finger.SetActive (false);
			fingerShadow.SetActive (false);

			SlideArea1.SetActive (false);
			SlideArea2.SetActive (false);
			SlideArea3.SetActive (false);
			Joystick.GetComponent<VirtualJoystickAndac> ().tutorial2 = false;
			Joystick.GetComponent<VirtualJoystickAndac> ().tutorial = false;
		
		}
		if (tc == 6) {
		
			SlideArea1.SetActive (true);
			SlideArea2.SetActive (true);
			SlideArea3.SetActive (true);
			finger.SetActive (true);
			fingerShadow.SetActive (true);
			SlideArea1.GetComponent<PerpectiveSlideAndac> ().tutorial = false; SlideArea2.GetComponent<PerpectiveSlideAndac> ().tutorial = false; SlideArea3.GetComponent<PerpectiveSlideAndac> ().tutorial = false;
		
		}
		if (tc == 7) {
		
		
			finger.SetActive (false);
			fingerShadow.SetActive (false);
		
		
		}


	}
}
