using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataforma_Vertical : MonoBehaviour
{
    private bool moveBaixo = true;
    public float velocidade = 8f;
    public Transform pontoA;
    public Transform pontoB;

    void Update()
    {
        if (transform.position.y > pontoA.position.y)
            moveBaixo = true;
        if (transform.position.y < pontoB.position.y)
            moveBaixo = false;
        if (moveBaixo)
            transform.position = new Vector2(transform.position.x, transform.position.y - velocidade * Time.deltaTime);
        else
            transform.position = new Vector2(transform.position.x, transform.position.y + velocidade * Time.deltaTime);

    }


}
