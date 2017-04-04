using UnityEngine;
using System.Collections;

[System.Serializable]
public class Range {
	public float min, max;

	public float getValue() {
		return Random.Range (min, max);
	}
}

public class GameController : MonoBehaviour {

	public GameObject[] hazardList;

	public Vector3 spawnValue;
	public Range hazardCount;
	public Range spawnWait;
	public float startWait;
	public Range waveWait;

	public GUIText scoreText;
	public GUIText restartText;
	public GUIText gameoverText;

	private bool gameOver;
	private bool restart;
	private int score;

	void Start() {
		score = 0; 
		StartCoroutine (SpawnWaves() );
		UpdateScore ();

		gameOver = false; restart = false;
		if (restartText != null)
			restartText.text = "";
		
		if (gameoverText != null)
		gameoverText.text = "";
	}

	void Update() {
		if (restart && Input.GetKeyDown (KeyCode.R)) {
			Application.LoadLevel( Application.loadedLevel );
		}
	}

	IEnumerator SpawnWaves() {
		
		yield return new WaitForSeconds (startWait);
		while (true) {
			float countNow = hazardCount.getValue ();
			for (int i = 0; i < countNow; i++) {
				Vector3 spawnPosition = new Vector3 ( Random.Range(-spawnValue.x, spawnValue.x), spawnValue.y, spawnValue.z);

				GameObject hazard = hazardList[Random.Range (0, hazardList.Length)];
				Quaternion spawnRotation = hazard.transform.rotation;

				Instantiate (hazard, spawnPosition, spawnRotation);

				yield return new WaitForSeconds (spawnWait.getValue());
			}
			yield return new WaitForSeconds (waveWait.getValue());

			if (gameOver) {
				restart = true;
				restartText.text = "Press 'R' to restart";
				break;
			}
		}
	}

	public void GameOver() {
		gameOver = true;
		gameoverText.text = "Game Over";
	}

	public void Restart() {

	}

	public void AddScore(int newScore) {
		score += newScore;
		UpdateScore ();
	}

	void UpdateScore() {
		if ( scoreText != null)
			scoreText.text = "Score: " + score;
	}
}
