using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
//using System.Collections;

public class AttackCtrl : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {

    private Image joystickImage;
	
	private void Start () {
        joystickImage = GetComponent<Image>();
	}

    public virtual void OnPointerDown(PointerEventData ped)
    {
        Debug.Log("Attack Touch!!");
    }

    public virtual void OnPointerUp(PointerEventData ped)
    {

    }
	
}
