using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Desafio_2 : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 posicInicial;
    Vector3 posicDestino;
    Vector3 vetorDirecao;
    Rigidbody2D _rigidbody2D;
    bool estaArrastando;
    float distancia;

    [HideInInspector]
    public bool estaConectado;

    [Range(1, 15)]
    public float velocidadeDeMovimento = 10;
    [Space(10)]
    public Transform conector;
    [Range(0.1f, 2.0f)]
    public float distanciaMinimaConector = 0.5f;
    public GameObject[] imagem;
    private int cont = 0;
    private bool completou;
    private float cronometro;
 
    public Text pontoAnterior, pontoAtual;
    public GameObject painelFeedback;
    public GameObject[] estrelas;
    public string teste;
    private int pontuacao, tempo;
    public GameObject peca;

    Vector3 poseInicial;

  
    void Start()
    {
        _rigidbody2D = transform.root.GetComponent<Rigidbody2D>();
        _rigidbody2D.gravityScale = 0;
       
       // poseInicial = _rigidbody2D.transform.position;
        AudioListener.pause = false;//new
        cronometro = 0;
        completou = false;
    }

   

    void Update(){

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

    }

    void OnMouseDown()
    {
        posicInicial = transform.root.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        _rigidbody2D.gravityScale = 0;
        estaArrastando = true;
        estaConectado = false;
    }

    void OnMouseDrag()
    {
        posicDestino = posicInicial + Camera.main.ScreenToWorldPoint(Input.mousePosition);
        vetorDirecao = posicDestino - transform.root.position;
        _rigidbody2D.velocity = vetorDirecao * velocidadeDeMovimento;
    }

    void OnMouseUp()
    {
        _rigidbody2D.gravityScale = 1;
        estaArrastando = false;
    }

    void FixedUpdate()
    {
        cronometro += Time.deltaTime;
        teste = cronometro.ToString("0");

       

        if(!completou){
            if (!estaArrastando && !estaConectado)
            {
                 
                distancia = Vector2.Distance(transform.root.position, conector.position);
                
                if (distancia < distanciaMinimaConector)
                {
                    _rigidbody2D.gravityScale = 0;
                    _rigidbody2D.velocity = Vector2.zero;
                    transform.root.position = Vector2.MoveTowards(transform.root.position, conector.position, 0.02f);
                }
                if (distancia < 0.01f)
                {
                    estaConectado = true;
                    
                    _rigidbody2D.simulated = false;
                    transform.root.position = conector.position;
                    peca.SetActive(false);

                    int.TryParse(teste, out tempo);
                    Debug.Log(completou);

                    if(SceneManager.GetActiveScene().buildIndex == 3){
                        PlayerPrefs.SetInt("desa1_2", tempo);
                    }else if(SceneManager.GetActiveScene().buildIndex == 7){
                        PlayerPrefs.SetInt("desa2_2", tempo);
                    }else if(SceneManager.GetActiveScene().buildIndex == 11){
                        PlayerPrefs.SetInt("desa3_2", tempo);
                    }



                    painelFeedback.SetActive(true);
                    AudioListener.pause = true;//new
                    pontoAnterior.text = PlayerPrefs.GetInt("pontuacao").ToString();
                    if(tempo < 31){
                        pontoAtual.text = (PlayerPrefs.GetInt("pontuacao") + 100).ToString();
                        PlayerPrefs.SetInt("pontuacao",(PlayerPrefs.GetInt("pontuacao") + 100) );
                        
                        
                    }else if(tempo > 30 && tempo < 61){
                        pontoAtual.text = (PlayerPrefs.GetInt("pontuacao") + 50).ToString();
                        PlayerPrefs.SetInt("pontuacao",(PlayerPrefs.GetInt("pontuacao") + 50) );
                        estrelas[2].SetActive(false);
                    }else{
                        pontoAtual.text = (PlayerPrefs.GetInt("pontuacao") + 25).ToString();
                        PlayerPrefs.SetInt("pontuacao",(PlayerPrefs.GetInt("pontuacao") + 25) );
                        estrelas[1].SetActive(false);
                        estrelas[2].SetActive(false);
                        
                    }
                   
                    completou = false;

                    
                }

                
            }

            
        }

        
    }


    // Update is called once per frame
   

    public void MostrarImagem(int n){
        
        if(n != 0){
            imagem[n].SetActive(true);
            imagem[n-1].SetActive(false);
            cont++;
        }else{
            imagem[n].SetActive(true);
            imagem[imagem.Length - 1].SetActive(false);
           // Debug.Log("--> " + cont);
        }
        if(cont > imagem.Length - 1){
            completou = true;
            for (int i = 0; i < imagem.Length; i++)
            {
                imagem[i].SetActive(true);
            }

        }
        
    }

    public void MostrarCena(int cena){
        if(cena == 3 || cena == 7 || cena == 11)
            PlayerPrefs.SetInt("pontuacao", int.Parse(pontoAnterior.text) );
        SceneManager.LoadScene(cena);
    }
}
