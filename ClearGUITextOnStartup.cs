using UnityEngine;
using System.Collections;

public class ClearGUITextOnStartup : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GetComponent<GUIText> ().text = "";
	}
}
