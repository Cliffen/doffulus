using UnityEngine;
using System.Collections;

public class AxisRestrict : MonoBehaviour {

	public GameObject target = null;
	public bool restrictX = false;
	public bool restrictY = false;
	public bool restrictZ = false;

	// Objects starting position
	protected Vector3 origPos = new Vector3( 0.0f, 0.0f, 0.0f );
	protected Quaternion origRot = new Quaternion( 0.0f, 0.0f, 0.0f, 0.0f );
	protected bool bound = false;
	protected bool freed = false;

	// Store starting position
	void Start () {
		origPos = target.transform.position;
		origRot = target.transform.rotation;
	}

	// If bound, only move along unrestrcited axis
	void Update() {
		Vector3 newPos = target.transform.position;
		if ( restrictX && bound ) {
			newPos.x = origPos.x;
		}
		if ( restrictY && bound ) {
			newPos.y = origPos.y;
		}
		if ( restrictZ && bound ) {
			newPos.z = origPos.z;
		}
		target.transform.position = newPos;

		if ( bound ) {
			target.transform.rotation = origRot;
		}
	}

	void OnTriggerEnter( Collider other ) {
		if ( other == target.collider && !freed ) {
			bound = true;
		}
	}

	void OnTriggerStay( Collider other ) {
		if ( other == target.collider && !freed ) {
			bound = true;
		}
	}

	void OnTriggerExit( Collider other ) {
		if ( other == target.collider && !freed ) {
			bound = false;
			freed = true;
		}
	}
}
