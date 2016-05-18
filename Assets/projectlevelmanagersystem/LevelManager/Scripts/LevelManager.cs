using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {


	[System.Serializable]
	public class Level
	{
		public string LevelText;
		public int UnLocked;
		public bool IsInteractable;
	}
	public GameObject levelButton;
	public Transform Spacer;//canvasta gameobject için
	public List<Level> LevelList;
	//Burdaki sayıları geçtikçe star yükselicek
	// levelManager GameObjectte değiştirilebilir
	public int Star1Points = 5000;
	public int Star2Points = 10000;
	public int Star3Points = 20000;

	void Start () 
	{
		FillList ();
	}

	void FillList()
	{
		foreach(var level in LevelList)
		{
			GameObject newbutton = Instantiate(levelButton) as GameObject;
			LevelButton button = newbutton.GetComponent<LevelButton>();
			button.LevelText.text = level.LevelText;
			//döngüde olan butonun value su 1 ise o zaman unlocked et interactive yap
			if(PlayerPrefs.GetInt("Level" + button.LevelText.text) == 1)
			{
				level.UnLocked = 1;
				level.IsInteractable = true;
			}
			//kilit state
			button.unlocked = level.UnLocked;
			//etkileşimli olan state
			button.GetComponent<Button>().interactable = level.IsInteractable;

			button.GetComponent<Button>().onClick.AddListener(() => SceneManager.LoadScene("Demo"));
			//startları check et 
			if(PlayerPrefs.GetInt("Level"+ button.LevelText.text + "_score") >= Star1Points)
			{
				button.Star1.SetActive(true);
			}

			if(PlayerPrefs.GetInt("Level"+ button.LevelText.text + "_score") >= Star2Points)
			{
				button.Star2.SetActive(true);
			}

			if(PlayerPrefs.GetInt("Level"+ button.LevelText.text + "_score") >= Star3Points)
			{
				button.Star3.SetActive(true);
			}
			// spacer için parent set et canvas için gerekli
			newbutton.transform.SetParent(Spacer,false);
		}
		SaveAll ();//oyun baslayınca save
	
	}

	void SaveAll()
	{
		if(PlayerPrefs.HasKey("Level1"))//eger kaydedildiyse önceden
		{
			return;//burda birşey yapma
		}
		else
		{
			
			GameObject[] allButtons = GameObject.FindGameObjectsWithTag("LevelButton");
			foreach (GameObject buttons in allButtons)
			{
				LevelButton button = buttons.GetComponent<LevelButton>();
				PlayerPrefs.SetInt("Level" + button.LevelText.text, button.unlocked);
			}
		}
	}
	//bütün kaydedilmişleri silmek için
	public void DeleteAll()
	{
		PlayerPrefs.DeleteAll ();
	}
	//tıklanılan leveli siliyor
	void loadLevels(string value)
	{
		//Application.LoadLevel (value);
		SceneManager.LoadScene(value);
	}
}
