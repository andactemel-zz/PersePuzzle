using UnityEngine;
using System.Collections;

public class EnemyMovementType1 : MonoBehaviour {

	/*
	 * Bu düşman tipi sadece top view dayken yukarı aşağı hareket ediyor ve istenirse "isFiring" değişkeni ile ateş edip edilmediği belirleniyor 
	 * 
	 * Projectilı kendine özgü o "ProjectileEnemy1" bağlanması lazım
	 * 
	 * "alwaysOnSight" değişkeni ile karakterin side viewda durması ve görünmesimi yoksa, side viewdada top hareketine devam etmesi gerektiğine
	 * mi karar veriliyor
	 * 
	 * 
	 * WayPointler sadece "z ekseninde nereye getirilmek isteniyorsa getirilip bağlanırsa yeterli oluyor. Sadece yukarı aşağıı hareket
	 * ettiğinden dolayı yokus cıkmasına gerek yok way pointleri kafanıza göre yerleştirin kod onları dogru x,y pozisyonuna getiriyor
	 * x i ve y sini kendisininkine eşitliyor
	 * 
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
	public bool alwayOnSight=true;// düşman yan görüntüde hep kalsın isteniyorsa true olmalı
	public bool isFiring=true;



	public GameObject projectile;


	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		//burada waypointler senkronize ediliyor
		WayPoints [0].position = new Vector3 (transform.position.x, transform.position.y, WayPoints [0].position.z);
		WayPoints [1].position = new Vector3 (transform.position.x, transform.position.y, WayPoints [1].position.z);
		Target = transform.position;
		CM = Camera.main.GetComponent<CameraMovement> ();

		control = GetComponent<CharacterController> ();
		transform.position = WayPoints [0].position;
		if (WayPoints.Length > 1) {
			GoNextWayPoint ();


		}
		if (isFiring) {
			StartCoroutine (Fire ());
		}

	}

	// Update is called once per frame
	void Update () {
		
			direction = (Target - transform.position).normalized;


		if (!CM.sideView) {
			
				control.Move (direction * Time.deltaTime * moveSpeed);

				if ((transform.position - Target).magnitude < 0.2f) {
					GoNextWayPoint ();

				}
			
		} else {
			if (alwayOnSight) {

				transform.position = new Vector3 (transform.position.x, transform.position.y, player.transform.position.z);
			} else {

				control.Move (direction * Time.deltaTime * moveSpeed);

				if ((transform.position - Target).magnitude < 0.2f) {
					GoNextWayPoint ();

				}

			}
		}
			transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (direction), 0.3f);




	}

	void GoNextWayPoint()
	{

		Debug.Log ("GonextPoint");
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

		if (!CM.sideView) {
			Vector3 temp = transform.position + direction;
			temp.y = player.transform.position.y;
			GameObject.Instantiate (projectile, temp, Quaternion.Euler (new Vector3 (transform.eulerAngles.z, transform.eulerAngles.y, transform.eulerAngles.x)));
		}
			yield return new WaitForSeconds (2f);

				StartCoroutine (Fire ());


	}


}
