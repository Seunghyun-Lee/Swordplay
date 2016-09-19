using UnityEngine;
using System.Collections;

public class MyGizmos : MonoBehaviour {

	public enum Gizmotype {sphere, wire}

	public Gizmotype _type = Gizmotype.sphere;
	public Color _color = Color.yellow;
	public float _radius = 1.0f;

	void OnDrawGizmos()
	{
		Gizmos.color = _color;

		switch(_type)
		{
		case Gizmotype.sphere:
			Gizmos.DrawSphere(transform.position, _radius);
			break;
		case Gizmotype.wire:
			Gizmos.DrawWireSphere(transform.position, _radius);
			break;
		}
	}
}
