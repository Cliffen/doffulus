using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TrashIt : MonoBehaviour {

	// Amount of time an object must stay before being trashed
	public int trashTimeout = 10;
	public ParticleSystem stinky = null;

	protected Dictionary<string, int> contentNames = new Dictionary<string, int>();
	protected uint noTrashed = 0;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter( Collider other ) {
		string id = other.name;
		if ( !contentNames.ContainsKey( id ) ) {
			contentNames.Add( id, 0 );
		}

		AxisRestrict target = other.gameObject.GetComponentInParent<AxisRestrict>();
		if ( target != null ) {
			target.setInTrash( true );
		}
	}

	void OnTriggerStay( Collider other ) {
		string id = other.name;
		if ( contentNames.ContainsKey( id ) ) {
			// If halfway through timeout, show particles
			if ( stinky && contentNames[ id ] > trashTimeout/2 ) {
				stinky.Play();
			}
			// If timeout period passed, trash item
			if ( contentNames[ id ] > trashTimeout ) {
				other.gameObject.SetActive(false);
				contentNames.Remove( id );
				noTrashed++;

				return;
			}
			// Increment objects counter
			contentNames[ id ] = contentNames[ id ] + 1;
		}
	}

	void OnTriggerExit( Collider other ) {
		AxisRestrict target = other.gameObject.GetComponentInParent<AxisRestrict>();
		if ( target != null ) {
			target.setInTrash( false );
		}
	}
}
