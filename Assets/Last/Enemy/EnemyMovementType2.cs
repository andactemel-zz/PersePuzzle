using UnityEngine;
using System.Collections;

public class EnemyMovementType2 : MonoBehaviour {


	/*
	 * Bu düşman tipi topview ve sideview dayken sağa sola hareket ediyor ve istenirse "isFiringSide" ve "isFiringTop" değişkeni ile
	 *  sağa ve sola ateş edip edilmediği belirleniyor 
	 * 
	 * Projectilı kendine özgü o "ProjectileEnemy2" bağlanması lazım
	 * 
	 * */

	public CharacterController control;
	public Vector3 move=Vector3.zero;
	public float gravity=20f;
	public Vector3 Target;
	public int i;
	bool goUp=true;
	public Vector3 direction=Vector3.zero;
	public float moveSpeed=3f;
	public Transform[] WayPoints;
	CameraMovement CM;
	GameObject player;
	public bool isFiringSide=true;
	public bool isFiringTop=true;

	//trigger alanını k0ontrol eden değişkenler
	public float x_SizeofTrigger=35f;
	public float z_SizeofTrigger=35f;
	bool triggerOriented=false;

	public GameObject projectile;
	public GameObject BXCollider;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		//WayPoints [0].position = new Vector3 (transform.position.x, transform.position.y, WayPoints [0].position.z);
		//WayPoints [1].position = new Vector3 (transform.position.x, transform.position.y, WayPoints [1].position.z);
		Target = transform.position;
		CM = Camera.main.GetComponent<CameraMovement> ();

		control = GetComponent<CharacterController> ();
		transform.position = WayPoints [0].position;
		if (WayPoints.Length > 1) {
			GoNextWayPoint ();


		}

			StartCoroutine (Fire ());



	}

	// Update is called once per frame
	void Update () {

		direction = (Target - transform.position).normalized;




			control.Move (direction * Time.deltaTime * moveSpeed);

			if ((transform.position - Target).magnitude < 0.2f) {
				GoNextWayPoint ();

			}

		 
		transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (direction), 0.3f);

			ChangeObjectTriggerArea ();


	}

	void GoNextWayPoint()
	{

//		Debug.Log ("GonextPoint");
		if (goUp) {
			i = i + 1;
			if (i+1 > WayPoints.Length) {

				goUp = false;
				i = i - 1;
			} else {

				Target = WayPoints [i].position;
			} 
		}


		if (!goUp) {
			i = i - 1;
			if (i < 0) {
				i = i + 1;
				goUp = true;

			} else {
				Target = WayPoints [i].position;
			}

		}



	}

	IEnumerator Fire()
	{
		//Debug.Log ("Fire");

			Vector3 temp = transform.position + direction;
			

			if (isFiringTop && !CM.sideView) {
				GameObject.Instantiate (projectile, temp, Quaternion.Euler (new Vector3 (transform.eulerAngles.z, transform.eulerAngles.y, transform.eulerAngles.x)));
			} else if(isFiringSide &&CM.sideView) {
				
				GameObject.Instantiate (projectile, temp, Quaternion.Euler (new Vector3 (transform.eulerAngles.z, transform.eulerAngles.y, transform.eulerAngles.x)));
			}
		
		yield return new WaitForSeconds (2f);

		StartCoroutine (Fire ());


	}

	public void ChangeObjectTriggerArea()
	{
		BXCollider.transform.rotation = Quaternion.identity;
		Vector3 temp=BXCollider.GetComponent<BoxCollider> ().size;
		if (CM.sideView) {

			temp.z = z_SizeofTrigger;
			temp.y = 2f;
			temp.x = 1f;
			BXCollider.GetComponent<BoxCollider> ().size = temp;
			
		
		} else {
			temp.z = 1f;
			temp.y = 2f;
			temp.x = x_SizeofTrigger;
			BXCollider.GetComponent<BoxCollider> ().size = temp;
		}

	}

}
