using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combinacoes_SuperCenouras : MonoBehaviour
{
    Extrair_DNA extrair;
    Cria_Itens criaItens;

    public GameObject[] imagensDNA_DIR;
    public GameObject[] imagensDNA_ESQ;

    public int contadorDNA_DIR = 0;
    public int contadorDNA_ESQ = 0;

    public int probabilidadeSC;

    DNA_Azul dnaAzul;
    DNA_Laranja dnaLaranja;
    DNA_Preto dnaPreto;
    DNA_Verde dnaVerde;

    public void BotaoSetaESQ()
    {
         contadorDNA_ESQ ++;
    }
    public void BotaoSetaDIR()
    {
         contadorDNA_DIR ++;
    }

    void Awake()
    {
        extrair = GameObject.FindObjectOfType<Extrair_DNA>();
        criaItens = GameObject.FindObjectOfType<Cria_Itens>();

        dnaAzul = GameObject.FindObjectOfType<DNA_Azul>();
        dnaLaranja = GameObject.FindObjectOfType<DNA_Laranja>();
        dnaPreto = GameObject.FindObjectOfType<DNA_Preto>();
        dnaVerde = GameObject.FindObjectOfType<DNA_Verde>();
    }

    void Update()
    {
       if(contadorDNA_ESQ > 3)
        {
            contadorDNA_ESQ = 0;
        }
       if(contadorDNA_DIR > 3)
        {
            contadorDNA_DIR = 0;
        }

       if(contadorDNA_DIR == 0)
        {
            imagensDNA_DIR[0].SetActive(true);
        }
        else
        {
            imagensDNA_DIR[0].SetActive(false);
        }

        if (contadorDNA_DIR == 1)
        {
            imagensDNA_DIR[1].SetActive(true);
        }
        else
        {
            imagensDNA_DIR[1].SetActive(false);
        }

        if (contadorDNA_DIR == 2)
        {
            imagensDNA_DIR[2].SetActive(true);
        }
        else
        {
            imagensDNA_DIR[2].SetActive(false);
        }

        if (contadorDNA_DIR == 3)
        {
            imagensDNA_DIR[3].SetActive(true);
        }
        else
        {
            imagensDNA_DIR[3].SetActive(false);
        }

        if(contadorDNA_ESQ == 0)
        {
            imagensDNA_ESQ[0].SetActive(true);
        }
        else
        {
            imagensDNA_ESQ[0].SetActive(false);
        }
        if (contadorDNA_ESQ == 1)
        {
            imagensDNA_ESQ[1].SetActive(true);
        }
        else
        {
            imagensDNA_ESQ[1].SetActive(false);
        }

        if (contadorDNA_ESQ == 2)
        {
            imagensDNA_ESQ[2].SetActive(true);
        }
        else
        {
            imagensDNA_ESQ[2].SetActive(false);
        }

        if (contadorDNA_ESQ == 3)
        {
            imagensDNA_ESQ[3].SetActive(true);
        }
        else
        {
            imagensDNA_ESQ[3].SetActive(false);
        }

        extrair.quantidade[0] = dnaAzul.GetQuantidade();
        extrair.quantidade[1] = dnaLaranja.GetQuantidade();
        extrair.quantidade[2] = dnaPreto.GetQuantidade();
        extrair.quantidade[3] = dnaVerde.GetQuantidade();
    }

    public void BotaoOtimizar_DNA()
    {
        if(contadorDNA_DIR == 0 && contadorDNA_ESQ == 0)
        {
            if (extrair.quantidade[0] > 1) 
            {
                //Gasta 2 Genes
                Debug.Log("Gastou Dois Genes Azuis");
                dnaAzul.SetQuantidade(-2);
                //extrair.quantidade[0] = -2;
                //Cria Super Cenoura Azul;
                Debug.Log("Criou Super Cenoura Azul");
                criaItens.CriaSuperCenouraAzul();
            }

        }
        else if (contadorDNA_DIR == 1 && contadorDNA_ESQ == 1)
        {
            if (extrair.quantidade[1] > 1)
            {
                //Gasta 2 Genes
                Debug.Log("Gastou Dois Genes Laranjas");
                dnaLaranja.SetQuantidade(-2);
                //extrair.quantidade[1] = -2;
                //Cria Super Cenoura Laranja;
                Debug.Log("Criou Super Cenoura Laranja");
                criaItens.CriaSuperCenouraLaranja();
            }
        }
        else if (contadorDNA_DIR == 2 && contadorDNA_ESQ == 2)
        {
            if (extrair.quantidade[2] > 1)
            {
                //Gasta 2 Genes
                Debug.Log("Gastou Dois Genes Pretos");
                dnaPreto.SetQuantidade(-2);
                //extrair.quantidade[2] = -2;
                //Cria Super Cenoura Pretos;
                Debug.Log("Criou Super Cenoura Preta");
                criaItens.CriaSuperCenouraPreta();
            }
        }
        else if (contadorDNA_DIR == 3 && contadorDNA_ESQ == 3)
        {
            if (extrair.quantidade[3] > 1)
            {
                //Gasta 2 Genes
                Debug.Log("Gastou Dois Genes Verdes");
                dnaVerde.SetQuantidade(-2);
                //extrair.quantidade[3] = -2;
                //Cria Super Cenoura Pretos;
                Debug.Log("Criou Super Cenoura Verde");
                criaItens.CriaSuperCenouraVerde();
            }
        }
    }
}
