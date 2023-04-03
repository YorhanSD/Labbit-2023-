using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cria_Itens : MonoBehaviour
{
    Inventario inventario;

    InterfaceTextos iT;

    DNA_Azul dnaAzul;
    DNA_Laranja dnaLaranja;
    DNA_Verde dnaVerde;
    DNA_Preto dnaPreto;

    void Awake()
    {
        iT = GameObject.FindObjectOfType<InterfaceTextos>();

        inventario = GameObject.FindObjectOfType<Inventario>();

        dnaAzul = GameObject.FindObjectOfType<DNA_Azul>();
        dnaLaranja = GameObject.FindObjectOfType<DNA_Laranja>();
        dnaPreto = GameObject.FindObjectOfType<DNA_Preto>();
        dnaVerde = GameObject.FindObjectOfType<DNA_Verde>();
        
    }
    public void CriaCenouraAzul()
    {
        Cenoura_Azul cenouraAzul = new Cenoura_Azul();
        cenouraAzul.SetNome("Cenoura Azul");

        if (inventario != null)
        {
            inventario.AdicionaItem(cenouraAzul);
        }
    }

    public void CriaCenouraLaranja()
    {
        for (int i = 0; i < 3; i++) 
        {
            Cenoura_Laranja cenouraLaranja = new Cenoura_Laranja();
            cenouraLaranja.SetNome("Cenoura Laranja");

            if (inventario != null)
            {
                inventario.AdicionaItem(cenouraLaranja);
            }
        }
    }

    public void CriaCenouraPreta()
    {
        for (int i = 0; i < 3; i++)
        {
            Cenoura_Preta cenouraPreta = new Cenoura_Preta();
            cenouraPreta.SetNome("Cenoura Preta");

            if (inventario != null)
            {
                inventario.AdicionaItem(cenouraPreta);
            }
        }
    }

    public void CriaCenouraVerde()
    {
        Cenoura_Verde cenouraVerde = new Cenoura_Verde();
        cenouraVerde.SetNome("Cenoura Verde");

        if (inventario != null)
        {
            inventario.AdicionaItem(cenouraVerde);
        }
    }

    public void CriaSuperCenouraAzul()
    {
        Super_CenouraAzul superCenouraAzul = new Super_CenouraAzul();
        superCenouraAzul.SetNome("Super Cenoura Azul");

        if (inventario != null)
        {
            inventario.AdicionaItem(superCenouraAzul);
        }
    }

    public void CriaSuperCenouraLaranja()
    {
        Super_CenouraLaranja superCenouraLaranja = new Super_CenouraLaranja();
        superCenouraLaranja.SetNome("Super Cenoura Laranja");

        if (inventario != null)
        {
            inventario.AdicionaItem(superCenouraLaranja);
        }
    }

    public void CriaSuperCenouraPreta()
    {
        Super_CenouraPreta superCenouraPreta = new Super_CenouraPreta();
        superCenouraPreta.SetNome("Super Cenoura Preta");

        if (inventario != null)
        {
            inventario.AdicionaItem(superCenouraPreta);
        }
    }

    public void CriaSuperCenouraVerde()
    {
        Super_CenouraVerde superCenouraVerde = new Super_CenouraVerde();
        superCenouraVerde.SetNome("Super Cenoura Verde");

        if (inventario != null)
        {
            inventario.AdicionaItem(superCenouraVerde);
        }
    }

    public void CriaDNAAzul()
    {
        dnaAzul.SetNome("DNA Azul");

        Debug.Log("Criou DNA Azul");

        if (inventario != null)
        {
            dnaAzul.SetQuantidade(+1);

                if(dnaAzul.GetQuantidade() > 1)
                {
                    CriaSuperCenouraAzul();

                    dnaAzul.SetQuantidade(-2);
                }
        }
    }

    public void CriaDNALaranja()
    {
        dnaLaranja.SetNome("DNA Laranja");

        Debug.Log("Criou DNA Laranja");

        iT.SetEsperaMenssagem(true);
        iT.SetRecebeMenssagem("2x DNA Criam uma Super Cenoura");

        if (inventario != null)
        {
            dnaLaranja.SetQuantidade(+1);

                if(dnaLaranja.GetQuantidade() > 1)
                {
                    CriaSuperCenouraLaranja();

                    dnaLaranja.SetQuantidade(-2);
                }
        }
    }

    public void CriaDNAPreto()
    {
        dnaPreto.SetNome("DNA Preto");

        Debug.Log("Criou DNA Preto");

        iT.SetEsperaMenssagem(true);
        iT.SetRecebeMenssagem("2x DNA Criam uma Super Cenoura");

        if (inventario != null)
        {
            dnaPreto.SetQuantidade(+1);

                if(dnaPreto.GetQuantidade() > 1)
                {
                    CriaSuperCenouraPreta();

                    dnaPreto.SetQuantidade(-2);
                }
        }
    }

    public void CriaDNAVerde()
    {
        dnaVerde.SetNome("DNA Verde");

        Debug.Log("Criou DNA Verde");

        if (inventario != null)
        {
            dnaVerde.SetQuantidade(+1);

                if(dnaVerde.GetQuantidade() > 1)
                {
                    CriaSuperCenouraVerde();

                    dnaVerde.SetQuantidade(-2);
                }
        }
    }
}
