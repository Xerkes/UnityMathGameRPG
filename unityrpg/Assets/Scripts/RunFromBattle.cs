using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class RunFromBattle : MonoBehaviour {

	[SerializeField]
	private float runnningChance;

	public string previousScene;

	public void tryRunning() {
		float randomNumber = Random.value;
		if (randomNumber < this.runnningChance) {

			if(previousScene == "F")
            {
				SceneManager.LoadScene("Forest");
			}
			else if (previousScene == "J")
			{
				SceneManager.LoadScene("Jungle");
			}
			else if (previousScene == "D")
			{
				SceneManager.LoadScene("Desert");
			}
			else if (previousScene == "S")
			{
				SceneManager.LoadScene("Snow");
			}
			else if (previousScene == "W")
			{
				SceneManager.LoadScene("Wasteland");
			}
			else
            {
				SceneManager.LoadScene ("Town");
            }
			
		} else {
			GameObject.Find("TurnSystem").GetComponent<TurnSystem> ().nextTurn ();
		}
	}
}
