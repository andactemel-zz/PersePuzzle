using UnityEngine;
using System.Collections;

public class ProjectileEnemy1 : MonoBehaviour {

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

		if (CM.sideView) {
		
			Destroy (gameObject);
		}
	}

	public void Fire(){ //mermiye oldğu perspektive göre hızını veren fonksyon
		if (!CM.sideView) {
			
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
