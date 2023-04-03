using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soco : MonoBehaviour
{
    public float velocidade = 30;
    Rigidbody2D rigid;
    private Vector2 direcao;
    public void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    public void Direcao(Vector2 recebeDirecao) //Direcao da cenoura
    {
        direcao = recebeDirecao;
    }

    private void FixedUpdate() 
    {
        rigid.velocity = direcao * velocidade;
    }
}
