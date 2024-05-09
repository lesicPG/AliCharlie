using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//requer um boxCollider2D
[RequireComponent(typeof(Rigidbody2D))]
public class MoveObject2D : MonoBehaviour
{ // funciona apenas com cameras ortograficas

    
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
    float leiFitts, cronometro;
    public string teste;
    int tempo;

   

    void Start()
    {
        _rigidbody2D = transform.root.GetComponent<Rigidbody2D>();
        _rigidbody2D.gravityScale = 0;
        leiFitts = Mathf.Log((2*140), 2);
        
        

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
                

                
                int.TryParse(teste, out tempo);
                Debug.Log("--> tempo " + tempo);
                Debug.Log("--> Fitts " + leiFitts);
                Fitts(tempo);
                transform.root.position = conector.position;
            }
        }
    }

    public void Fitts(int tempo){
        if(tempo < leiFitts){
            Debug.Log("--> resultado bom");
        }else{
            Debug.Log("--> resultado ruim");
        }
    }
}