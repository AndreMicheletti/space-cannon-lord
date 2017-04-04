using UnityEngine;
using System.Collections;

public class CollectShield : MonoBehaviour {
	
	public GameObject shield;
	public float YRotation;

	private Transform player;
	void Start() {
		GameObject playerObj = GameObject.FindWithTag ("Player");
		if (playerObj != null) {
			player = playerObj.GetComponent<Transform> ();

			if (player == null) {
				Debug.Log ("Cannot find 'player' gameobject");
				Destroy (gameObject);
			}
		} else {
			Destroy (gameObject);
		}
	}

	void OnTriggerEnter(Collider other) {
		if (GameObject.FindWithTag ("Shield") != null)
			return;
		if (other.CompareTag("Player")) {

			((GameObject) Instantiate (
				shield,
				player.transform.position,
				Quaternion.Euler (0.0f, YRotation, 0.0f)))
			.transform.parent = player;

			Destroy (gameObject);
		}
	}
}
