using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Desafio_3 : MonoBehaviour
{
    public Text temp_txt, qntde_imagens;
    public Text pontoAnterior, pontoAtual;
     public GameObject painelFeedback;
    public GameObject[] pecas;
    public GameObject game;
    private SpriteRenderer imagem;
    private Sprite umSprite, doisSprite, tresSprite;
    private float x, y, temp;
    private int cont, sortImagem;
    public string limitador;
    private bool pararTemp;
    // Start is called before the first frame update
    void Start()
    {
        pararTemp = false;
        cont = 0;
        x = Random.Range(-5.0f, 5.0f);
        y = Random.Range(-3.0f, 3.0f);
        AudioListener.pause = false; //new
        game.transform.position = new Vector2(x,y);

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("--->" + PlayerPrefs.GetInt("audioCharlie"));
        if(pararTemp == false && (PlayerPrefs.GetInt("audioCharlie") == 4 || PlayerPrefs.GetInt("audioCharlie") == 8 || PlayerPrefs.GetInt("audioCharlie") == 12)){
          
            temp = temp + Time.deltaTime;
            temp_txt.text = temp.ToString("0");
     
            if(Input.GetButtonDown("Fire1")){
                
                x = Random.Range(-5.0f, 5.0f);
                y = Random.Range(-3.0f, 3.0f);
                game.transform.position = new Vector2(x,y);
                cont++;
            }
             if( temp_txt.text.Equals(limitador)){
                  pecas[0].SetActive(false);
                painelFeedback.SetActive(true);
                AudioListener.pause = true; //new
               
                pontoAnterior.text = PlayerPrefs.GetInt("pontuacao").ToString();
                pontoAtual.text = (PlayerPrefs.GetInt("pontuacao") + cont).ToString();
                qntde_imagens.text = cont.ToString();
                PlayerPrefs.SetInt("pontuacao", (PlayerPrefs.GetInt("pontuacao") + cont));
                Debug.Log("qntd imagens: " + cont);
                pararTemp = true;
                PlayerPrefs.SetInt("audioCharlie", 0);

                if(SceneManager.GetActiveScene().buildIndex == 4){
                    PlayerPrefs.SetInt("desa1_3", cont);
                }else if(SceneManager.GetActiveScene().buildIndex == 8){
                    PlayerPrefs.SetInt("desa2_3", cont);
                }else if(SceneManager.GetActiveScene().buildIndex == 12){
                    PlayerPrefs.SetInt("desa3_3", cont);
                }
                    
                
            }
        }
      
        
    }

    public void MostrarCena(int cena){
        if(cena == 4 || cena == 8 || cena == 12)
            PlayerPrefs.SetInt("pontuacao", int.Parse(pontoAnterior.text) );
        SceneManager.LoadScene(cena);
        
    }

}
