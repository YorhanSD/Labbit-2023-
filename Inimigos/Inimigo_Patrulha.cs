using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo_Patrulha : MonoBehaviour
{
    bool moveDireita = true;
    public float velocidade = 8f;
    public GameObject inimigo;
    public float posicaoInicial;
    public float posicaoFinal;
    public Animator anim;
    public Rigidbody2D rigid2D;
    public SpriteRenderer sr;
    private bool parar = false;

    public void SetPararInimigo(bool _parar)
    {
        parar = _parar;
    }

    public bool GetParar()
    {
        return parar;
    }

    void Start()
    {
        anim = GetComponent<Animator>();
        rigid2D = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (GetParar() == false)
        {
            anim.SetFloat("Walking", Mathf.Abs(rigid2D.velocity.x));

            if (posicaoInicial > inimigo.transform.position.x)
            {
                moveDireita = true;
                sr.flipX = true;
            }
            else if (posicaoFinal < inimigo.transform.position.x)
            {
                moveDireita = false;
                sr.flipX = false;
            }

            if (moveDireita)
            {
                inimigo.transform.position = new Vector2(transform.position.x + velocidade * Time.deltaTime, transform.position.y);
            }
            else
            {
                inimigo.transform.position = new Vector2(transform.position.x - velocidade * Time.deltaTime, transform.position.y);
            }
        }

    }
}
