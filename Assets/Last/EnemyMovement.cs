using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {
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




	public GameObject projectile;



	// Use this for initialization
	void Start () {
		
		Target = transform.position;
	

		control = GetComponent<CharacterController> ();
		transform.position = WayPoints [0].position;
		transform.position = WayPoints [0].position;
		if (WayPoints.Length > 1) {
			GoNextWayPoint ();


		}
		StartCoroutine (Fire ());


	}
	
	// Update is called once per frame
	void Update () {
	
		direction = (Target - transform.position).normalized;
		control.Move (direction * Time.deltaTime*moveSpeed);
		if ((transform.position - Target).magnitude < 0.2f) {
			GoNextWayPoint ();

		}

		transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (direction), 0.3f);
	
			


	}

	void GoNextWayPoint()
	{
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
		GameObject.Instantiate (projectile, transform.position+direction, Quaternion.Euler( new Vector3(transform.eulerAngles.z,transform.eulerAngles.y,transform.eulerAngles.x)));
		yield return new WaitForSeconds (2f);
		StartCoroutine (Fire ());

	}









}
