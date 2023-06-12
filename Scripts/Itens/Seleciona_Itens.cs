using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;


public class Seleciona_Itens : MonoBehaviour
{
    public int contagem = 0;

    Inventario inventario;

    Atirar_Cenoura atirarCenoura;

    InterfaceTextos iT;

    Player_Vida playerVida;

    Cenoura_Azul cenouraAzul;
    Cenoura_Laranja cenouraLaranja;
    Cenoura_Preta cenouraPreta;
    Cenoura_Verde cenouraVerde;

    Super_CenouraAzul superCenouraAzul;
    Super_CenouraLaranja superCenouraLaranja;
    Super_CenouraPreta superCenouraPreta;
    Super_CenouraVerde superCenouraVerde;

    void Awake()
    {
        playerVida = GameObject.FindObjectOfType<Player_Vida>();
        iT = GameObject.FindObjectOfType<InterfaceTextos>();

        inventario = GameObject.FindObjectOfType<Inventario>();
        atirarCenoura = GameObject.FindObjectOfType<Atirar_Cenoura>();

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
        if (inventario.listaItens.Count > 0)
        {
            if (cenouraAzul.GetQuantidade() > 0 || cenouraLaranja.GetQuantidade() > 0 || cenouraPreta.GetQuantidade() > 0 || cenouraVerde.GetQuantidade() > 0 || superCenouraAzul.GetQuantidade() > 0 || superCenouraLaranja.GetQuantidade() > 0 || superCenouraPreta.GetQuantidade() > 0 || superCenouraVerde.GetQuantidade() > 0)
            {
                VerificaCenouras();
            }
        }

        if (Input.GetKeyDown(KeyCode.F) || Input.GetKeyDown("joystick button 9")) //Ao pressionar F o contador conta +1
        { 
            if (contagem < inventario.listaItens.Count)
            {
                iT.SetEsperaMenssagem(false);

                if (cenouraAzul.GetQuantidade() > 0 || cenouraLaranja.GetQuantidade() > 0 || cenouraPreta.GetQuantidade() > 0 || cenouraVerde.GetQuantidade() > 0 || superCenouraAzul.GetQuantidade() > 0 || superCenouraLaranja.GetQuantidade() > 0 || superCenouraPreta.GetQuantidade() > 0 || superCenouraVerde.GetQuantidade() > 0)
                {
                    contagem++;
                }
            }
        }

        if (contagem == inventario.listaItens.Count)
        {
            contagem = 0;
        }
    }

    void VerificaCenouras()
    {
        switch (inventario.listaItens[contagem].GetNome())
        {
            case "Cenoura Azul":

                if (iT.GetEsperaMenssagem() == false)
                {
                    iT.SetRecebeMenssagem("[X] para Atacar [C] para Curar");
                }

                atirarCenoura.SetItem(cenouraAzul);
                atirarCenoura.SetPodeAtirar(true);

                playerVida.BarraDeApoio(true, cenouraAzul.GetCura());

                if (cenouraAzul.GetQuantidade() < 1)
                {
                    contagem++;
                }

                break;

            case "Cenoura Laranja":

                if (iT.GetEsperaMenssagem() == false)
                {
                    iT.SetRecebeMenssagem("[X] para Atacar [C] para Curar");
                }

                atirarCenoura.SetItem(cenouraLaranja);

                atirarCenoura.SetPodeAtirar(true);

                playerVida.BarraDeApoio(true, cenouraLaranja.GetCura());

                if (cenouraLaranja.GetQuantidade() < 1)
                {
                    contagem++;
                }

                break;

            case "Cenoura Preta":

                if (iT.GetEsperaMenssagem() == false)
                {
                    iT.SetRecebeMenssagem("[X] para Atacar [C] para Curar");
                }

                atirarCenoura.SetItem(cenouraPreta);
                atirarCenoura.SetPodeAtirar(true);

                playerVida.BarraDeApoio(true, cenouraPreta.GetCura());

                if (cenouraPreta.GetQuantidade() < 1)
                {
                    contagem++;
                }

                break;

            case "Cenoura Verde":

                if (iT.GetEsperaMenssagem() == false)
                {
                    iT.SetRecebeMenssagem("[X] para Atacar [C] para Curar");
                }

                atirarCenoura.SetItem(cenouraVerde);
                atirarCenoura.SetPodeAtirar(true);

                playerVida.BarraDeApoio(true, cenouraVerde.GetCura());

                if (cenouraVerde.GetQuantidade() < 1)
                {
                    contagem++;
                }
                break;

            case "Super Cenoura Azul":

                if (iT.GetEsperaMenssagem() == false)
                {
                    iT.SetRecebeMenssagem("[C] Ativar Imunidade Ultravioleta [X] para Atacar");
                }

                atirarCenoura.SetItem(superCenouraAzul);
                atirarCenoura.SetPodeAtirar(true);

                playerVida.BarraDeApoio(false, 0);

                if (superCenouraAzul.GetQuantidade() < 1)
                {
                    contagem++;
                }

                break;

            case "Super Cenoura Laranja":

                if (iT.GetEsperaMenssagem() == false)
                {
                    iT.SetRecebeMenssagem("[C] Ativar Regeneração [X] para Atacar");
                }

                atirarCenoura.SetItem(superCenouraLaranja);
                atirarCenoura.SetPodeAtirar(true);

                playerVida.BarraDeApoio(false,0);

                if (superCenouraLaranja.GetQuantidade() < 1)
                {
                    contagem++;
                }

                break;

            case "Super Cenoura Preta":

                if (iT.GetEsperaMenssagem() == false)
                {
                    iT.SetRecebeMenssagem("[C] Ativar Ressuscitar [X] para Atacar");
                }

                atirarCenoura.SetItem(superCenouraPreta);
                atirarCenoura.SetPodeAtirar(true);

                playerVida.BarraDeApoio(false,0);

                if (superCenouraPreta.GetQuantidade() < 1)
                {
                    contagem++;
                }

                break;

            case "Super Cenoura Verde":

                if (iT.GetEsperaMenssagem() == false)
                {
                    iT.SetRecebeMenssagem("[C] Ativar Imunidade Toxicidade [X] para Atacar");
                }

                atirarCenoura.SetItem(superCenouraVerde);
                atirarCenoura.SetPodeAtirar(true);

                playerVida.BarraDeApoio(false, 0);

                if (superCenouraVerde.GetQuantidade() < 1)
                {
                    contagem++;
                }

                break;
        }
    }

}

