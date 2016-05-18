using UnityEngine;
using System.Collections;


public class CameraMovement : MonoBehaviour {
	Vector3 targetPos;
	Quaternion targetRot;
	public Vector3 TopPos;
	public Vector3 SidePos;
	public float TopCameraRot=90f;
	public float SideCameraRot=0f;
	public bool sideView = true;
	public bool changing = false;
	public float WaitingOfCamera = 0.25f;
	public float cameraLeftLimit = -45f;//Kamera smmoth follwda gidebileceği en sol yer
	public float cameraRightLimit = 45f;//Kamera smooth followda gidebileceği en sağ yer
	public GameObject player;
	// Use this for initialization

	void Start () {
		
		player = GameObject.FindGameObjectWithTag ("Player");
		transform.position = new Vector3 (cameraLeftLimit, transform.position.y, transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.E)) {
			WhenPerspectiveChangeStarted ();
			ChangeView ();
		}
		transform.rotation = Quaternion.Slerp (transform.rotation, targetRot, 0.1f);
		if (changing) {
			
			transform.position = Vector3.Lerp (transform.position, targetPos, WaitingOfCamera);
			if((targetPos-transform.position).magnitude<0.25f)
			{
				changing = false;
				WhenPerspectiveChangeFinished ();

			}
		
		}
		CameraSmoothFollow ();
	}

	public void ChangeView()
	{
		changing = true;

		if (sideView) {



			sideView = false;
			TopPos = new Vector3 (transform.position.x, TopPos.y, TopPos.z);
			targetPos = TopPos;
			ChangeCameraRotation (TopCameraRot);




		
		} else {
			sideView = true;
			SidePos = new Vector3 (transform.position.x, SidePos.y, SidePos.z);
			targetPos = SidePos;
			ChangeCameraRotation (SideCameraRot);
		}
		
	}
	void ChangeCameraRotation(float cameraRotation)
	{
		targetRot = Quaternion.Euler (cameraRotation, 0f, 0f);

	}


	void CameraSmoothFollow()
	{
		if (!changing) {
			if (player.transform.position.x < cameraRightLimit && player.transform.position.x > cameraLeftLimit) {
				transform.position = new Vector3 (player.transform.position.x, transform.position.y, transform.position.z);
			}
		}

	}


	public void WhenPerspectiveChangeFinished()//perpektif değişimi bitince çağırılan mesaage'ım
	{
		player.GetComponent<UnitPlayer> ().CorrectionOfPerspectiveChange ();

		if (sideView) {
			player.transform.position = new Vector3 (player.transform.position.x, player.transform.position.y, player.GetComponent<UnitPlayer> ().bottomZ);
		} else if (!sideView) {
			player.transform.position = new Vector3 (player.transform.position.x, player.GetComponent<UnitPlayer> ().bottomY, player.transform.position.z);
		}

	}
	public void WhenPerspectiveChangeStarted() //perspektif değişimi başladığında çağırılan message'ım
	{
		
	}
}
