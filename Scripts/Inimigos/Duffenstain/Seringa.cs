using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Seringa : MonoBehaviour
{
    public int dano = 20;
    public float velocidade = 20f;
    public float tempoDestruicao = 1f;
    public SpriteRenderer seringaSprite;
    public bool ladoDireito;

    private Player_Vida playerVida;
    private Controle_Emocional controleEmocional;
    private Player_Movimento playerMovimento;
    private Rigidbody2D rigd2D;
    private Vector2 direcao;

    void Awake()
    {
        playerVida = GameObject.FindObjectOfType<Player_Vida>();
        controleEmocional = GameObject.FindObjectOfType<Controle_Emocional>();
        playerMovimento = GameObject.FindObjectOfType<Player_Movimento>();
    }
    public void Start()
    {
        seringaSprite = GetComponent<SpriteRenderer>();
        rigd2D = GetComponent<Rigidbody2D>();
        Destruir();
    }
    private void Update()
    {
        if (direcao == Vector2.right)
        {
            seringaSprite.flipX = true;
        }
        else if (direcao == Vector2.left)
        {
            seringaSprite.flipX = false;
        }
    }
    public void FixedUpdate()
    {
        rigd2D.velocity = direcao * velocidade;
    }
    public void OnTriggerEnter2D(Collider2D _player)
    {
        /*
        if (_player.gameObject.tag == "Player" && playerVida.GetImuneDano() == false)
        {
            playerVida.SetImuneDano(true);
            playerVida.barraDeVida.value -= dano;
            controleEmocional.Medo(50);
            Destroy(gameObject);
        }
        */
    }
    public void Inicializar(Vector2 _direcao)
    {
        direcao = _direcao;
    }
    
    void Destruir()
    {
        Destroy(gameObject, tempoDestruicao);
    }
}
