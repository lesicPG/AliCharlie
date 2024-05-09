using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Sair : MonoBehaviour
{
   
    public InputField inputText;
    string nomeJogador;

    

    public void SalvarNome(){
      nomeJogador = inputText.text;
      PlayerPrefs.SetString("nome_jogador", nomeJogador);
      Debug.Log( PlayerPrefs.GetString("nome_jogador"));
      SceneManager.LoadScene(1);
    }

     public void SairFunction()
    {
        PlayerPrefs.SetInt("pontuacao", 0);
        PlayerPrefs.SetString("pontuacao", "0");
         PlayerPrefs.SetInt("botaoVoltar", 0);
           PlayerPrefs.SetInt("audioCharlie", 0);
           
           PlayerPrefs.SetInt("erros_quiz",0);
     PlayerPrefs.SetInt("acertos_quiz", 0);
       PlayerPrefs.SetInt("pontuacao_final", 0);
       PlayerPrefs.SetString("nome_jogador", "nome");


     PlayerPrefs.SetInt("desa1_1", 0);
     PlayerPrefs.SetInt("desa1_2", 0);
    PlayerPrefs.SetInt("desa1_3", 0);
     PlayerPrefs.SetInt("desa1_4", 0);

      PlayerPrefs.SetInt("desa2_1", 0);
     PlayerPrefs.SetInt("desa2_2", 0);
     PlayerPrefs.SetInt("desa2_3", 0);
     PlayerPrefs.SetInt("desa2_4", 0);

   PlayerPrefs.SetInt("desa3_1", 0);
     PlayerPrefs.SetInt("desa3_2", 0);
    PlayerPrefs.SetInt("desa3_3", 0);
     PlayerPrefs.SetInt("desa3_4", 0);
           
           
           
                   PlayerPrefs.Save();
        

        //se estiver no editor
      //UnityEditor.EditorApplication.isPlaying = false;
        //para o jogo compilado
        Application.Quit();
    }

    public void Iniciar(int cena){
      SceneManager.LoadScene(cena);
      
    }

    public void BotaoVoltarr(){
      PlayerPrefs.SetInt("botaoVoltar", SceneManager.GetActiveScene().buildIndex);
      SceneManager.LoadScene(1);
    }

    public void Iniciar_continuar(){
      
      if(PlayerPrefs.GetInt("botaoVoltar") == 0){
         SceneManager.LoadScene(PlayerPrefs.GetInt("botaoVoltar") + 2);
      }else{
         SceneManager.LoadScene(PlayerPrefs.GetInt("botaoVoltar"));
      }
      
    }

    public void continuarQuiz(){
      PlayerPrefs.SetInt("pontuacao", 0);
        PlayerPrefs.SetString("pontuacao", "0");
          PlayerPrefs.SetInt("botaoVoltar", 0);
            PlayerPrefs.SetInt("audioCharlie", 0);
        PlayerPrefs.Save();
        SceneManager.LoadScene(1);
    }
    
}
