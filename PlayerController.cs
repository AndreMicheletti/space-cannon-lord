using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary {
	public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour {

	public float speed = 10;
	public float tilt = 1;

	public float fireRate = 0.5f;
	private float nextFire = 0.0f;
	public float weaponPowerUpTime = 0;

	public Boundary boundary;

	public GameObject shot;
	public Transform shotSpawn;

	public GUIText weaponTime;

	private Rigidbody rigidBody;
	// Use this for initialization
	void Start () {
		rigidBody = GetComponent<Rigidbody> ();

		weaponTime.text = "";
	}

	void Update() {
		if (Input.GetButton ("Fire1") && Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
			GetComponent<AudioSource> ().Play ();
			if (weaponPowerUpTime > 0) {
				Instantiate (shot, 
					new Vector3 (shotSpawn.position.x + 0.5f,
						shotSpawn.position.y,
						shotSpawn.position.z),
					shotSpawn.rotation);

				Instantiate (shot, 
					new Vector3 (shotSpawn.position.x - 0.5f,
						shotSpawn.position.y,
						shotSpawn.position.z),
					shotSpawn.rotation);
				/*
				Instantiate (shot, 
					new Vector3 (shotSpawn.position.x + 0.5f,
						shotSpawn.position.y,
						shotSpawn.position.z),
					Quaternion.Euler (0.0f, -10.0f, 0.0f));
				
				Instantiate(shot,
					new Vector3(shotSpawn.position.x - 0.5f,
						shotSpawn.position.y,
						shotSpawn.position.z),
					Quaternion.Euler(0.0f, -10.0f, 0.0f));
				*/
				//Debug.Log ("I'm powered up!");
			}
		}

		if (weaponPowerUpTime <= 0) {
			if (weaponTime.text != "")
				weaponTime.text = "";
		} else {


			weaponPowerUpTime -= (Time.deltaTime);
			weaponPowerUpTime = Mathf.Max (weaponPowerUpTime, 0);

			weaponTime.text = "Power-Up: " + Mathf.RoundToInt(weaponPowerUpTime);
		}
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		// Get Input
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical	 = Input.GetAxis ("Vertical");

		// Apply Input
		Vector3 force = new Vector3 (moveHorizontal, 0.0f, moveVertical) * speed;
		rigidBody.velocity = force ;

		// Clump the Player inside the Play Area
		rigidBody.position = new Vector3 (
			Mathf.Clamp(rigidBody.position.x, boundary.xMin, boundary.xMax),
			0.0f,
			Mathf.Clamp(rigidBody.position.z, boundary.zMin, boundary.zMax)
		);

		// Apply Tilt
		rigidBody.rotation = Quaternion.Euler (0.0f, 0.0f, rigidBody.velocity.x * -tilt);
	}
}
