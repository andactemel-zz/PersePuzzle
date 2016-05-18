using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class FireButtonAndac : MonoBehaviour,IPointerClickHandler,IPointerUpHandler,IPointerDownHandler {
	public UnitPlayer player;
	Image fire;
	public bool TutorialGO=false;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<UnitPlayer> ();
		fire = GetComponent<Image> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	public virtual void OnPointerDown(PointerEventData ped)
	{
		fire.enabled = false;
		TutorialGO = true;
		player.Fire ();

	}

	public virtual void OnPointerUp(PointerEventData ped){

		fire.enabled = true;
	}
	public virtual void OnPointerClick(PointerEventData ped){

	}


}
