using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChecarEstado : MonoBehaviour
{

    public bool completou;
    float cronometro;
    public Text pontoAnterior, pontoAtual;
    public GameObject painelFeedback;
    public GameObject[] pecas, estrelas;
    public string teste;
    private int pontuacao, tempo;

    MoveObject2D[] objetos;

    void Start()
    {
       // PlayerPrefs.SetInt("pontuacao", 0);
        cronometro = 0;
        completou = false;
        AudioListener.pause = false;//new
        objetos = FindObjectsOfType<MoveObject2D>();
    }

    void Update()
    {
        cronometro += Time.deltaTime;
        teste = cronometro.ToString("0");
        if (completou == false)
        { //5Hz
          
            int soma = 0;
            for (int x = 0; x < objetos.Length; x++)
            {
                if (objetos[x].estaConectado)
                {
                    soma++;
                }
            }
            if (soma >= objetos.Length)
            {
                completou = true;
                int.TryParse(teste, out tempo);
                //Debug.Log(tempo);

                for (int i = 0; i < pecas.Length; i++)
                {
                    pecas[i].SetActive(false);
                }


                 if(SceneManager.GetActiveScene().buildIndex == 5){
                        PlayerPrefs.SetInt("desa1_4", tempo);
                    }else if(SceneManager.GetActiveScene().buildIndex == 9){
                        PlayerPrefs.SetInt("desa2_4", tempo);
                    }else if(SceneManager.GetActiveScene().buildIndex == 13){
                        PlayerPrefs.SetInt("desa3_4", tempo);
                }else if(SceneManager.GetActiveScene().buildIndex == 2){
                    PlayerPrefs.SetInt("desa1_1", tempo);
                }



                pontoAnterior.text = PlayerPrefs.GetInt("pontuacao").ToString();
                if(tempo < 31){
                    pontoAtual.text = (PlayerPrefs.GetInt("pontuacao") + 100).ToString();
                    PlayerPrefs.SetInt("pontuacao", (PlayerPrefs.GetInt("pontuacao") + 100));
                    
                }else if(tempo > 30 && tempo < 61){
                    pontoAtual.text = (PlayerPrefs.GetInt("pontuacao") + 50).ToString();
                    PlayerPrefs.SetInt("pontuacao", (PlayerPrefs.GetInt("pontuacao") + 50));

                    estrelas[2].SetActive(false);
                }else{
                    pontoAtual.text = (PlayerPrefs.GetInt("pontuacao") + 25).ToString();
                    PlayerPrefs.SetInt("pontuacao", (PlayerPrefs.GetInt("pontuacao") + 25));
                    estrelas[1].SetActive(false);
                    estrelas[2].SetActive(false);
                    
                }
                if(SceneManager.GetActiveScene().buildIndex == 13){
                    PlayerPrefs.SetInt("pontuacao_final", (PlayerPrefs.GetInt("pontuacao")));
                }
                painelFeedback.SetActive(true);
                AudioListener.pause = true; //new
               // Debug.Log("Completou com sucesso!!");
            }
        }
    }

    public void MostrarCena(int cena){
        if(cena == 2){
            PlayerPrefs.SetString("pontuacao", "0");
        }else if(cena == 5 || cena == 9 || cena == 13){
             PlayerPrefs.SetInt("pontuacao", int.Parse(pontoAnterior.text) );
        }else if (cena == 11){
            Debug.Log("fiiiim!");
        }
        SceneManager.LoadScene(cena);
    }

   
}