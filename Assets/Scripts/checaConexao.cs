using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class checaConexao : MonoBehaviour
{


   


    public GameObject[] game;
    void Start(){
        PlayerPrefs.SetInt("guardar", 0);
        PlayerPrefs.Save();
        for (int i = 1; i < game.Length; i++)
        {
            game[i].SetActive(false);
        }

        
    }

    void Update(){
        if(Input.GetKeyDown(KeyCode.UpArrow)){
            Debug.Log("seta para cima");
        }else if(Input.GetKeyDown(KeyCode.DownArrow)){
            Debug.Log("seta para baixo");
        }else if(Input.GetKeyDown(KeyCode.LeftArrow)){
            Debug.Log("seta para esquerda");
        }else if(Input.GetKeyDown(KeyCode.RightArrow)){
            Debug.Log("seta para direita");
        }


         
    }


    void Ativar(int i){
        game[i].SetActive(true);
    }

     
    
}  
