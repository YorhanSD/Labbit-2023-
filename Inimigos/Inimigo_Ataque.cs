using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo_Ataque : MonoBehaviour
{
    public Seringa Seringa;
    public bool disparar = true;
    public Transform pontoDisparo;
    public float velocidadeAtaque = 3f;
    public GameObject seringa;
    public bool ladoDireito = false;

    void Start()
    {
        Seringa = GetComponent<Seringa>();
        StartCoroutine(DisparaSeringa());
    }

    public IEnumerator DisparaSeringa()
    {
        SeringaMovimento();
        yield return new WaitForSeconds(velocidadeAtaque);
        disparar = true;
        StartCoroutine(DisparaSeringa());
    }
    
    public void SeringaMovimento()
    {
        if (disparar == true)
        {
            //cria uma seringa temporaria no ponto de disparo
            GameObject seringaTemp = (GameObject)(Instantiate(seringa, pontoDisparo.transform.position, Quaternion.identity));

            if (ladoDireito)
            {
                seringaTemp.GetComponent<Seringa>().Inicializar(Vector2.right);
            }
            else
            {
                //Direciona a cenoura conforme a direcao que o personagem aponta
                //Importa o void inicializar com o componente de direcao do script da cenoura
                seringaTemp.GetComponent<Seringa>().Inicializar(Vector2.left);
            }
            disparar = false;
        }
    }
}
