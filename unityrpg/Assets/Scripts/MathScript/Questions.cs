using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Questions : MonoBehaviour
{
    public Text QuestionText;
    public Text[] Buttons;
    private int num1;
    private int num2;
    private int Operator;
    private int CorrectAnswer;
    private int WrongAnswer;
    private int correctButtonIndex;

    void Start()
    {
        SetQuestions();
        SetButtonAnswers();
    }

    public void CheckAnswer(int buttonNumber)
    {
        if (buttonNumber == correctButtonIndex)
        {
            StartCoroutine(GetNewEquation());
        }
        else
        {
            StartCoroutine(GetNewEquation());
        }
    }
    private IEnumerator GetNewEquation()
    {
        yield return new WaitForSeconds(2);
        SetQuestions();
        SetButtonAnswers();
      
    }
    void Update()
    {
        
    }

    public void SetQuestions()
    {
        num1 = Random.Range(0, 10);                          //Set the right side of the question to a random between 0 and 10
        num2 = Random.Range(0, 10);                          //Set the left side of the question to a random between -10 and 10 
        Operator = 3;                                       //Set the operator of the question
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
    private void SetButtonAnswers()
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
                Buttons[i].text = "Yes " + answer;
            }
            else
            {
                Buttons[i].text = "No " + answerDeviations[deviationCounter++];
            }
        }
    }
    private int[] GetDeviations()
    {
        int[] deviations = new int[2];
        int[] numbersToChooseFrom = {-3,-2,-1,1,2,3};
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
