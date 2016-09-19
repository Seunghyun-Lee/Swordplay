using UnityEngine;
using System.Collections;

public enum PlayerState
{
    Alert,
    Attack1,
    Attack2,
    Attack3,
    Block,
    Damage,
    Dash,
    Die1,
    Die2,
    Idle,
    Jump,
    Move,
    Move_l,
    Move_R,
    Sit,
    Victory
}

public class PlayerCtrl : MonoBehaviour {

	public Animator anim;
    public PlayerState PS;

    public Vector3 lookDirection;
    public float speed = 0f;
    public float moveSpeed = 6f;
    public float attackSpeed = 12f;

    public float findRange = 10.0f;
    public float damage = 20.0f;

    public Transform player;
    public VirtualJoystick joystick;
    

	void Start () {
        player = GameObject.Find("PlayerCtrl").transform;
		anim = GetComponent<Animator> ();
	}

    void Update () {
        
//		if (Application.platform == RuntimePlatform.Android ||
//		    Application.platform == RuntimePlatform.IPhonePlayer) {
			VirtualpadInput ();
//		} else {
//			KeyboardInput ();
//		}
        LookUpdate();
	}
    
    void LookUpdate()
    {
        Quaternion R = Quaternion.LookRotation(lookDirection);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, R, 2.0f);
        
       // transform.Translate(Vector3.forward * speed * Time.deltaTime);
		transform.Translate(Vector3.forward * speed * Time.deltaTime, Camera.main.transform);
    }

    void KeyboardInput()
    {
        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");
        
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow) || 
            Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow))
        {
            lookDirection = v * Vector3.forward + h * Vector3.right;
            speed = moveSpeed;
            
            anim.SetFloat("Speed", v);
            anim.SetFloat("Direction", h);
        }
    }

    void VirtualpadInput()
    {
        Vector3 dir = Vector3.zero;
        dir.x = joystick.Vertical();
        dir.z = joystick.Horizontal();
        
        if (dir.x > 0.5 || dir.x < -0.5 || dir.z > 0.5 || dir.z < -0.5)
        {			
            lookDirection = dir.x * Vector3.forward + dir.z * Vector3.right;
            speed = moveSpeed;
            dir.Normalize();
        }
        else
        {
            speed = 0;
        }
        
        anim.SetFloat("Speed", dir.x);
        anim.SetFloat("Direction", dir.z);
    }

}
