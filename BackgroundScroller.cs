using UnityEngine;
using System.Collections;

public class BackgroundScroller : MonoBehaviour {

	public float scrollSpeed;
	public float tileSizeZ;

	private Vector3 startPos;

	void Start() {
		startPos = transform.position;
	}

	// Update is called once per frame
	void Update () {
		float newPos = Mathf.Repeat (Time.time * scrollSpeed, tileSizeZ);

		transform.position = startPos + Vector3.forward * newPos;
	}
}
