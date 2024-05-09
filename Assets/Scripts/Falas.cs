using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Falas : MonoBehaviour
{
    // Start is called before the first frame update
    float cronometro;
    int tempo;
    string teste;
    private AudioSource narracao;
    public Animator animacao;

    void Start()
    {
       cronometro = 0;
       
       animacao = GetComponent<Animator>();
    }

    void Awake(){
        narracao = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!narracao.isPlaying){
            animacao.SetBool("taParado", false);
        }
        cronometro += Time.deltaTime;
        teste = cronometro.ToString("0");
        int.TryParse(teste, out tempo);

        if(tempo == 1 ){
            
            animacao.SetBool("taParado", true);
            //narracao.PlayDelayed(0.1f);
             narracao.Play();
             
                  
        }

        if(tempo == 9 && SceneManager.GetActiveScene().buildIndex == 4){

            PlayerPrefs.SetInt("audioCharlie", 4);
            Debug.Log("--->" + PlayerPrefs.GetInt("audioCharlie"));
        }else if(tempo == 9 && SceneManager.GetActiveScene().buildIndex == 8){
            PlayerPrefs.SetInt("audioCharlie", 8);
            Debug.Log("--->" + PlayerPrefs.GetInt("audioCharlie"));

        }else if(tempo == 9 && SceneManager.GetActiveScene().buildIndex == 12){
            PlayerPrefs.SetInt("audioCharlie", 12);
            Debug.Log("--->" + PlayerPrefs.GetInt("audioCharlie"));
        }
    }


}
