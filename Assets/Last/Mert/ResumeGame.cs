using UnityEngine;
using System.Collections;

public class ResumeGame : MonoBehaviour {
	public GameObject Rating;
	public GameObject levelcomplete;
	public GameObject Sound;
	// Use this for initialization
	void Start () {
	
		Rating = GameObject.FindGameObjectWithTag ("Rating");
		levelcomplete = GameObject.FindGameObjectWithTag ("LevelComplateGUI");
		Sound = GameObject.FindGameObjectWithTag ("Sound");

	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void resumegameee()
	{
		Time.timeScale = 1.0f;


	}
		
	public void gotomainmenu()
	{
		Application.LoadLevel ("Main Menu Scene");
		Time.timeScale = 1.0f;
	}

	public void gotolevels()
	{
		Application.LoadLevel ("Levels");
		Time.timeScale = 1.0f;
	}
	public void startlevel1()
	{
		Application.LoadLevel ("Level1");
		PlayerPrefs.SetInt("currentlevel", 0);
	}
	public void startlevel2()
	{
		Application.LoadLevel ("Level2");
		PlayerPrefs.SetInt("currentlevel", 1);
	}

	public void startlevel3()
	{
		Application.LoadLevel ("Level3");
		PlayerPrefs.SetInt("currentlevel", 2);
	}
	public void startlevel4()
	{
		Application.LoadLevel ("Level4");
		PlayerPrefs.SetInt("currentlevel", 3);
	}
	public void startlevel5()
	{
		Application.LoadLevel ("Level5");
		PlayerPrefs.SetInt("currentlevel", 4);
	}
	public void startlevel6()
	{
		Application.LoadLevel ("Level6");
		PlayerPrefs.SetInt("currentlevel", 5);
	}
	public void startlevel7()
	{
		Application.LoadLevel ("Level7");
		PlayerPrefs.SetInt("currentlevel", 6);
	}
	public void startlevel8()
	{
		Application.LoadLevel ("Level8");
		PlayerPrefs.SetInt("currentlevel", 7);
	}
	public void restart()
	{
		Application.LoadLevel(Application.loadedLevel);
		Time.timeScale = 1.0f;
	}

	public void NextLevel(){
		if(PlayerPrefs.GetInt("currentlevel")!=7){
		PlayerPrefs.SetInt("currentlevel", PlayerPrefs.GetInt("currentlevel")+1);
		Time.timeScale = 1.0f;
		Application.LoadLevel ("Level"+(PlayerPrefs.GetInt("currentlevel")+1).ToString());
		}


	}
	public void credits()
	{
		Application.LoadLevel ("Credits");
	}



	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Player") {

			Sound.GetComponent<SoundManager> ().WinSound ();
			Time.timeScale = 0f;
			//levelcomplete.SetActive (true);
			for (int i = 0; i < levelcomplete.transform.childCount; i++) {
		
				levelcomplete.transform.GetChild (i).gameObject.SetActive (true);

		
			}
			Debug.Log (PlayerPrefs.GetInt ("currentlevel"));
			if (PlayerPrefs.GetInt ("currentlevel") != 7) {
				Debug.Log ("next level numberı " + (PlayerPrefs.GetInt ("currentlevel") + 1));

				LevelEditor.levels [PlayerPrefs.GetInt ("currentlevel") + 1].Unlocked = 1;
			}

			//Puanın Hesaplandığı yer
			if (PlayerPrefs.GetInt ("currentlevel") == 0 ||PlayerPrefs.GetInt ("currentlevel")==1) {
				Rating.GetComponent<RatingForTime> ().CalculateScore ();
				LevelEditor.levels [PlayerPrefs.GetInt ("currentlevel")].score = 3;
		
		
			}


			else if (Rating.GetComponent<RatingForTime> ().CalculateScore () > LevelEditor.levels [PlayerPrefs.GetInt ("currentlevel")].score) {
				LevelEditor.levels [PlayerPrefs.GetInt ("currentlevel")].score = Rating.GetComponent<RatingForTime> ().CalculateScore ();
			}


			LevelEditor.UpdatePlayerPrefFromLevels ();

		}


	
	}

}