using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PerpectiveSlideAndac : MonoBehaviour,IDragHandler,IPointerDownHandler,IPointerUpHandler {
	float slideThreshhold=50f;
	public Vector2 slideStart;
	public Vector2 slideFinish;
	UnitPlayer player;
	CameraMovement CM;
	public bool tutorial=false;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<UnitPlayer> ();
		CM = Camera.main.GetComponent<CameraMovement> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public virtual void OnDrag(PointerEventData ped)
	{
		


	}
	public virtual void OnPointerDown(PointerEventData ped)
	{
		
		slideStart = ped.position;

		OnDrag (ped);


	}
	public virtual void OnPointerUp(PointerEventData ped)
	{
		slideFinish = ped.position;

		if (Mathf.Abs (slideStart.y - slideFinish.y) > slideThreshhold) {
			

			player.ChangePerspective ();
			CM.ChangeView ();
			tutorial = true;

		}

		
	}
}
