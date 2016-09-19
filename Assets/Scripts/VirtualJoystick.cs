using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class VirtualJoystick : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    private Image bgImage;
    private Image joystickImage;
    private Vector3 inputVector;

    private PlayerCtrl pCtrl;

    private bool isPressed;
    private float pressedTime;

    private void Start()
    {
		Screen.SetResolution (800, 1280, true);
        bgImage = GetComponent<Image>();
        joystickImage = transform.GetChild(0).GetComponent<Image>();
        pCtrl = GameObject.Find("KnightA").GetComponent<PlayerCtrl>();
    }

    public virtual void OnDrag(PointerEventData ped)
    {
        //Debug.Log(ped.clickCount);
        Vector2 pos;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(bgImage.rectTransform
                                                                    , ped.position
                                                                    , ped.pressEventCamera
                                                                    , out pos))
        {
            pos.x = (pos.x / bgImage.rectTransform.sizeDelta.x);
            pos.y = (pos.y / bgImage.rectTransform.sizeDelta.y);

            inputVector = new Vector3(pos.x * 2 + 1, 0, pos.y * 2 - 1);
            inputVector = (inputVector.magnitude > 1.0f) ? inputVector.normalized : inputVector;

            // Move Joystick Image
            joystickImage.rectTransform.anchoredPosition =
                new Vector3(inputVector.x * (bgImage.rectTransform.sizeDelta.x / 3)
                    , inputVector.z * (bgImage.rectTransform.sizeDelta.y / 3));
        }
        
        
    }

    void Update()
    {
        if (!this.isPressed)
        {
           // pCtrl.anim.SetBool("Attack", false);
        }
        if (Time.realtimeSinceStartup - this.pressedTime > 0.5f)
        {
            //Debug.Log("Handle long tap");
            this.isPressed = false;
            pCtrl.anim.SetBool("Attack1", false); 
			pCtrl.anim.SetBool("Attack2", false); 
        }
    }

    public virtual void OnPointerDown(PointerEventData ped)
    {
        OnDrag(ped);
        this.isPressed = true;
        this.pressedTime = Time.realtimeSinceStartup;

		if (ped.IsPointerMoving())
		{
		//	if (ped.clickCount % 2 == 0) 
		//		pCtrl.anim.SetBool("Attack2", false);
		//	else
				pCtrl.anim.SetBool("Attack1", false);
		}
		else
		{
		//	if (ped.clickCount % 2 == 0) 
		//		pCtrl.anim.SetBool("Attack2", true);
		//	else
				pCtrl.anim.SetBool("Attack1", true);
		}
    }

	public virtual void OnPointerUp(PointerEventData ped)
	{        
        inputVector = Vector3.zero;
		joystickImage.rectTransform.anchoredPosition = Vector3.zero;
        //Debug.Log(ped.clickCount);
        
        this.isPressed = false;
        //pCtrl.anim.SetBool("Attack", false);
    }

	public float Horizontal()
	{
		if (inputVector.x != 0)
			return inputVector.x;
		else
			return Input.GetAxis ("Horizontal");
	}

	public float Vertical()
	{
		if (inputVector.z != 0)
			return inputVector.z;
		else
			return Input.GetAxis ("Vertical");
	}			
}
