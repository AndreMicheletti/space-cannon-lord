using UnityEngine;
using System.Collections;

public class WeaponController : MonoBehaviour {

	public float[] timer;
	public GameObject shot;
	public Transform shotSpawn;

	private float nextShot = 0.0f;
	// Use this for initialization
	void Start () {
		nextShot = Time.time + Random.Range (timer [0], timer [1]);
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > nextShot)
			Fire ();
	}

	void Fire() {
		nextShot = Time.time + Random.Range (timer [0], timer [1]);
		Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
		GetComponent<AudioSource> ().Play ();
	}
}
