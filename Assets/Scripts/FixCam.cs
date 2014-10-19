using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FixCam : MonoBehaviour {

	public List<Vector3> positions = new List<Vector3>();
	public bool animate = false;

	// Init
	void Start () {
		// If user provides no positions, leave camera at default
		// else set camera position to first position in user's list
		if ( positions.Count == 0 ) {
			positions.Add( transform.position );
		} else {
			transform.position = positions[0];
		}
	}

	// On number press, move position to given point
	void Update () {
		if ( Input.GetKeyDown( "1" ) && positions.Count >= 1 ) {
			setPosition( 1 );
		} else if ( Input.GetKeyDown( "2" ) && positions.Count >= 2 ) {
			setPosition( 2 );
		} else if ( Input.GetKeyDown( "3" ) && positions.Count >= 3 ) {
			setPosition( 3 );
		} else if ( Input.GetKeyDown( "4" ) && positions.Count >= 4 ) {
			setPosition( 4 );
		} else if ( Input.GetKeyDown( "5" ) && positions.Count >= 5 ) {
			setPosition( 5 );
		} else if ( Input.GetKeyDown( "6" ) && positions.Count >= 6 ) {
			setPosition( 6 );
		} else if ( Input.GetKeyDown( "7" ) && positions.Count >= 7 ) {
			setPosition( 7 );
		} else if ( Input.GetKeyDown( "8" ) && positions.Count >= 8 ) {
			setPosition( 8 );
		} else if ( Input.GetKeyDown( "9" ) && positions.Count >= 9 ) {
			setPosition( 9 );
		} else if ( Input.GetKeyDown( "0" ) && positions.Count >= 1 ) {
			setPosition( 0 );
		}
	}

	// Set camera to given position index and return true if index exists
	public bool setPosition( int position ) {
		if ( positions.Count > position ) {
			transform.position = positions[ position ];
			return true;
		}
		return false;
	}
}
