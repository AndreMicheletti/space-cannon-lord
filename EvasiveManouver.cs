using UnityEngine;
using System.Collections;

public class EvasiveManouver : MonoBehaviour {

	public float speed;
	public float dodge;
	public float tilt;
	public float maneuverSmoothing;

	public Vector2 startWait;
	public Vector2 maneuverTime;
	public Vector2 maneuverWait;

	public Boundary boundary;

	private Rigidbody rigidBody;
	private float targetManeuver;

	// Use this for initialization
	void Start () {
		rigidBody = GetComponent<Rigidbody> ();
		rigidBody.velocity = transform.forward * speed;

		StartCoroutine (Evade ());
	}

	IEnumerator Evade() {
		yield return new WaitForSeconds (Random.Range (startWait.x, startWait.y));
		while (true) {
			targetManeuver = Random.Range (1, dodge) * -Mathf.Sign(transform.position.x);
			yield return new WaitForSeconds (Random.Range (maneuverTime.x, maneuverTime.y));
			targetManeuver = 0;		
			yield return new WaitForSeconds (Random.Range (maneuverWait.x, maneuverWait.y));		 			
		}
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float newManeuver = Mathf.MoveTowards (rigidBody.velocity.x, targetManeuver, Time.deltaTime * maneuverSmoothing);
		rigidBody.velocity = new Vector3 (newManeuver, 0.0f, rigidBody.velocity.z);

		// Clump the Player inside the Play Area
		rigidBody.position = new Vector3 (
			Mathf.Clamp(rigidBody.position.x, boundary.xMin, boundary.xMax),
			0.0f,
			rigidBody.position.z
		);

		rigidBody.rotation = Quaternion.Euler (0.0f, 180.0f, rigidBody.velocity.x * tilt);

	}
}
