using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataforma_Vertical : MonoBehaviour
{
    private bool moveBaixo = true;
    public float velocidade = 8f;
    public float posicaoInicial;
    public float posicaoFinal;

    void Update()
    {
        if (transform.position.y > posicaoInicial)
            moveBaixo = true;
        if (transform.position.y < posicaoFinal)
            moveBaixo = false;
        if (moveBaixo)
            transform.position = new Vector2(transform.position.x, transform.position.y - velocidade * Time.deltaTime);
        else
            transform.position = new Vector2(transform.position.x, transform.position.y + velocidade * Time.deltaTime);

    }


}
