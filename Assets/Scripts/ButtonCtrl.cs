using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class ButtonCtrl : MonoBehaviour, IPointerUpHandler, IPointerDownHandler 
{
	private PlayerCtrl pCtrl;

	private bool isPressedDefence;
	private float timePressedDefence;

	private void Start () {
		pCtrl = GameObject.Find("KnightA").GetComponent<PlayerCtrl>();
	}
	
	void Update(){
		if (isPressedDefence) {
			//this.timePressedDefence += Time.deltaTime;
		}

		if (Time.realtimeSinceStartup - this.timePressedDefence > 0.5f)
		{			
			//this.isPressedDefence = false;
			//pCtrl.anim.SetBool("Defence", false); 
		}
	}

	public virtual void OnPointerDown(PointerEventData ped){		
		this.isPressedDefence = true;
		this.timePressedDefence = Time.realtimeSinceStartup; 
		pCtrl.anim.SetBool ("Defence", true);
	}

	public virtual void OnPointerUp(PointerEventData ped){
		this.isPressedDefence = false;
		this.timePressedDefence = 0.0f;
		pCtrl.anim.SetBool ("Defence", false);
	}

	public void pressDefence() {
		this.isPressedDefence = true;
	}
}
