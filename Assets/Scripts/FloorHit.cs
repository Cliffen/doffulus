using UnityEngine;
using System.Collections;

public class FloorHit : MonoBehaviour {
	public int lives = 3;
	// Defaults to items tagged Respawn
	public GameObject[] resets;
	public Light alarm;

	public int maxIntensity = 5;
	public float speed = 40.0f;

	protected int fails = 0;

	// Use this for initialization
	void Start () {
		if ( resets == null ) {
			resets = GameObject.FindGameObjectsWithTag("Respawn");
		}
	}

	// Update is called once per frame
	void Update () {
		// Flash alarm
		if ( alarm && fails > 0 ) {
			alarm.range = Mathf.PingPong( Time.time * speed, maxIntensity );
			speed += 10;
		}
	}

	void OnTriggerEnter( Collider other ) {
		fails++;
		//Debug.Log("Fails " + fails);

		// Reset object that hit floor
		AxisRestrict target = other.gameObject.GetComponentInParent<AxisRestrict>();
		if ( target != null && !target.isInTrsah() )
			target.resetObject();
	}
}
