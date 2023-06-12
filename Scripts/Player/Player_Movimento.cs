using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Player_Movimento : MonoBehaviour
{
    [Header ("Atributos de Movimentação")]

    [SerializeField] public float movimento;
    [SerializeField][Range(15f,30f)] private float velocidade;
    [SerializeField][Range(25f, 50f)] private float forcaPulo;
    [SerializeField] private bool noChao;
    public bool ladoDireito = false;

    private Player_Bencaos playerBencaos;
    private Player_Physics playerPhysics;
    private SpriteRenderer sr;
    private Rigidbody2D rigid2D;
    private Animator anim;
    private bool imobilizado;
    private bool confuso;
    public Transform pe;
    public float tamanhoPe;
    public Transform pontoDisparo;
    public LayerMask chao;
    public AudioSource aS;
    public AudioClip audioPulo;

    public void SetPlayerVelocidade(float _velocidade)
    {
        velocidade = _velocidade;
    }
    public void SetPlayerForcaPulo(float _forcaPulo)
    {
        forcaPulo = _forcaPulo;
    }
    public float GetPlayerVelocidade()
    {
        return velocidade;
    }
    public float GetPlayerForcaPulo()
    {
        return forcaPulo;
    }
    public void SetPlayerImobilizado(bool _imobilizado)
    {
        imobilizado = _imobilizado;
    }
    public bool GetPlayerImobilizado()
    {
        return imobilizado;
    }
    public void SetPlayerConfuso(bool _confuso)
    {
        confuso = _confuso;
    }
    public bool GetPlayerConfuso()
    {
        return confuso;
    }
    public void Awake()
    {
        playerPhysics = GameObject.FindObjectOfType<Player_Physics>();
        playerBencaos = GameObject.FindObjectOfType<Player_Bencaos>();
    }

    public void Start()
    {
        aS = GetComponent<AudioSource>();
        rigid2D = GetComponent<Rigidbody2D>(); //Referencia o rigidbody2D do player
        sr = GetComponent<SpriteRenderer>(); //Referencia o sprite rendenrer
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        for (int i = 0; i < 19; i++)
        {
            if (Input.GetKeyDown("joystick button " + i.ToString()))
                print("joystick button " + i.ToString());
        }

        if (GetPlayerImobilizado() != false)
        {
            movimento = 0;
            velocidade = 0;
            forcaPulo = 0;
        }

        //Alteracao das teclas esta em: Edit / Project Settings / Input Manager

        if (GetPlayerConfuso() == true)
        {
            sr.color = Color.green;
        }
        else
        {
            movimento = Input.GetAxis("Horizontal");
        }

        rigid2D.velocity = new Vector2(movimento * velocidade, rigid2D.velocity.y);

        //Controle de Animação no Eixo X e Y

        anim.SetFloat("Walking", Mathf.Abs(rigid2D.velocity.x));
        anim.SetFloat("Jump", Mathf.Abs(rigid2D.velocity.y));

        Flip(movimento);

        noChao = Physics2D.OverlapCircle(pe.position, tamanhoPe, chao);//Cria um raio no pe e verifica o que e chao

        //Pulo
        if (Input.GetKeyDown(KeyCode.UpArrow) && noChao == true || Input.GetKeyDown(KeyCode.W) && noChao == true || Input.GetKeyDown(KeyCode.Space) && noChao == true ||(Input.GetKeyDown("joystick button 1") && noChao == true ))//Quando a tecla "UpArrow" ou "W" for pressionada e noChao for verdadeiro entao:
        {
            aS.clip = audioPulo;
            aS.Play();
            rigid2D.velocity = Vector2.up * forcaPulo; //Player vai ser impulsionado para cima vezes a forcaPulo
        }

        playerPhysics.SetNoChao(noChao);
    }

    private void Flip(float _movimento) //Flipa o Sprite do Player de acordo com o movimento
    {
        if (_movimento > 0)
        {
            sr.flipX = true;
            pontoDisparo.localPosition = new Vector2(4.5f, 0f);
            ladoDireito = true;
        }
        else if (_movimento < 0)
        {
            sr.flipX = false;
            pontoDisparo.localPosition = new Vector2(-4.5f, 0f);
            ladoDireito = false;
        }
    }

    void OnCollisionEnter2D(Collision2D _player)
    {
        if (_player.gameObject.tag.Equals("Plataforma"))
        {
            this.transform.parent = _player.transform;
        }
    }
    void OnCollisionExit2D(Collision2D _player)
    {
        if (_player.gameObject.tag.Equals("Plataforma"))
        {
            this.transform.parent = null;
        }
    }

    public void OnTriggerEnter2D(Collider2D _player)
    {
        if (playerBencaos.GetImuneToxicidade() == false) 
        {

            if (_player.gameObject.tag == "Seringa" || _player.gameObject.tag == "BioHazard")
            {
                StartCoroutine(Confusao());
            }

        }
    }
    IEnumerator Confusao()
    {
        SetPlayerConfuso(true);
        yield return new WaitForSeconds(2f);
        SetPlayerConfuso(false);
        sr.color = Color.white;
    }


}


