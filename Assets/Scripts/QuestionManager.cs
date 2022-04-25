using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class QuestionManager : MonoBehaviour
{
    public GameObject[] Options;
    public GameObject QuestionScreen;
    public List<QuestionAnswer> QA;
    public int currentQuestion;

    public TMP_Text QuestionTxt;
    // Start is called before the first frame update
    void Start()
    {
        generateQuestion();
    }

    public void correct(){
        if(QA.Count > 1){
            QA.RemoveAt(currentQuestion);
            generateQuestion();
        }else{
            CongratulationScreen();
        }
    }

    void generateQuestion(){
        currentQuestion = Random.Range(0, QA.Count);

        QuestionTxt.text = QA[currentQuestion].Question;
        setAnswers();
    }

    void CongratulationScreen(){
        QuestionScreen.transform.GetChild(0).GetComponent<TMP_Text>().text = "Congratulations!\n\n Thank you for your time, we hope you enjoyed the experience!";

        for(int i = 0; i < Options.Length; i++){
            Options[i].GetComponent<Image>().enabled = false;
            Options[i].transform.GetChild(0).GetComponent<TMP_Text>().text = "";
        }
    }

    void setAnswers(){
        for (int i = 0; i < Options.Length; i++){
            Options[i].GetComponent<AnswerScript>().isCorrect = false;            
            Options[i].transform.GetChild(0).GetComponent<TMP_Text>().text = QA[currentQuestion].Answers[i];
        
            if(QA[currentQuestion].CorrectAnswer == i+1){
                Options[i].GetComponent<AnswerScript>().isCorrect = true;
            }
        }
    }

}
