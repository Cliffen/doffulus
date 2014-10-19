using UnityEngine;
using System.Collections;

public class TrashIt : MonoBehaviour {
	protected uint noTrashed = 0;


	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter( Collider other ) {
		Destroy( other.gameObject, 2.0f );
	}
}
