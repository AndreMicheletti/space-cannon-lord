using UnityEngine;
using System.Collections;

public class ClearTextOnMissTag : MonoBehaviour {

	public string Tag = "";

	private GUIText myText;

	void Start() {
		myText = GetComponent<GUIText> ();
	}

	// Update is called once per frame
	void Update () {
		if (GameObject.FindGameObjectWithTag (Tag) == null) {
			myText.text = "";
		}
	}
}
