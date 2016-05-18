using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Saver : MonoBehaviour {
	
	public int score;//score tutacak
	public string LevelManagerName = "LevelManager";
//Buraya tekrar bak önemliiiiiiiiiiiiiiiiiiiiiii
	private int LevelAmount = 3;//kaç tane levelimiz varsa buraya yazıyoruz


	private int CurrentLevel;

	public void SetScore(int scoreAmount)//leveli geçince bu fonksiyon çağırılacak save edilmiş score ile
	{
		score = scoreAmount;
		CheckCurrentLevel ();

	}

	void CheckCurrentLevel()
	{
		//hangi leveldayz
		for (int i = 1; i <= LevelAmount; i++)
		{
			//if (Application.loadedLevelName == "Level" + i)//bunuda deneyebilirsin
			if(SceneManager.GetActiveScene().name == "Level" + i)//unity 5.3ten sonrakinde böyle oluyormuş
			{

				CurrentLevel = i;//found levelin score et
				SaveMyGame ();
			}
		}
	}





	void SaveMyGame()
	{
		//burda save olayını yapıyoruz
		int NextLevel = CurrentLevel + 1;// unlocked level için gerekli
		if (NextLevel < LevelAmount+1) {//to prevent overflow
			PlayerPrefs.SetInt ("Level" + NextLevel.ToString (), 1);//unlock next level
			if (PlayerPrefs.GetInt ("Level" + CurrentLevel.ToString () + "_score") < score) //eğer current store en yüksekse o ztn en yüksek olandır onu check ediyoruz
			{
				PlayerPrefs.SetInt ("Level" + CurrentLevel.ToString () + "_score", score);//eğer öyleyse save ediyor
			}
		} 
		else //eğer son levelsa
		{
			if (PlayerPrefs.GetInt ("Level" + CurrentLevel.ToString () + "_score") < score) 
			{
				PlayerPrefs.SetInt ("Level" + CurrentLevel.ToString () + "_score", score);
			}
		}
		BackToLevelSelect ();
	}

	void BackToLevelSelect()
	{
		// Level Select Menuye geri dönüyoruz
		SceneManager.LoadScene(LevelManagerName);
	}
}
