using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class VirtualJoystickAndac : MonoBehaviour,IDragHandler,IPointerUpHandler,IPointerDownHandler {

	private Image bcgdImage;
	private Image joystickImage;
	public Vector3 inputVector;
	public bool tutorial = false;
	public bool tutorial2 = false;

	void Awake()
	{
		#if UNITY_STANDALONE
		transform.parent.gameObject.SetActive(false);

		#elif UNITY_ANDROID
		transform.parent.gameObject.SetActive(true);
		#endif

	}

	void Start()
	{
		bcgdImage = GetComponent<Image> ();
		joystickImage = transform.GetChild (0).GetComponent<Image> ();
	}

	public virtual void OnDrag(PointerEventData ped)
	{
		Vector2 pos;
		if(RectTransformUtility.ScreenPointToLocalPointInRectangle(bcgdImage.rectTransform,ped.position,ped.pressEventCamera,out pos))
			{

				pos.x=(pos.x/bcgdImage.rectTransform.sizeDelta.x);
				pos.y=(pos.y/bcgdImage.rectTransform.sizeDelta.y);

			inputVector=new Vector3(pos.x*2-1,0,pos.y*2-1);

				inputVector=(inputVector.magnitude>1.0f)?inputVector.normalized:inputVector;
//			Debug.Log (inputVector);


				//joystick resim hareketi
				joystickImage.rectTransform.anchoredPosition=new Vector3(inputVector.x*(bcgdImage.rectTransform.sizeDelta.x/3),inputVector.z*(bcgdImage.rectTransform.sizeDelta.y/3));

			}
	}
	public virtual void OnPointerDown(PointerEventData ped)
	{
		OnDrag (ped);
		tutorial2 = true;
	}
	public virtual void OnPointerUp(PointerEventData ped)
	{
		tutorial = true;
		inputVector = Vector3.zero;
		joystickImage.rectTransform.anchoredPosition = Vector3.zero;
	}

}
