using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class RatingForTime : MonoBehaviour {
	public int score;
	public float startTime;
	public float finishTime;
	public float currentTime;
	public float decreasingTime = 0.1f;//küçüldükçe yavaş akıyor
	bool started=false;
	public RawImage Star;
	public GameObject[] stars;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (started) {
		
			currentTime = Time.time - startTime;
//			Debug.Log (currentTime);


			Star.uvRect = new Rect (currentTime * decreasingTime, 0f, 1f, 1f);
		
		}
	
	}

	public int CalculateScore()
	{
		started = false;
		if (Star.uvRect.x < 0.34f) {
			score = 3;
		
		} else if (Star.uvRect.x < 0.66f) {
			score = 2;
			
		} else if (Star.uvRect.x < 1f) {
			score = 1;
		} else {
			score = 0;
		}
		if (PlayerPrefs.GetInt ("currentlevel")== 0) {

			LevelEditor.levels [PlayerPrefs.GetInt ("currentlevel")].score = 3;
			score = 3;

		}
		for (int i = 0; i < score; i++) {
		

			stars [i].SetActive (true);
		}
		return score;


	}

	public void StartTimer()
	{
		started = true;
		startTime = Time.time;
	}
}
