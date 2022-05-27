using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SpawnEnemy : MonoBehaviour {

	[SerializeField]
	private GameObject enemyEncounterPrefab;

	private bool spawning = false;
	public string previousScene;

	void Start() {
		DontDestroyOnLoad (this.gameObject);

		SceneManager.sceneLoaded += OnSceneLoaded;
	}

	private void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
		if (scene.name == "Battle") {
			if (this.spawning) {
				Instantiate (enemyEncounterPrefab);
			}
			SceneManager.sceneLoaded -= OnSceneLoaded;
			Destroy (this.gameObject);
		}
		else if(scene.name == "BattleF")
        {
			if (this.spawning)
			{
				Instantiate(enemyEncounterPrefab);
			}
			SceneManager.sceneLoaded -= OnSceneLoaded;
			Destroy(this.gameObject);
		}
		else if (scene.name == "BattleJ")
        {
			if (this.spawning)
			{
				Instantiate(enemyEncounterPrefab);
			}
			SceneManager.sceneLoaded -= OnSceneLoaded;
			Destroy(this.gameObject);
		}
		else if (scene.name == "BattleD")
		{
			if (this.spawning)
			{
				Instantiate(enemyEncounterPrefab);
			}
			SceneManager.sceneLoaded -= OnSceneLoaded;
			Destroy(this.gameObject);
		}
		else if (scene.name == "BattleS")
		{
			if (this.spawning)
			{
				Instantiate(enemyEncounterPrefab);
			}
			SceneManager.sceneLoaded -= OnSceneLoaded;
			Destroy(this.gameObject);
		}
		else if (scene.name == "BattleW")
		{
			if (this.spawning)
			{
				Instantiate(enemyEncounterPrefab);
			}
			SceneManager.sceneLoaded -= OnSceneLoaded;
			Destroy(this.gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Player")
		{
			this.spawning = true;
			if (previousScene == "Forest")
			{
				SceneManager.LoadScene("BattleF");
			}
			else if(previousScene == "Jungle")
			{
				SceneManager.LoadScene("BattleJ");
			}
			else if (previousScene == "Desert")
			{
				SceneManager.LoadScene("BattleD");
			}
			else if (previousScene == "Snow")
			{
				SceneManager.LoadScene("BattleS");
			}
			else if (previousScene == "Wasteland")
			{
				SceneManager.LoadScene("BattleW");
			}
			else
            {
				SceneManager.LoadScene("Battle");
			}


		}
	}
}
