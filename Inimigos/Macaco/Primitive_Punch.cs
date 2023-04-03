using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Primitive_Punch : MonoBehaviour
{
    
    public int danoInimigo = 50;
    public float posicaoInicial;
    public float posicaoFinal;
    private bool proximoSoco = true;
    private bool ladoDireito;

    private Animator anim;
    public GameObject pontoDisparo;
    public GameObject soco;
    private Player_Vida playerVida;
    private Controle_Emocional controleEmocional;
    public BoxCollider2D boxCollider;

    public AudioSource aS;


    void Awake()
    {
        anim = GetComponent<Animator>();

        playerVida = GameObject.FindObjectOfType<Player_Vida>();
        controleEmocional = GameObject.FindObjectOfType<Controle_Emocional>();
    }

    void Update()
    {
        ControlePosicao();
    }

    private bool ControlePosicao()
    {
        if (posicaoInicial > gameObject.transform.position.x)
        {
            pontoDisparo.transform.localPosition = new Vector2(2f, 0f);
            boxCollider.offset = new Vector2(7, 0);

            ladoDireito = true;

            return false;
        }

        if (posicaoFinal < gameObject.transform.position.x)
        {
            pontoDisparo.transform.localPosition = new Vector2(-2f, 0f);
            boxCollider.offset = new Vector2(-7, 0);

            ladoDireito = false;
        }

        return false;
    }
    private void OnTriggerEnter2D(Collider2D _Player)
    {
        if(_Player.gameObject.tag == "Player" && proximoSoco == true)
        {
            proximoSoco = false;

            StartCoroutine(EsperaSoco());
        }
    }

    private IEnumerator EsperaSoco()
    {
        anim.SetTrigger("Primitive_Punch");

        yield return new WaitForSeconds(0.5f);

        aS.Play();

        CriaSoco();

        DanoSoco();

        yield return new WaitForSeconds(2f);

        proximoSoco = true;
    }

    private bool DanoSoco()
    {
        if (playerVida.GetImuneDano() == true)
        {
            return false;
        }

        playerVida.SetImuneDano(true);
        playerVida.barraDeVida.value -= danoInimigo;
        controleEmocional.Medo(50);

        return false;
    }

    private bool CriaSoco()
    {
        GameObject socoTemp = (Instantiate(soco, pontoDisparo.transform.position, pontoDisparo.transform.rotation));

        Debug.Log("Primitive Punch!!!");

        if (ladoDireito)
        {
            socoTemp.GetComponent<Soco>().Direcao(Vector2.right);

            Destroy(socoTemp, 0.7f);

            return false;
        }
        
        if(!ladoDireito)
        {
            socoTemp.GetComponent<Soco>().Direcao(Vector2.left);

            Destroy(socoTemp, 0.7f);
        }

        return true;
    }
    
}
