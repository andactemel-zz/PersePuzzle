using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]

public class Unit : MonoBehaviour {

	public CharacterController control;
	public Vector3 move=Vector3.zero;
	public Vector3 targetPos;//perpektif değişirken karakterin gideceği pozisyon
	public float bottomY = -8.5f; //karakterin topView de y pozisyonunda olması gerekn yer
	public float bottomZ = -9f;  //karakterin sideView de y pozisyonunda olması gerekn yer
	public float jumpSpeed=8f;
	public float gravity=20f;
	public float speed=6f;
	public bool sideView=true;
	public float characterOrientaionSpeed = 0.3f;// karakter perpektif değişirken yerine hangi hızla gideceğini hesaplıyor (0 ile 1 arasında float olmalı)
	public CameraMovement CM;
	// Use this for initialization
	public virtual void Start () {
		targetPos = transform.position;
		control =GetComponent<CharacterController>();
		CM = Camera.main.GetComponent<CameraMovement> ();
		if (!control) {
		
			Debug.LogError ("Unit.Start() " + name + " has no Chracter controller");
			enabled = false;
		}
	
	}
	
	// Update is called once per frame
	public virtual  void Update () {
	

		if (!CM.changing) { 
			control.Move (move * Time.deltaTime);

		
		}
		else {   // perspektif değişirken karakterin yerini oryante eden kod
			if(gameObject.tag=="Player")
			transform.position = Vector3.Lerp (transform.position, targetPos, characterOrientaionSpeed);
		
		}
	}
	public virtual void AdjustPositionofCharacter()
	{
		
	}

}
