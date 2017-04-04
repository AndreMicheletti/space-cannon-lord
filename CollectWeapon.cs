using UnityEngine;
using System.Collections;

public class CollectWeapon : MonoBehaviour {

	public float powerUpTime = 15;

	private PlayerController player;

	void Start() {
		GameObject playerObj = GameObject.FindWithTag ("Player");
		player = playerObj.GetComponent<PlayerController>();

		if (player == null) {
			Debug.Log ("Cannot find 'player' gameobject");
			Destroy (gameObject);
		}
	}

	void OnTriggerEnter(Collider other) {
		if (other.CompareTag("Player")) {
			player.weaponPowerUpTime += powerUpTime;
			Destroy (gameObject);
		}
	}
}
