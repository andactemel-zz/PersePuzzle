using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class LevelEditor : MonoBehaviour {
	public static Level[] levels;
	public int levelCount;
	public bool firstTime=true;
	public GameObject[] LevelObjects;
	// Use this for initialization
	void Start () {

	//PlayerPrefs.DeleteKey ("firsttime");
		if (PlayerPrefs.HasKey ("firsttime")) {
		
			firstTime = false;
				PlayerPrefs.SetInt("firsttime",0);
			Debug.Log ("firsttime değil ");
		}
		else
		{
			Debug.Log ("firsttime ");
			PlayerPrefs.SetInt("firsttime",1);
			firstTime=true;

		}
		if (firstTime) {
			Debug.Log ("firsttime da initilaize level");
			levels = new Level[levelCount];
			InitiliazeLevels ();
			LoadLevelsFromClass();
		
		
		} else {

			Debug.Log ("firsttime değil leveldan yükle ");
			if (levels == null) {
			
			//player preften levelları güncelle

			

				UpdatelevelsFromPlayerPref();
				//ekrana levelsdan yazıdr
				LoadLevelsFromClass();
			
			} else {


				//Level ı player prefe ata sonra
				UpdatePlayerPrefFromLevels();
				// ekranı güncelle from levels
				LoadLevelsFromClass();
			}

		}

		//PlayerPrefs.DeleteKey ("firsttime");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void LoadLevelsFromClass()
	{

		ShowLevel ();



		for (int i = 0; i < levels.Length; i++) {
		
			LevelObjects [i].SetActive (true);
			if (levels [i].Unlocked == 1) {
				//unlocksuz resim
				LevelObjects[i].transform.GetChild(0).gameObject.SetActive(false);
				LevelObjects [i].GetComponent<Button> ().interactable = true;
				//scora göre resim koy

				for(int k=0;k<levels[i].score;k++)
				{

					LevelObjects [i].transform.GetChild (k + 1).transform.GetChild(0).gameObject.SetActive (true);

				}
			
			
			} else {
				LevelObjects [i].GetComponent<Button> ().interactable = false;
				//unlocklu resim
			}
		
		
		
		}

	}

	void UpdatelevelsFromPlayerPref()
	{
		
		levels = new Level[PlayerPrefs.GetInt ("levelcount")];
		Debug.Log (levels.Length);
		for(int i=0; i<PlayerPrefs.GetInt ("levelcount");i++)
		{
			levels [i] = new Level ();
			levels [i].levelName = "Level" + (i+1).ToString ();
			levels [i].score = PlayerPrefs.GetInt (levels [i].levelName + "score");
			levels [i].Unlocked = PlayerPrefs.GetInt (levels [i].levelName + "unlocked");



		}
		
	}
	public static void UpdatePlayerPrefFromLevels()
	{
	
		for (int i = 0; i < levels.Length; i++) {
		
			PlayerPrefs.SetInt (levels [i].levelName + "score", levels [i].score);
			PlayerPrefs.SetInt (levels [i].levelName + "unlocked", levels [i].Unlocked);

		
		
		}
	}





	void InitiliazeLevels()
	{	
		PlayerPrefs.SetInt ("levelcount", levelCount);
	
			for (int i = 0; i < levelCount; i++) {
			levels [i] = new Level ();
				levels [i].levelName = "Level" + (i + 1).ToString ();
			//Debug.Log (levels [i].levelName);
				levels [i].Unlocked = 0;
				levels [i].score = 0;
				PlayerPrefs.SetInt (levels [i].levelName + "unlocked", 0);
				PlayerPrefs.SetInt (levels [i].levelName + "score", 0);
			if (i == 0) {

				levels [i].Unlocked = 1;
				PlayerPrefs.SetInt (levels [i].levelName + "unlocked", 1);
			}
		
		
			}


	
	}



	public void ShowLevel()
	{

		for (int i = 0; i < levels.Length; i++) {
		
			Debug.Log ("Level adı "+levels [i].levelName + " levelunlocked " + levels [i].Unlocked + " levelscore " + levels [i].score);
		
		
		}
	}
}



public class Level{

	public int Unlocked;
	public string levelName;
	public int score;
	//int Unlocked,string levelName,int score
	public Level()
	{
		/*this.Unlocked = Unlocked;
		this.levelName = levelName;
		this.score = score;
*/
	}

}
