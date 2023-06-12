using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Primitive_Punch : MonoBehaviour
{
    public float posicaoInicial;
    public float posicaoFinal;
    public float raioArea;

    public string animacaoIdle;
    public string animacaoAtaque;

    private bool proximoAtaque = true;
    private bool ladoDireito;
    public bool isPlayer;

    public LayerMask playerLayer;
    public Transform areaAtaque;
    public Transform areaDano;
    private Animator anim;
    public AudioSource audioSource;
    public Inimigo_Patrulha inimigoPatrulha;


    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        proximoAtaque = true;
    }

    void Update()
    {
        ControlePosicao();

        if (proximoAtaque == true)
        {
            isPlayer = Physics2D.OverlapCircle(areaAtaque.position, raioArea, playerLayer); //Cria o Range de Ataque
        }
        
        if(isPlayer == true)
        {
            proximoAtaque = false;
            StartCoroutine(AnimacaoAtaque());
        }
    }

    private bool ControlePosicao()
    {
        if (posicaoInicial > gameObject.transform.position.x)
        {
            areaAtaque.localPosition = new Vector2(6f, 0f);
            areaDano.localPosition = new Vector2(7f, 1.5f);

            ladoDireito = true;

            return false;
        }

        if (posicaoFinal < gameObject.transform.position.x)
        {
            areaAtaque.localPosition = new Vector2(-6, 0f);
            areaDano.localPosition = new Vector2(-7f, 1.5f);

            ladoDireito = false;
        }

        return false;
    }
 
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(areaAtaque.position, raioArea);
    }

    private IEnumerator AnimacaoAtaque()
    {
        if (inimigoPatrulha != null)
        {
            inimigoPatrulha.SetPararInimigo(true);
        }

        anim.SetTrigger(animacaoAtaque);

        audioSource.Play();

        yield return new WaitForSeconds(1f);

        anim.SetTrigger(animacaoIdle);

        yield return new WaitForSeconds(1f);

        if (inimigoPatrulha != null)
        {
            inimigoPatrulha.SetPararInimigo(false);
        }

        proximoAtaque = true;
    }

    /*
    private bool CriaSoco()
    {
        //GameObject socoTemp = (Instantiate(soco, pontoDisparo.transform.position, pontoDisparo.transform.rotation));

        Debug.Log("Primitive Punch!!!");

        if (ladoDireito)
        {
            //socoTemp.GetComponent<Soco>().Direcao(Vector2.right);

            //Destroy(socoTemp, 0.7f);

            return false;
        }
        
        if(!ladoDireito)
        {
            //socoTemp.GetComponent<Soco>().Direcao(Vector2.left);

            //Destroy(socoTemp, 0.7f);
        }

        return true;
    }
    */
    
}
