using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class StartBattle : MonoBehaviour {

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (this.gameObject);

		SceneManager.sceneLoaded += OnSceneLoaded;

		this.gameObject.SetActive (false);
	}

	private void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
		if (scene.name == "Title") {
			SceneManager.sceneLoaded -= OnSceneLoaded;
			Destroy (this.gameObject);
		} else if  (scene.name == "BattleF")
					{
			this.gameObject.SetActive(true);
        }
		else if (scene.name == "BattleJ")
		{
			this.gameObject.SetActive(scene.name == "BattleJ");
		}
		else if (scene.name == "BattleD")
		{
			this.gameObject.SetActive(scene.name == "BattleD");
		}
		else if (scene.name == "BattleS")
		{
			this.gameObject.SetActive(scene.name == "BattleS");
		}
		else if (scene.name == "BattleW")
		{
			this.gameObject.SetActive(scene.name == "BattleW");
		}
		else
        {
			this.gameObject.SetActive(scene.name == "Battle");
		}
		
	}

}
