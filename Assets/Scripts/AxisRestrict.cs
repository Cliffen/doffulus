using UnityEngine;
using System.Collections;

public class AxisRestrict : MonoBehaviour {

	public GameObject target = null;
	// Direction which to restrict a movement to
	// ie 0, 1, 0 will allow the object to only move in the positive Y direction from its starting point
	public Vector3 restrictDir = new Vector3( 0.0f, 0.0f, 0.0f );

	// Objects starting position
	protected bool restrictX = false;
	protected bool restrictY = false;
	protected bool restrictZ = false;
	protected Vector3 origPos = new Vector3( 0.0f, 0.0f, 0.0f );
	protected Quaternion origRot = new Quaternion( 0.0f, 0.0f, 0.0f, 0.0f );
	protected bool bound = false;
	protected bool freed = false;
	[HideInInspector]
	public bool inTrash = false;

	void Start () {
		// translate restrict vector into basic bools for quick logic
		restrictX = ( restrictDir.x != 0.0 ) ? false : true;
		restrictY = ( restrictDir.y != 0.0 ) ? false : true;
		restrictZ = ( restrictDir.z != 0.0 ) ? false : true;

		// Store starting position and rotation
		origPos = target.transform.position;
		origRot = target.transform.rotation;
	}

	// If bound, only move along unrestrcited axis
	void Update() {
		Vector3 newPos = target.transform.position;
		// On 'R' reset objects
		if ( Input.GetKeyDown( "p" ) ) {
			resetObject();
			return;
		}

		// If unbound and ungrabbed, add gravity
		GrabbableObject grabbee = gameObject.GetComponentInChildren<GrabbableObject>();
		if ( freed && grabbee != null ) {
			if ( !grabbee.IsGrabbed() ) {
				grabbee.rigidbody.useGravity = true;
			}
		}

		// Restrict motion along each axis if set
		// =======================================
		// X axis is restricted and target is still inside of collider bounds
		if ( restrictX && bound ) {
			newPos.x = origPos.x;
		} else if ( bound ) {
			// If X axis is bound positively as indicated in direction vector,
			// position can only move positively w.r.t. its original position.
			// Else if bound negatively, can only move negatively
			if ( restrictDir.x > 0.0 && newPos.x < origPos.x ) {
				newPos.x = origPos.x;
			} else if ( restrictDir.x < 0.0 && newPos.x > origPos.x ) {
				newPos.x = origPos.x;
			}
		}
		// Y axis is restricted and target is still inside of collider bounds
		if ( restrictY && bound ) {
			newPos.y = origPos.y;
		} else if ( bound ) {
			// If Y axis is bound positively as indicated in direction vector,
			// position can only move positively w.r.t. its original position.
			// Else if bound negatively, can only move negatively
			if ( restrictDir.y > 0.0 && newPos.y < origPos.y ) {
				newPos.y = origPos.y;
			} else if ( restrictDir.y < 0.0 && newPos.y > origPos.y ) {
				newPos.y = origPos.y;
			}
		}
		// Y axis is restricted and target is still inside of collider bounds
		if ( restrictZ && bound ) {
			newPos.z = origPos.z;
		} else if ( bound ) {
			// If Z axis is bound positively as indicated in direction vector,
			// position can only move positively w.r.t. its original position.
			// Else if bound negatively, can only move negatively
			if ( restrictDir.z > 0.0 && newPos.z < origPos.z ) {
				newPos.z = origPos.z;
			} else if ( restrictDir.z < 0.0 && newPos.z > origPos.z ) {
				newPos.z = origPos.z;
			}
		}
		// Set position to altered one
		target.transform.position = newPos;

		// If still bound, don't rotate or add velocity
		if ( bound ) {
			target.transform.rotation = origRot;
			target.rigidbody.velocity = new Vector3( 0.0f, 0.0f, 0.0f );
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

	public void setInTrash( bool state ) {
		inTrash = state;
	}

	public bool isInTrsah() {
		return inTrash;
	}

	public void resetObject() {
		bound = false;
		freed = false;
		target.rigidbody.useGravity = false;
		target.transform.position = origPos;
		target.transform.rotation = origRot;
		target.rigidbody.velocity = new Vector3( 0.0f, 0.0f, 0.0f );
	}
}
