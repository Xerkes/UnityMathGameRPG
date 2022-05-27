using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SpawnEnemyTest : MonoBehaviour {

	[SerializeField]
	private GameObject enemyEncounterPrefab;

	private bool spawning = false;

	void Start() {
		DontDestroyOnLoad (this.gameObject);

		SceneManager.sceneLoaded += OnSceneLoaded;
	}

	private void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
		if (scene.name == "BattleTest") {
			if (this.spawning) {
				Instantiate (enemyEncounterPrefab);
			}
			SceneManager.sceneLoaded -= OnSceneLoaded;
			Destroy (this.gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Player") {
			this.spawning = true;
			SceneManager.LoadScene ("BattleTest");
		}
	}
}
