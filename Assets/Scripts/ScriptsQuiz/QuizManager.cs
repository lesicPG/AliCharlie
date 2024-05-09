using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class QuizManager : MonoBehaviour //classe questao
{
    [SerializeField] private QuizUI quizUI;
    [SerializeField] private QuizDataScriptable quizData;
    public GameObject feedEstrela;
    [SerializeField] private List<Question> questions;
   
    private Question selectedQuestion;
    private int scoreCount = 0;
    private int numero, val = 0;
    
    public Text erros, acertos;
    public AudioSource audioQuestoes;
    public AudioClip[] audios;

    private int contAudios=1;
   


    // Start is called before the first frame update
    void Start()// função mostrarQuestao
    {
        scoreCount = 0;
        AudioListener.pause = false;
        numero = questions.Count;
        val = questions.Count - 1;
        audioQuestoes = GetComponent<AudioSource>();
        audioQuestoes.clip = audios[0];
        audioQuestoes.PlayDelayed(1.0f);
        Criar();
    }
    void Awake(){   
       
    }
   
    void Criar()
    {

        if (questions.Count > 0)
        {
            EmbaralharAlternativa();
        }
        else
        {
            MostrarFeedback();
        }

    }

    public void MostrarFeedback()
    {
        audioQuestoes.Stop();
        feedEstrela.SetActive(true);
        
        acertos.text = scoreCount.ToString();
        erros.text = (numero - scoreCount).ToString();

        PlayerPrefs.SetInt("acertos_quiz", scoreCount);
        PlayerPrefs.SetInt("erros_quiz", (numero - scoreCount));
      
    }

    public void EmbaralharAlternativa()
    {
        //int val = UnityEngine.Random.Range(0, questions.Count);
      
            selectedQuestion = questions[val];
            quizUI.Iniciar(selectedQuestion);
            questions.RemoveAt(val);
            val--;

    
    }

    public bool VerificarAlternativa(string answered)
    {
        bool corrextAns = false;

        if (answered == selectedQuestion.correctAns)
        {
            //yes
            corrextAns = true;
            scoreCount++;
            //audioQuestoes.Stop();
            audioQuestoes.clip = audios[contAudios];
            audioQuestoes.PlayDelayed(2.1f);
           
        }
        else
        {
            //No
             
            audioQuestoes.clip = audios[contAudios];
            audioQuestoes.PlayDelayed(2.1f);
        }

        if(contAudios <6){
            contAudios++;}

        Invoke("Criar", 2.0f);
         
        return corrextAns;
    }
}


public class MultiplaEscolha: QuizManager
{
    public QuizManager quizManager;
}

[System.Serializable]
public class Question
{
    public string questionInfo;
    public QuestionType questionType;
    public Sprite questionImage;
    public List<string> options;
    public string correctAns;

}
[System.Serializable]
public enum QuestionType
{
    TEXT,
    IMAGE,
    VIDEO,
    AUDIO
}

