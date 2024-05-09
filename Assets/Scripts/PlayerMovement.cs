using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{

    float cronometro;
    public Text pontoAnterior, pontoAtual;
    public GameObject painelFeedback;
    public GameObject[] estrelas;
    public string teste;
    private int pontuacao, tempo;



    public float moveSpeed;
    public Rigidbody2D rb; 
   // public checaConexao checar;
    
    private Vector2 moveDirection;

    public Transform conector;
    float distancia;
    bool estaConectado = false;
    bool completou = false;
  
   
    public GameObject[] game;
    

   void Start(){
      AudioListener.pause = false; //new
       
   }

    // Update is called once per frame
    void Update()
    {
      

        var distanceZ = (transform.position - Camera.main.transform.position).z;

        var leftBorder = Camera.main.ViewportToWorldPoint (new Vector3 (0,0,distanceZ)).x;

        var rightBorder = Camera.main.ViewportToWorldPoint (new Vector3 (1,0,distanceZ)).x;

        var topBorder = Camera.main.ViewportToWorldPoint (new Vector3 (0,0,distanceZ)).y;

        var bottomBorder = Camera.main.ViewportToWorldPoint (new Vector3 (0,1,distanceZ)).y;

        transform.position = new Vector3 (
            Mathf.Clamp (transform.position.x, leftBorder, rightBorder),
            Mathf.Clamp (transform.position.y, topBorder, bottomBorder),
            transform.position.z
        );

    
        ProcessInputs();
    }

    /// <summary>
    /// this function is called every
    /// </summary>
   void FixedUpdate(){
       Move();
   }

   void ProcessInputs(){
       float moveX = Input.GetAxisRaw("Horizontal");
       float moveY = Input.GetAxisRaw("Vertical");

       moveDirection = new Vector2(moveX, moveY).normalized; // TODO come back to this
   }

    void Move(){
        cronometro += Time.deltaTime;
        teste = cronometro.ToString("0");
      
        distancia = Vector2.Distance(transform.root.position, conector.position);
      
        if(!estaConectado && !completou){
            if(distancia < 0.5f){
           
                rb.gravityScale = 0;
                rb.velocity = Vector2.zero;
                transform.root.position = Vector2.MoveTowards(transform.root.position, conector.position, 0.02f);
            
            }
            if (distancia < 0.01f)
            {
                estaConectado = true;
                transform.root.position = conector.position;
               
                if(rb.name != "peca6"){
                    game[PlayerPrefs.GetInt("guardar") + 1].SetActive(true);
            
                    PlayerPrefs.SetInt("guardar", PlayerPrefs.GetInt("guardar") + 1 );
                    PlayerPrefs.Save();
                   
                }else{
                     completou = true;

                    for (int i = 0; i < game.Length; i++)
                    {
                        game[i].SetActive(false);
                    }

                    int.TryParse(teste, out tempo);

                    if(SceneManager.GetActiveScene().buildIndex == 6){
                        PlayerPrefs.SetInt("desa2_1", tempo);
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

                    painelFeedback.SetActive(true);
                    AudioListener.pause = true; //new
                    }
               
            }else{
                rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y *moveSpeed);
            }
        }
        
        
       
    }

    public void MostrarCena(int cena){
        if(cena == 6){
             PlayerPrefs.SetInt("pontuacao", int.Parse(pontoAnterior.text) );
        }
        SceneManager.LoadScene(cena);
    }

}
