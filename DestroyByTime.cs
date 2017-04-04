using UnityEngine;
using System.Collections;

public class DestroyByTime : MonoBehaviour {

	public float lifetime;
	public string timerName = "";
	public string timerTextTag = "";

	private float timer;
	private GUIText timerText = null;
	// Use this for initialization
	void Start () {
		Destroy (gameObject, lifetime);
		timer = lifetime;

		if(timerTextTag != "") {
			GameObject obj = GameObject.FindGameObjectWithTag (timerTextTag);
			if (obj != null) {
				timerText = obj.GetComponent<GUIText> ();
			}
		}
	}

	void Update() {
		if (timerText != null) {
			timer -= Time.deltaTime;
			timer = Mathf.Max (timer, 0);
			timerText.text = timerName + Mathf.RoundToInt(timer);
		}
	}
}
