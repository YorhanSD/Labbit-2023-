using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChuvaSeringas : MonoBehaviour
{
    public bool criar;

    public GameObject laserEsq;
    public GameObject laserDir;

    public bool ativarLeitura = false;
    public bool disparar = true;
    public bool punicaoAfiada;

    public Transform[] pontoDisparoBisturi;
    public Transform[] pontoDisparoSeringa;
    public Transform[] pontoCriacao;

    public float intervalo;
    public float velocidadeAtaque;

    public GameObject bisturi;
    public GameObject seringa;

    public int quantDisparosSeringas;
    public int quantDisparosBisturi;

    public int contagemBisturi;
    public int contagemSeringa;
    public int contagemLaser;

    void Start()
    {
        StartCoroutine(DisparaAtaque());

        quantDisparosBisturi = 2;
        quantDisparosSeringas = 0;
    }

    private void Update()
    {
        if (ativarLeitura == true)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W))
            {
                if (quantDisparosBisturi < 12)
                {
                    quantDisparosBisturi++;
                }

                if (quantDisparosSeringas < 6)
                {
                    quantDisparosSeringas++;
                }

                if (velocidadeAtaque > 1f)
                {
                    velocidadeAtaque -= 0.10f;
                }

                if (intervalo > 0.5f)
                {
                    intervalo -= 0.10f;
                }
            }

            if (Input.GetMouseButtonDown(1) || Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.C))
            {
                punicaoAfiada = true;
            }

            if(Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
            {
                contagemLaser++;

                if (contagemLaser == 30)
                {
                    criar = true;

                    CriaLaser();

                    contagemLaser = 0;
                }
            }
        }
    }

    public IEnumerator DisparaLaser() 
    { 
        yield return new WaitForSeconds(intervalo);
    }
    public IEnumerator DisparaAtaque()
    {
        punicaoAfiada = false;

        contagemBisturi = 0;

        contagemSeringa = 0;
        
        for (int i = contagemBisturi; contagemBisturi < quantDisparosBisturi; contagemBisturi++) 
        {
            yield return new WaitForSeconds(intervalo);

            BisturiMovimento();

            disparar = true;
        }
        
        for (int y = contagemSeringa; contagemSeringa < quantDisparosSeringas; contagemSeringa++)
        {
            yield return new WaitForSeconds(intervalo);

            SeringaMovimento();

            disparar = true;
        }

        if (punicaoAfiada == true)
        {
            contagemBisturi = 0;

            contagemSeringa = 0;


            for (int i = contagemBisturi; contagemBisturi < quantDisparosBisturi; contagemBisturi++)
            {
                BisturiMovimento();

                disparar = true;
            }

            for (int y = contagemSeringa; contagemSeringa < quantDisparosSeringas; contagemSeringa++)
            {
                SeringaMovimento();

                disparar = true;
            }
        }

        yield return new WaitForSeconds(velocidadeAtaque);

        StartCoroutine(DisparaAtaque());
    }

    public void CriaLaser()
    {
        if (criar == true)
        {
            GameObject laserEsqTemp = (GameObject)(Instantiate(laserEsq, pontoCriacao[0].transform.position, pontoCriacao[0].transform.rotation));

            GameObject laserDirTemp = (GameObject)(Instantiate(laserDir, pontoCriacao[1].transform.position, pontoCriacao[1].transform.rotation));

            criar = false;
        }
    }

    public void BisturiMovimento()
    {
        if (disparar == true)
        {
            //cria uma seringa temporaria no ponto de disparo
            GameObject bisturiTemp = (GameObject)(Instantiate(bisturi, pontoDisparoBisturi[contagemBisturi].transform.position, pontoDisparoBisturi[contagemBisturi].transform.rotation));

            disparar = false;
        }
    }

    public void SeringaMovimento()
    {
        if (disparar == true)
        {
            //cria uma seringa temporaria no ponto de disparo
            GameObject seringaTemp = (GameObject)(Instantiate(seringa, pontoDisparoSeringa[contagemSeringa].transform.position, Quaternion.identity));

            if (contagemSeringa % 2 == 0)
            {
                seringaTemp.GetComponent<Seringa>().Inicializar(Vector2.left);
            }
            else
            {
                seringaTemp.GetComponent<Seringa>().Inicializar(Vector2.right);
            }  
            
            disparar = false;
        }
    }
}
