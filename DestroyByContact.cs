using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour {

	public GameObject explosion;
	public GameObject playerExplosion;
	public int scoreValue;

	public GameObject[] dropList;

	private GameController gameController;

	void Start() {
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null)
			gameController = gameControllerObject.GetComponent<GameController> ();

		if (gameController == null)
			Debug.Log ("Cannot find 'GameController' script");
	}

	void OnTriggerEnter(Collider other) {
		if (other.CompareTag("Boundary")) return;
		if ( other.tag == "Enemy") return;
		if ( other.tag == "PickUp") return;

		Destroy (other.gameObject);
		Destroy (gameObject);

		if (explosion != null)
			Instantiate(explosion, transform.position, transform.rotation);
		if (other.tag == "Player") {
			Instantiate (playerExplosion, other.transform.position, other.transform.rotation);
			gameController.GameOver ();
		}

		if (CompareTag ("Bolt") == false || CompareTag ("Player") == true) { //&& other.CompareTag ("Bolt") == false) {
			Debug.Log ("Rolling Drop for this Collision");
			foreach (GameObject drop in dropList) {
				DropChance chance = drop.GetComponent<DropChance> ();
				if (chance != null) {
					if (Random.value <= chance.chanceValue) {
						Instantiate (drop, transform.position, transform.rotation);
						break;
					}
				}
			}
		}

		if (other.tag == "Bolt")
			gameController.AddScore (scoreValue);
	}
}
