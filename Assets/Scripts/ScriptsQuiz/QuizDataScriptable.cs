using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "QuestionsData", menuName = "QuestionsData")]
public class QuizDataScriptable : ScriptableObject
{
    //public string categoryName;
    public List<Question> questions;
}
