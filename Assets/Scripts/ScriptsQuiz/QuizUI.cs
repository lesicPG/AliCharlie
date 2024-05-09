using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuizUI : MonoBehaviour //classe Quiz Template Method
{
    [SerializeField] private QuizManager quizManager;
    [SerializeField] private Text questionText;
    [SerializeField] private Image questionImage;
    [SerializeField] private List<Button> options;
    [SerializeField] private Color correctCOl, wrongCol, normalCOl;

    private Question question; //
    private bool answered;

    

    // Start is called before the first frame update
    void Awake()// Função Unity
    {
        for (int i = 0; i < options.Count; i++)
        {
            Button localBtn = options[i];
            localBtn.onClick.AddListener(() => OnClick(localBtn));
        }
       
    }

    public void Iniciar(Question question)
    {
        this.question = question;

        switch (question.questionType)
        {
            case QuestionType.TEXT:
                questionImage.transform.parent.gameObject.SetActive(false);
                break;
            default:
                break;
        }

        questionText.text = question.questionInfo;

        List<string> answerList = ShuffleList.ShuffleListItems<string>(question.options);


        for (int i = 0; i < options.Count; i++)
        {
            
            options[i].GetComponentInChildren<Text>().text = answerList[i];
            options[i].name = answerList[i];    
            options[i].image.color = normalCOl; 
        }

        answered = false;


    }

    public void Finalizar()
    {
        SceneManager.LoadScene(2);
    }


    private void OnClick(Button btn)//função unity
    {
        if (!answered)
        {
            answered = true;
            bool val = quizManager.VerificarAlternativa(btn.name);
            if (val)
            {
                btn.image.color = correctCOl;
            }
            else
            {
                btn.image.color = wrongCol;
            }
        }
    }

    
}
