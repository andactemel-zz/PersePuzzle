using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;
public class UnitPlayer : Unit {
	public GameObject projectile;// mermi prefabının tutulduğu değişken
	public Vector3 targetRot;// karakter yönünü ayarlarken hedef oryantasyonun euler hali
	public float rotationSpeed=0.1f;//karakterin yüzünü dönme hızı(0 ile 1 arasında)
	public float projectileOrientation=0f;// karakter ateş ettiğinde merminin yönünü belirleyen y konumunda ki euler açısı
	public int characterOrientaion=0;//0=sağa bakıyor, 1=sağ alta,2=alta,3=sol alta,4=sola,5=sol üste,6=üste,7=sağ üste
	public Animator alienAnim;
	public float fireRateTime=2f;
	float fireStartTime;
	bool fired=false;
	public GameObject controlForBugs;//perspektif değişiminde raycast attığımız obje
	public VirtualJoystickAndac VJA;
	public bool JumpForVirtual=false;
	public bool perspectiveStart=true;
	public GameObject Rating;
	public GameObject Sound;



	// Use this for initialization
	public virtual void Start () {
		
		Sound = GameObject.FindGameObjectWithTag ("Sound");
		alienAnim = transform.FindChild ("alien character").GetComponent<Animator> ();
		StartCoroutine (CharacterPositionControl ());

		Rating.GetComponent<RatingForTime>().StartTimer();


		base.Start ();
	}
	
	// Update is called once per frame
	public virtual void Update () {


//		Debug.Log (control.isGrounded);
		//Debug.Log (control.isGrounded + " yerde");

		if (control.isGrounded&&!JumpForVirtual) { // yerdeyken hareket kontrolleri


			// karakterin yön vectorleri alınıyopr
			if (sideView) { 



				#if UNITY_ANDROID

				move.x = VJA.inputVector.x*speed;
				#elif UNITY_STANDALONE
				move.x = Input.GetAxis ("Horizontal")*speed;


				#endif
				//side viewda z de hareket etmemesini sağlayan kod
				move.z=0f;

                   
			}
			 if (!sideView) {
				
				#if UNITY_ANDROID
				move.x = VJA.inputVector.x*speed;
				move.z = VJA.inputVector.z*speed;
				#elif UNITY_STANDALONE
				move.x = Input.GetAxis ("Horizontal")*speed;
				move.z = Input.GetAxis ("Vertical")*speed;
				#endif
			}
			//move.y = 0f;
			move.y -= gravity * Time.deltaTime;
			//move = transform.TransformDirection (move);

			//düşerken olusan bugı düzelten kod
			if (move.y < -2f) {
				move.y = -1f;
			}

			//zıplanırsa karakterin zıplama vektörü alınıyor
			if (Input.GetButton ("Jump")) {

				//Debug.Log ("aa");
				Jump ();

			}

		} else { //karakter havada iken yön vektörleri alınıyor
			RaycastHit hit;
			//Karekterkafayı carpar ise tavana yapısmasını engelleyen raycast
			if(Physics.Raycast(transform.position,Vector3.up,out hit,1.5f))
				{
				Debug.Log (hit.transform.gameObject.name);
				move.y=-gravity*Time.deltaTime;
				}


			//karakterin yön vectorleri alınıyopr
			if (sideView) {
				#if UNITY_ANDROID
				move.x = VJA.inputVector.x*speed;
				move.z = 0f;
				#elif UNITY_STANDALONE
				move.x = Input.GetAxis ("Horizontal")*speed;
				#endif
			}
			if (!sideView) {
				#if UNITY_ANDROID
				move.x = VJA.inputVector.x*speed;
				move.z = VJA.inputVector.z*speed;
				#elif UNITY_STANDALONE

				move.x = Input.GetAxis ("Horizontal")*speed;
				move.z = Input.GetAxis ("Vertical")*speed;
				#endif
			}
		//	move = transform.TransformDirection (move);


			#if UNITY_ANDROID
			if (sideView&&!CM.changing) //karakter yan bakıştaysa gravity vektörü uygulanıyor
			{
//				Debug.Log("buraya girmek lazım");
				move.y -= gravity * Time.deltaTime;
				JumpForVirtual=false;

			}
			else//karakter yan bakışta değilse gravity si kaldırılıyor
				move.y = -9.8f;//eskiden sıfırdı


			#elif UNITY_STANDALONE

			if (sideView&&!CM.changing) //karakter yan bakıştaysa gravity vektörü uygulanıyor
				move.y -= gravity * Time.deltaTime;
			else//karakter yan bakışta değilse gravity si kaldırılıyor
				move.y = -9.8f;//eskiden sıfırdı

			#endif
		}


		if (CM.changing) {
			move.y = 0f;
		}



		if(Input.GetKeyDown(KeyCode.E)) // perpektif değiştirme tuşu algılanıyor
		{
			ChangePerspective ();
		}


		if ((Time.time - fireStartTime > fireRateTime) && fired) {
		
			fired = false;		
		
		}

		if (Input.GetButtonDown ("Fire1")) { //ateş tuşuna basılınca girilen if
		
			Fire ();
		
		}
		AdjustCharacterRotation ();

		//move.x = VJA.inputVector.x;
		//Debug.Log( VJA.inputVector.x+" and  "  + move.x);



		base.Update ();


	}

	public virtual void AdjustPositionofCharacter() // perpektif değişirken karakterin gideceği pozisyonu hesaplıyor
	{
		
		Vector3 temp = transform.position;
		//Debug.Log (temp);
		if(sideView)
			targetPos = new Vector3 (temp.x, temp.z+2.5f, bottomZ);
		else
			targetPos = new Vector3 (temp.x, bottomY, temp.y-2.5f);

		base.AdjustPositionofCharacter ();
	}

	public void CreateProjectile() // ateş tuşuna basıldığında mermi yaratan fonksyon
	{


//		Debug.Log ("CreateProjectile Start");
		Sound.GetComponent<SoundManager>().FireSound();
		alienAnim.SetTrigger ("Attack");
		fired = true;
		fireStartTime = Time.time;
		Vector3 temp=Vector3.zero;//merminin oluşturulacağı yeri belirleyen vector
		#if UNITY_STANDALONE

		if (characterOrientaion == 0) {
			temp=transform.position + Vector3.right;
		} else if (characterOrientaion == 1) {
			temp = transform.position + (Vector3.right + Vector3.back).normalized;
		} else if (characterOrientaion == 2) {
			temp = transform.position + Vector3.back;
		} else if (characterOrientaion == 3) {
			temp = transform.position + (Vector3.left + Vector3.back).normalized;
		} else if (characterOrientaion == 4) {
			temp = transform.position + Vector3.left;
		} else if (characterOrientaion == 5) {
			temp = transform.position + (Vector3.left + Vector3.forward).normalized;
		} else if (characterOrientaion == 6) {
			temp = transform.position + Vector3.forward;
		} else if (characterOrientaion == 7) {
			temp = transform.position + (Vector3.forward + Vector3.right).normalized;
		} 
		#elif UNITY_ANDROID

		if(sideView)
		{
			if (characterOrientaion == 0) {
				temp=transform.position + Vector3.right;
			} else if (characterOrientaion == 4) {
				temp = transform.position + Vector3.left;
			}
		}
		else
		{
			temp=transform.position+transform.right;

		}
		#endif
		GameObject.Instantiate (projectile, temp, Quaternion.Euler(new Vector3(0f,projectileOrientation,0f)));
	}


	public void AdjustCharacterRotation()//karakterin rotationını gittiği yöne göre ayarlıyor
	{
		
		if (!CM.changing) {
			
			if (sideView) {
				
				#if UNITY_STANDALONE
				if (move.x > 0f) {
					//Debug.Log ("SideView'da Sağa gidiyorum "+ move.x);
					targetRot = Vector3.zero;
					projectileOrientation = 0f;
					characterOrientaion = 0;
					alienAnim.SetBool ("Walking", true);
			
				} else if (move.x < 0f) {
					//Debug.Log ("SideView'da Sola gidiyorum");
					targetRot = new Vector3 (0f, 180f, 0f);
					projectileOrientation = 180f;
					characterOrientaion = 4;
					alienAnim.SetBool ("Walking", true);
				} else {
					alienAnim.SetBool ("Walking", false);
					//Debug.Log ("SideView'da duruyorum "+move.x );
				}
				#elif UNITY_ANDROID

				if (move.x > 0f) {
					//Debug.Log ("SideView'da Sağa gidiyorum "+ move.x);
					targetRot = Vector3.zero;
					projectileOrientation = 0f;
					characterOrientaion = 0;
					alienAnim.SetBool ("Walking", true);

				} else if (move.x < 0f) {
					//Debug.Log ("SideView'da Sola gidiyorum");
					targetRot = new Vector3 (0f, 180f, 0f);
					projectileOrientation = 180f;
					characterOrientaion = 4;
					alienAnim.SetBool ("Walking", true);
				} else {
					alienAnim.SetBool ("Walking", false);
					//Debug.Log ("SideView'da duruyorum "+move.x );
				}


				#endif



			} else {
				#if UNITY_STANDALONE
				if (move.x > 0f && move.z > 0f) {
					//Debug.Log ("topView'da Sağ yukarı gidiyorum");
					targetRot = new Vector3 (0f, 315f, 0f);
					projectileOrientation = 315f;
					characterOrientaion = 7;
					alienAnim.SetBool ("Walking", true);
				} else if (move.x > 0f && move.z < 0f) {
					//Debug.Log ("topView'da Sağ aşağı gidiyorum");
					targetRot = new Vector3 (0f, 45f, 0f);
					projectileOrientation = 45f;
					characterOrientaion = 1;
					alienAnim.SetBool ("Walking", true);
				} else if (move.x > 0f && move.z == 0f) {
					//Debug.Log ("topView'da Sağa gidiyorum");
					targetRot = new Vector3 (0f, 0f, 0f);
					projectileOrientation = 0f;
					characterOrientaion = 0;
					alienAnim.SetBool ("Walking", true);
				} else if (move.x == 0f && move.z < 0f) {
					//Debug.Log ("topView'da aşağı gidiyorum");
					targetRot = new Vector3 (0f, 90f, 0f);
					projectileOrientation = 90f;
					characterOrientaion = 2;
					alienAnim.SetBool ("Walking", true);
				} else if (move.x < 0f && move.z < 0f) {
					//Debug.Log ("topView'da sol aşağı gidiyorum");
					targetRot = new Vector3 (0f, 145f, 0f);
					projectileOrientation = 145f;
					characterOrientaion = 3;
					alienAnim.SetBool ("Walking", true);
				} else if (move.x < 0f && move.z == 0f) {
					//Debug.Log ("topView'da sola gidiyorum");
					targetRot = new Vector3 (0f, 180f, 0f);
					projectileOrientation = 180f;
					characterOrientaion = 4;
					alienAnim.SetBool ("Walking", true);
				} else if (move.x < 0f && move.z > 0f) {
					//Debug.Log ("topView'da sol yukarı gidiyorum");
					targetRot = new Vector3 (0f, 225f, 0f);
					projectileOrientation = 225f;
					characterOrientaion = 5;
					alienAnim.SetBool ("Walking", true);
				} else if (move.x == 0f && move.z > 0f) {
					//Debug.Log ("topView'da yukarı gidiyorum");
					targetRot = new Vector3 (0f, 270f, 0f);
					projectileOrientation = 270f;
					characterOrientaion = 6;
					alienAnim.SetBool ("Walking", true);
				} else {
					//Debug.Log ("TopView'da duruyorum");
					alienAnim.SetBool ("Walking", false);
				}
				#elif UNITY_ANDROID



				Vector3 temp=move;
				temp.y=0f;

				if(temp.magnitude==0)
				{
					
				}
				else
				{
					
					temp.Normalize();
					//Debug.Log(Vector3.Angle(Vector3.right,temp));
					float angle;
					if(temp.z>0)
					{
						angle=360f-Vector3.Angle(Vector3.right,temp);
						//Debug.Log("y 0 dan büyükken "+ angle);
						projectileOrientation=angle;
						targetRot=new Vector3(0f,360f-Vector3.Angle(Vector3.right,temp),0f);

					}else{
						angle=Vector3.Angle(Vector3.right,temp);
						projectileOrientation=angle;
						targetRot=new Vector3(0f,Vector3.Angle(Vector3.right,temp),0f);
						//Debug.Log("y 0 dan küçükken "+ angle);
					}



				}
				if(projectileOrientation>270f|| projectileOrientation <90f)
				{
					characterOrientaion=0;
				}
				else
				{
					characterOrientaion=4;
				}




			
				#endif


			}

		} else {//perspektif değişirken karakterin rotation'nını ayarlaryan kod
			//Debug.Log(targetRot.y);
			if (sideView) {
				#if UNITY_STANDALONE
				if (characterOrientaion==6 || characterOrientaion==7 || characterOrientaion==0 || characterOrientaion==1  ) {
					targetRot = Vector3.zero;
				} else {
					targetRot = targetRot = new Vector3 (0f, 180f, 0f);
				}
				#elif UNITY_ANDROID

			

					
			//	Debug.Log (characterOrientaion);

				if (characterOrientaion==0) {
					targetRot = Vector3.zero;
				} else {
					
					targetRot = targetRot = new Vector3 (0f, 180f, 0f);
				}
				
				#endif
			} 

		}




		#if UNITY_STANDALONE
		transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.Euler (targetRot), rotationSpeed);
		#elif UNITY_ANDROID


		transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.Euler (targetRot), rotationSpeed);
		#endif

	}

	public void CorrectionOfPerspectiveChange()//Perspektif değişimi sırasındaki hataları düzelten yer
	{
		/*

		//Debug.Log ("correction for player");
		controlForBugs.transform.position = new Vector3 (transform.position.x, controlForBugs.transform.position.y, transform.position.z);
		RaycastHit firstObject;
		if(Physics.Raycast( controlForBugs.transform.position, transform.position - controlForBugs.transform.position,out firstObject))
			{
		//	Debug.Log ("raycast attı vurdu "+ firstObject.collider.gameObject.name);

				if(firstObject.collider.gameObject.tag!=tag ) // carakter bir şeyin için de kaldıysa çalışan yer
				{
				if(firstObject.collider.gameObject.tag!="UseButton")
				{
		//		Debug.Log ("yerini düzeltti");
				Debug.Log (firstObject.collider.transform.position.y);
				transform.position=new Vector3(transform.position.x,firstObject.point.y+0.5f,transform.position.z);
				
				}
			}

			}

		*/


	}

	public void Jump()
	{
//		Debug.Log ("Jumpıjn içinde");
		if (sideView ) {
//			Debug.Log ("move y değiştirildi");
			Sound.GetComponent<SoundManager>().JumpSound();
			move.y = jumpSpeed;

		}

	}

	public void Fire()
	{
		if (!CM.changing && !fired) {
		
			CreateProjectile ();
		
		}

	}

	public void ChangePerspective()
	{
		Sound.GetComponent<SoundManager> ().PerspectiveSound ();
		sideView=!sideView;
		AdjustPositionofCharacter ();

	}


	IEnumerator CharacterPositionControl() // 2 sa de bir karakterin yerini düzelten kod
	{
		
		yield return new WaitForSeconds(2f);
		if (!CM.changing) {
			if (sideView) {
				transform.position = new Vector3 (transform.position.x, transform.position.y, bottomZ);
			} else if (!sideView) {
				transform.position = new Vector3 (transform.position.x, bottomY, transform.position.z);
			}
		}
		StartCoroutine (CharacterPositionControl ());

	}

	public void Die()
	{
		Sound.GetComponent<SoundManager> ().DeadSound ();

	}





}
