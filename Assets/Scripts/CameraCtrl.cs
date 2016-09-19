using UnityEngine;
using System.Collections;

public class CameraCtrl : MonoBehaviour {

	public GameObject cameraTarget;     // object to look at or follow
    public float distance = 6.0f;       // camera distance between player
    public float cameraHeight = 2.0f;	// height of camera adjustable
    public float cameraSpeed = 4.0f;    // camere following speed

    Vector3 Pos;

	void Start()
	{
		Screen.SetResolution (800, 1280, true);
	//	Screen.SetResolution (Screen.width, (Screen.width / 16) * 9, true); 
	}

    void Update()
    {
        Pos = new Vector3(cameraTarget.transform.position.x, cameraHeight, cameraTarget.transform.position.z - distance);
        this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, Pos, cameraSpeed * Time.deltaTime);
    }
}
