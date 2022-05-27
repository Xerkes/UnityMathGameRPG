using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class TurnSystem : MonoBehaviour {

	private List<UnitStats> unitsStats;

	private GameObject playerParty;

	public GameObject enemyEncounter;

	public string previousScene;

	[SerializeField]
	private GameObject actionsMenu, enemyUnitsMenu;


	public Text QuestionText;
	public Text[] Buttons;
	public int num1;
	public int num2;
	public int Operator;
	public int CorrectAnswer;
	public int WrongAnswer;
	public int correctButtonIndex;

    public int condition;
    public bool random;



    void Start() {


		SetQuestions();
		SetButtonAnswers();

        this.playerParty = GameObject.Find ("PlayerParty");

		unitsStats = new List<UnitStats> ();
		GameObject[] playerUnits = GameObject.FindGameObjectsWithTag("PlayerUnit");
		foreach (GameObject playerUnit in playerUnits) {
			UnitStats currentUnitStats = playerUnit.GetComponent<UnitStats> ();
			currentUnitStats.calculateNextActTurn (0);
			unitsStats.Add (currentUnitStats);
		}
		GameObject[] enemyUnits = GameObject.FindGameObjectsWithTag("EnemyUnit");
		foreach (GameObject enemyUnit in enemyUnits) {
			UnitStats currentUnitStats = enemyUnit.GetComponent<UnitStats> ();
			currentUnitStats.calculateNextActTurn (0);
			unitsStats.Add (currentUnitStats);
		}
		unitsStats.Sort ();

		this.actionsMenu.SetActive (false);
		this.enemyUnitsMenu.SetActive (false);

		this.nextTurn ();
    }

	public void nextTurn() {
		GameObject[] remainingEnemyUnits = GameObject.FindGameObjectsWithTag ("EnemyUnit");
		if (remainingEnemyUnits.Length == 0) {		
			this.enemyEncounter.GetComponent<CollectReward> ().collectReward ();
			if (previousScene == "Forest")
            {
				SceneManager.LoadScene("Forest");
			}
			else if (previousScene == "Jungle")
            {
				SceneManager.LoadScene("Jungle");
			}
			else if (previousScene == "Desert")
			{
				SceneManager.LoadScene("Desert");
			}
			else if (previousScene == "Snow")
			{
				SceneManager.LoadScene("Snow");
			}
			else if (previousScene == "Wasteland")
			{
				SceneManager.LoadScene("Wasteland");
			}
			else
            {
				SceneManager.LoadScene ("Town");
            }	
		} 
		GameObject[] remainingPlayerUnits = GameObject.FindGameObjectsWithTag ("PlayerUnit");
		if (remainingPlayerUnits.Length == 0) {
			SceneManager.LoadScene("Title");
		}

		UnitStats currentUnitStats = unitsStats [0];
		unitsStats.Remove (currentUnitStats);

		if (!currentUnitStats.isDead ()) {
			GameObject currentUnit = currentUnitStats.gameObject;

			currentUnitStats.calculateNextActTurn (currentUnitStats.nextActTurn);
			unitsStats.Add (currentUnitStats);
			unitsStats.Sort ();

			if (currentUnit.tag == "PlayerUnit") {
				this.playerParty.GetComponent<SelectUnit> ().selectCurrentUnit (currentUnit.gameObject);
			} else {
				currentUnit.GetComponent<EnemyUnitAction> ().act ();
			}
		} else {
			this.nextTurn ();
		}
	}

    public void CheckAnswer(int buttonNumber)
    {
        if (buttonNumber == correctButtonIndex)
        {

            StartCoroutine(GetNewEquation());
        }
        else
        {
            this.nextTurn();
            StartCoroutine(GetNewEquation());
        }
    }

    public IEnumerator GetNewEquation()
    {
        yield return new WaitForSeconds(2);
        SetQuestions();
        SetButtonAnswers();

    }
    public void SetQuestions()
    {
        num1 = Random.Range(0, 20);                          //Set the right side of the question to a random between 0 and 10
        num2 = Random.Range(0, 20);
        Operator = condition;
        if (random == true) {
            Operator = Random.Range(1, 4);
        }
                                                            //Set the left side of the question to a random between -10 and 10                                       //Set the operator of the question
            switch (Operator)
            {

                case 1:                                                     //If operator is 1
                    CorrectAnswer = num1 * num2;                          //Multiply the integers on the left and right 
                    WrongAnswer = CorrectAnswer + Random.Range(-1, 1);     //Add a number between -1 and 1 to the correct answer and set it to the wrong answer        
                    QuestionText.GetComponent<Text>().text = num1.ToString() + "  *  " + num2.ToString() + "  =  ";          //Display the question
                    break;                                                  //Break the switch


                case 2:                                                                     //If operator is 2
                    CorrectAnswer = num1 - num2;                                           //Subtract 
                    WrongAnswer = CorrectAnswer + Random.Range(-1, 1);                      //Add a number between -1 and 1 to the correct answer and set it to the wrong answer
                    QuestionText.GetComponent<Text>().text = num1.ToString() + "  -  " + num2.ToString() + "  =  ";               //Display the question
                    break;                                                  //Break the switch


                case 3:                                                         //If operator is 3
                    CorrectAnswer = num1 + num2;                               //Add
                    WrongAnswer = CorrectAnswer + Random.Range(-1, 1);          //Add a number between -1 and 1 to the correct answer and set it to the wrong answer
                    QuestionText.GetComponent<Text>().text = num1.ToString() + "  +  " + num2.ToString() + "  =  ";                   //Display the question
                    break;


                case 4:                                                         //If operator is 4
                    CorrectAnswer = num1 / num2;                               //Division
                    WrongAnswer = CorrectAnswer + Random.Range(-1, 1);          //Add a number between -1 and 1 to the correct answer and set it to the wrong answer
                    QuestionText.GetComponent<Text>().text = num1.ToString() + "  /  " + num2.ToString() + "  =  ";                   //Display the question
                    break;   //Break the switch

                default:
                    break;
            }
        
        
    }
    public void SetButtonAnswers()
    {
        int answer = CorrectAnswer;
        correctButtonIndex = Random.Range(0, 3);
        int[] answerDeviations = GetDeviations();
        int deviationCounter = 0;
        answerDeviations[0] += answer;
        answerDeviations[1] += answer;

        for (int i = 0; i < Buttons.Length; i++)
        {
            if (i == correctButtonIndex)
            {
                Buttons[i].text = " " + answer;
            }
            else
            {
                Buttons[i].text = " " + answerDeviations[deviationCounter++];
            }
        }
    }
    public int[] GetDeviations()
    {
        int[] deviations = new int[2];
        int[] numbersToChooseFrom = { -3, -2, -1, 1, 2, 3 };
        deviations[0] = numbersToChooseFrom[Random.Range(0, numbersToChooseFrom.Length)];
        while (true)
        {
            deviations[1] = numbersToChooseFrom[Random.Range(0, numbersToChooseFrom.Length)];
            if (deviations[1] != deviations[0])
            {
                break;
            }
        }
        return deviations;
    }
}
