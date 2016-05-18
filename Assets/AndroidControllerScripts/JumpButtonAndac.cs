using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class JumpButtonAndac :MonoBehaviour,IPointerClickHandler,IPointerDownHandler,IPointerUpHandler  {
	public UnitPlayer player;
	Image jump;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<UnitPlayer> ();
		jump=GetComponent<Image> ();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public virtual void OnPointerDown(PointerEventData ped)
	{
		jump.enabled = false;
			player.JumpForVirtual = true;
		Debug.Log (player.control.isGrounded);
		if (player.control.isGrounded) {
			Debug.Log ("tıklandı ve jump cagırıldı");
			player.Jump ();
		}
	}

	public virtual void OnPointerUp(PointerEventData ped){

		jump.enabled = true;
	}
	public virtual void OnPointerClick(PointerEventData ped){
		
	}
}
