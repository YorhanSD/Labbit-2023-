using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Visor_Itens : MonoBehaviour
{
    public GameObject player;

    public GameObject[] imagemItem;
    public GameObject[] imagemItemFusaoEsq;
    public GameObject[] imagemItemExtracao;

    Cenoura_Azul cenouraAzul;
    Cenoura_Laranja cenouraLaranja;
    Cenoura_Preta cenouraPreta;
    Cenoura_Verde cenouraVerde;

    Super_CenouraAzul superCenouraAzul;
    Super_CenouraLaranja superCenouraLaranja;
    Super_CenouraPreta superCenouraPreta;
    Super_CenouraVerde superCenouraVerde;

    Seleciona_Itens selecionaItens;
    Inventario inventario;

    void Awake()
    {
        inventario = GameObject.FindObjectOfType<Inventario>();
        selecionaItens = GameObject.FindObjectOfType<Seleciona_Itens>();

        cenouraAzul = GameObject.FindObjectOfType<Cenoura_Azul>();
        cenouraLaranja = GameObject.FindObjectOfType<Cenoura_Laranja>();
        cenouraPreta = GameObject.FindObjectOfType<Cenoura_Preta>();
        cenouraVerde = GameObject.FindObjectOfType<Cenoura_Verde>();

        superCenouraAzul = GameObject.FindObjectOfType<Super_CenouraAzul>();
        superCenouraLaranja = GameObject.FindObjectOfType<Super_CenouraLaranja>();
        superCenouraPreta = GameObject.FindObjectOfType<Super_CenouraPreta>();
        superCenouraVerde = GameObject.FindObjectOfType<Super_CenouraVerde>();
    }

    void Update()
    {
        if (player != null)
        {
            if (inventario != null)
            {
                if (inventario.listaItens.Count > 0)
                {
                    MostraItem();
                }

            }
        }
    }

    void MostraItem()
    {
        MostraCenouraAzul();
        MostraCenouraLaranja();
        MostraCenouraPreta();
        MostraCenouraVerde();

        MostraSuperCenouraAzul();
        MostraSuperCenouraLaranja();
        MostraSuperCenouraPreta();
        MostraSuperCenouraVerde();
    }

    public bool MostraCenouraAzul()
    {
        if (inventario.listaItens[selecionaItens.contagem].GetNome() == "Cenoura Azul")
        {
            imagemItem[0].SetActive(true);

            imagemItemFusaoEsq[0].SetActive(true);
            imagemItemExtracao[0].SetActive(true);

            return false;
        }

            imagemItem[0].SetActive(false);
            imagemItemFusaoEsq[0].SetActive(false);

            imagemItemExtracao[0].SetActive(false);
        
        return false;
    }

    public bool MostraCenouraLaranja()
    {
        if (inventario.listaItens[selecionaItens.contagem].GetNome() == "Cenoura Laranja")
        {
            imagemItem[1].SetActive(true);

            imagemItemFusaoEsq[1].SetActive(true);
            imagemItemExtracao[1].SetActive(true);

            return false;
        }

        imagemItem[1].SetActive(false);
        imagemItemFusaoEsq[1].SetActive(false);

        imagemItemExtracao[1].SetActive(false);

        return false;
    }

    public bool MostraCenouraPreta()
    {
        if (inventario.listaItens[selecionaItens.contagem].GetNome() == "Cenoura Preta")
        {
            imagemItem[2].SetActive(true);

            imagemItemFusaoEsq[2].SetActive(true);
            imagemItemExtracao[2].SetActive(true);

            return false;
        }

        imagemItem[2].SetActive(false);
        imagemItemFusaoEsq[2].SetActive(false);

        imagemItemExtracao[2].SetActive(false);

        return false;
    }

    public bool MostraCenouraVerde()
    {
        if (inventario.listaItens[selecionaItens.contagem].GetNome() == "Cenoura Verde")
        {
            imagemItem[3].SetActive(true);

            imagemItemFusaoEsq[3].SetActive(true);
            imagemItemExtracao[3].SetActive(true);

            return false;
        }

        imagemItem[3].SetActive(false);
        imagemItemFusaoEsq[3].SetActive(false);

        imagemItemExtracao[3].SetActive(false);

        return false;
    }

    public bool MostraSuperCenouraAzul()
    {
        if (inventario.listaItens[selecionaItens.contagem].GetNome() == "Super Cenoura Azul")
        {
            imagemItem[4].SetActive(true);

            return false;
        }

        imagemItem[4].SetActive(false);

        return false;
    }

    public bool MostraSuperCenouraLaranja()
    {
        if (inventario.listaItens[selecionaItens.contagem].GetNome() == "Super Cenoura Laranja")
        {
            imagemItem[5].SetActive(true);

            return false;
        }

        imagemItem[5].SetActive(false);

        return false;
    }

    public bool MostraSuperCenouraPreta()
    {
        if (inventario.listaItens[selecionaItens.contagem].GetNome() == "Super Cenoura Preta")
        {
            imagemItem[6].SetActive(true);

            return false;
        }

        imagemItem[6].SetActive(false);

        return false;
    }

    public bool MostraSuperCenouraVerde()
    {
        if (inventario.listaItens[selecionaItens.contagem].GetNome() == "Super Cenoura Verde")
        {
            imagemItem[7].SetActive(true);

            return false;
        }

        imagemItem[7].SetActive(false);

        return false;
    }
}
