using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Buffs_Nerfs : MonoBehaviour
{
    private BuffNerff_Cenouras buffarAndNerffarCenouras;
    private Player_Movimento playerMovimento;

    private Cenoura_Azul cenouraAzul;
    private Cenoura_Laranja cenouraLaranja;
    private Cenoura_Preta cenouraPreta;
    private Cenoura_Verde cenouraVerde;

    private Super_CenouraAzul superCenouraAzul;
    private Super_CenouraLaranja superCenouraLaranja;
    private Super_CenouraVerde superCenouraVerde;
    private Super_CenouraPreta superCenouraPreta;

    void Start()
    {
        buffarAndNerffarCenouras = GameObject.FindObjectOfType<BuffNerff_Cenouras>();
        playerMovimento = GameObject.FindObjectOfType<Player_Movimento>();

        cenouraAzul = GameObject.FindObjectOfType<Cenoura_Azul>();
        cenouraLaranja = GameObject.FindObjectOfType<Cenoura_Laranja>();
        cenouraPreta = GameObject.FindObjectOfType<Cenoura_Preta>();
        cenouraVerde = GameObject.FindObjectOfType<Cenoura_Verde>();

        superCenouraAzul = GameObject.FindObjectOfType<Super_CenouraAzul>();
        superCenouraLaranja = GameObject.FindObjectOfType<Super_CenouraLaranja>();
        superCenouraVerde = GameObject.FindObjectOfType<Super_CenouraVerde>();
        superCenouraPreta = GameObject.FindObjectOfType<Super_CenouraPreta>();
    }

    public void CoragemMaxima() //Metodo coragem maxima
    {
        playerMovimento.SetPlayerVelocidade(20);
        playerMovimento.SetPlayerForcaPulo(45);

        buffarAndNerffarCenouras.BuffarDanoCenouras();
    }

    public void AtributosNormais() //Atributos Padroes
    {
        playerMovimento.SetPlayerVelocidade(15);
        playerMovimento.SetPlayerForcaPulo(35);

        cenouraLaranja.SetDano(10);
        cenouraLaranja.SetCura(30);

        cenouraPreta.SetDano(30);
        cenouraPreta.SetCura(10);

        cenouraVerde.SetDano(20);
        cenouraVerde.SetCura(20);

        cenouraAzul.SetDano(30);
        cenouraAzul.SetCura(30);

        superCenouraLaranja.SetDano(10);
        superCenouraPreta.SetDano(80);
        superCenouraVerde.SetDano(60);
        superCenouraAzul.SetDano(20);
    }

    public void MedoMaximo() //Medo Maximo
    {
        playerMovimento.SetPlayerVelocidade(30);
        playerMovimento.SetPlayerForcaPulo(40);

        buffarAndNerffarCenouras.BuffarCuraCenouras();
    }
}