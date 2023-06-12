using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataforma_Horizontal : MonoBehaviour
{
    bool moveDireita = true;
    public float velocidade = 8f;

    public float posicaoInicial;
    public float posicaoFinal;

    void Update()
    {
        if (transform.position.x < posicaoInicial)
            moveDireita = true;
        if (transform.position.x > posicaoFinal)
            moveDireita = false;

        if (moveDireita == true)
        {
            transform.position = new Vector2(transform.position.x + velocidade * Time.deltaTime, transform.position.y);
        }
        else
        {
            transform.position = new Vector2(transform.position.x - velocidade * Time.deltaTime, transform.position.y);
        }

    }
}
