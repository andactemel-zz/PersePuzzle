using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TutorialManager2 : MonoBehaviour {
	public GameObject SlideArea1;
	public GameObject SlideArea2;
	public GameObject SlideArea3;
	public GameObject Joystick;
	public GameObject Buttons; 
	public Sprite[] tutorials;
	public int tc=0;
	public GameObject tutorialUI;
	public GameObject finger;
	public GameObject finger2;
	public GameObject finger3;
	public GameObject enemy2;
	public FireButtonAndac FBA;
	bool first=true;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetMouseButtonDown (0) && tc==0) {
		
			NextTutorialImage ();
		
		
		}
		if (FBA.TutorialGO == true&&first) {
		
			first = false;
			NextTutorialImage ();
		
		
		}
	
	}

	void NextTutorialImage()
	{

		tc++;
		tutorialUI.GetComponent<Image> ().sprite = tutorials [tc];


		if (tc == 1) {
		
			Buttons.SetActive (true);
			finger3.SetActive (true);
		
		
		}

		if (tc == 2) {
			finger3.SetActive (false);
		
			finger.SetActive (true);
			finger2.SetActive (true);
			StartCoroutine (SpawnEnemyAgain ());
		
		}
	}

	IEnumerator SpawnEnemyAgain()
	{

		yield return new WaitForSeconds(2f);
		enemy2.SetActive(true);
	}
}
