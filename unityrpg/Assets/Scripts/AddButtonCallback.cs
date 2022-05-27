using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AddButtonCallback : MonoBehaviour {

	[SerializeField]
	public bool physical;


	public TurnSystem script;

	public GameObject TurnScript;


	public int buttonN;

	public static int buttonNumber;

	// Use this for initialization
	void Start () {

		this.gameObject.GetComponent<Button>().onClick.AddListener(() => addCallback());
		script = FindObjectOfType<TurnSystem>();
	}

	public void addCallback() {

		GameObject playerParty = GameObject.Find("PlayerParty");
		if (buttonN == script.correctButtonIndex)
		{
			playerParty.GetComponent<SelectUnit>().selectAttack(this.physical);
			StartCoroutine(TurnScript.GetComponent<TurnSystem>().GetNewEquation());	
		}
		else
		{
			TurnScript.GetComponent<TurnSystem>().nextTurn();
			StartCoroutine(TurnScript.GetComponent<TurnSystem>().GetNewEquation());
		}
	}

}
