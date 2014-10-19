using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TrashIt : MonoBehaviour {

	// Amount of time an object must stay before being trashed
	public uint trashTimeout = 100;

	protected Dictionary<string, int> contentNames = new Dictionary<string, int>();
	protected uint noTrashed = 0;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter( Collider other ) {
		contentNames.Add( other.name, 0 );
	}

	void OnTriggerStay( Collider other ) {
		string id = other.name;
		if ( contentNames.ContainsKey( id ) ) {
			// If timeout period passed, trash item
			if ( contentNames[ id ] > trashTimeout ) {
				Destroy( other.gameObject, 2.0f );
				contentNames.Remove( id );
				noTrashed++;
				if ( gameObject.GetComponent<ParticleSystem>() )
					gameObject.GetComponent<ParticleSystem>().Play();
			}
			// Increment objects counter
			contentNames[ id ] = contentNames[ id ]++;
		} else {
			// If not in dict, add
			contentNames.Add( id, 0 );
		}
	}
}
