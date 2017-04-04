using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {

	public float speed;
	//public Range rotation;

	private Rigidbody rigidBody;

	// Use this for initialization
	void Start () {
		rigidBody = GetComponent<Rigidbody> ();

		Vector3 movement = new Vector3 (
			0.0f,//rigidBody.rotation.y,
			0.0f,
			1.0f
		);

		rigidBody.velocity = movement * speed;
	}
}
