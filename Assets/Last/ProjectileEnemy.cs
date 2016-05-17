using UnityEngine;
using System.Collections;

public class ProjectileEnemy : MonoBehaviour {
	protected Rigidbody rigid;
	public CameraMovement CM;
	public float projectileSideForce = 10f; // merminin atılma hızı
	public bool interrupted = false; //perpektif değişmiş ama daha mermi fizği ayarlanmamışsa true oluyor. perpektif ve fizik ayarlıysa true
	public Vector3 tempVelocity;//perpektif değişirken merminin hızını tutan değişken
	public Vector3 targetPos; //perpektif değişirken merminin olması gereken yeri tutan değişken
	public float projectileBlowTime=3f;//merminin kaç saniye hayatta kalacağını belirliyor
	// Use this for initialization
	void Start () {
		CM = Camera.main.GetComponent<CameraMovement>();
		rigid = GetComponent<Rigidbody> ();

		Fire ();
		StartCoroutine (DestroyProjectile ());

	}

	// Update is called once per frame
	void FixedUpdate () {
		//Debug.Log (" velocity=  " + rigid.velocity);
		//Debug.Log (" tempVelecity= " + tempVelocity);

		if (CM.changing) {
			if (interrupted == false) { //perpektif değişirken merminin özellikleri tutulan yer
				Vector3 tempPos = transform.position;
				targetPos = new Vector3 (tempPos.x, tempPos.z, tempPos.y);
				interrupted = true;
				tempVelocity = rigid.velocity;

			}

			rigid.isKinematic = true;//perspektif değişirken merminin fiziğini kapatoyr
			transform.position = Vector3.Lerp (transform.position, targetPos, 0.5f);

		} else {
			rigid.isKinematic = false;//perspektif değişirken merminin fiziğini açıyor
			if (interrupted == true) {//perspektif değişimitamamlanmış ama fizik mermiye aktarılmamışsa girilen if
				interrupted = false;
				if (CM.sideView) {
					Physics.gravity = new Vector3 (0f, -9.8f, 0f);
					rigid.velocity = tempVelocity;
					rigid.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;

				} else {
					//Physics.gravity = Vector3.zero;
					tempVelocity = new Vector3 (tempVelocity.x, 0f, tempVelocity.z);
					rigid.velocity = tempVelocity;
					rigid.constraints =  RigidbodyConstraints.FreezeRotation;

				}
			}



		}
	}

	public void Fire(){ //mermiye oldğu perspektive göre hızını veren fonksyon
		if (CM.sideView) {
			Physics.gravity = new Vector3 (0f, -9.8f, 0f);
			rigid.velocity = transform.forward * projectileSideForce;
		} else {
			//Physics.gravity = Vector3.zero;
			rigid.velocity = transform.forward * projectileSideForce;

		}
	}

	IEnumerator DestroyProjectile()
	{
		yield return new WaitForSeconds (projectileBlowTime);
		Destroy (gameObject);

	}

	void OnCollisionEnter(Collision other) {
	
		if (other.gameObject.tag == "Player") {
		
			Debug.Log ("playera vurdum ");
			other.transform.GetComponent<UnitPlayer> ().enabled = false;
			other.transform.FindChild ("alien character").GetComponent<Animator> ().SetBool ("Die",true);
		
		}
	
	}


}
