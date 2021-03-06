using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SelectUnit : MonoBehaviour {

	private GameObject currentUnit;

	private GameObject actionsMenu, enemyUnitsMenu;

	void Awake() {
		SceneManager.sceneLoaded += OnSceneLoaded;
	}

	private void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
		if (scene.name == "Battle") {
			this.actionsMenu = GameObject.Find ("ActionsMenu");
			this.enemyUnitsMenu = GameObject.Find ("EnemyUnitsMenu");
		}
<<<<<<< Updated upstream
		else if (scene.name == "BattleForest")
=======
		else if (scene.name == "BattleF")
>>>>>>> Stashed changes
        {
			this.actionsMenu = GameObject.Find("ActionsMenu");
			this.enemyUnitsMenu = GameObject.Find("EnemyUnitsMenu");
		}
<<<<<<< Updated upstream
=======
		else if (scene.name == "BattleJ")
		{
			this.actionsMenu = GameObject.Find("ActionsMenu");
			this.enemyUnitsMenu = GameObject.Find("EnemyUnitsMenu");
		}
		else if (scene.name == "BattleD")
		{
			this.actionsMenu = GameObject.Find("ActionsMenu");
			this.enemyUnitsMenu = GameObject.Find("EnemyUnitsMenu");
		}
		else if (scene.name == "BattleS")
		{
			this.actionsMenu = GameObject.Find("ActionsMenu");
			this.enemyUnitsMenu = GameObject.Find("EnemyUnitsMenu");
		}
		else if (scene.name == "BattleW")
		{
			this.actionsMenu = GameObject.Find("ActionsMenu");
			this.enemyUnitsMenu = GameObject.Find("EnemyUnitsMenu");
		}
>>>>>>> Stashed changes
	}

	public void selectCurrentUnit(GameObject unit) {
		this.currentUnit = unit;

		this.actionsMenu.SetActive (true);

		this.currentUnit.GetComponent<PlayerUnitAction> ().updateHUD ();
	}

	public void selectAttack(bool physical) {
		this.currentUnit.GetComponent<PlayerUnitAction> ().selectAttack (physical);

		this.actionsMenu.SetActive (false);
		this.enemyUnitsMenu.SetActive (true);
	}

	public void attackEnemyTarget(GameObject target) {
		this.actionsMenu.SetActive (false);
		this.enemyUnitsMenu.SetActive (false);

		this.currentUnit.GetComponent<PlayerUnitAction>().act (target);
	}
}
