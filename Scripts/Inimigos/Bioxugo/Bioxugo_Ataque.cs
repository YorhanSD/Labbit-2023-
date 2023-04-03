using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bioxugo_Ataque : MonoBehaviour
{
    public float posicaoInicial;

    public float posicaoFinal;

    public GameObject[] OndaEletrica = new GameObject[3];

    public Transform[] Choque;

    public SpriteRenderer spriteXugo;

    public SpriteRenderer[] spriteOndaEletrica;

    public AudioSource aS;

    public Rigidbody2D rigi2D;

    public Inimigo_Patrulha inimigoPatrulha;

    void Start()
    {
        rigi2D = GetComponent<Rigidbody2D>();

        StartCoroutine(IniciaRajadaEletrica());

        spriteXugo = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        ControlePosicao();
    }

    private void ControlePosicao()
    {
        if (posicaoInicial > gameObject.transform.position.x)
        {
            Choque[0].localPosition = new Vector2(8f, -0.4f);
            Choque[1].localPosition = new Vector2(12f, -0.4f);
            Choque[2].localPosition = new Vector2(16f, -0.4f);

            spriteOndaEletrica[0].flipX = true;
            spriteOndaEletrica[1].flipX = true;
            spriteOndaEletrica[2].flipX = true;
        }

        if (posicaoFinal < gameObject.transform.position.x)
        {
            Choque[0].localPosition = new Vector2(-8f, -0.4f);
            Choque[1].localPosition = new Vector2(-12f, -0.4f);
            Choque[2].localPosition = new Vector2(-16f, -0.4f);

            spriteOndaEletrica[0].flipX = false;
            spriteOndaEletrica[1].flipX = false;
            spriteOndaEletrica[2].flipX = false;
        }
    }



    IEnumerator IniciaRajadaEletrica()
    {
        inimigoPatrulha.SetPararInimigo(true);

        aS.Play();

        yield return new WaitForSeconds(0.1f);
        OndaEletrica[0].SetActive(true);
        yield return new WaitForSeconds(0.2f);
        OndaEletrica[1].SetActive(true);
        yield return new WaitForSeconds(0.5f);
        OndaEletrica[2].SetActive(true);

        StartCoroutine(FinalizaRajadaEletrica());
    }

    IEnumerator FinalizaRajadaEletrica()
    {
       yield return new WaitForSeconds(0.1f);
       OndaEletrica[0].SetActive(false);
       yield return new WaitForSeconds(0.2f);
       OndaEletrica[1].SetActive(false);
       yield return new WaitForSeconds(0.5f);
       OndaEletrica[2].SetActive(false);

       inimigoPatrulha.SetPararInimigo(false);

       yield return new WaitForSeconds(2f);

       StartCoroutine(IniciaRajadaEletrica());        
    }
}
