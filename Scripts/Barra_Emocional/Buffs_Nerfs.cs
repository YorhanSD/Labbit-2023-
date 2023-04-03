using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Buffs_Nerfs : MonoBehaviour
{
    private BuffarAndNerffar_Cenouras buffarAndNerffarCenouras;
    private Player_Movimento playerMovimento;

    private Cenoura_Azul cenouraAzul;
    private Cenoura_Laranja cenouraLaranja;
    private Cenoura_Preta cenouraPreta;
    private Cenoura_Verde cenouraVerde;

    private Super_CenouraLaranja superCenouraLaranja;
    private Super_CenouraVerde superCenouraVerde;
    private Super_CenouraPreta superCenouraPreta;

    void Start()
    {
        buffarAndNerffarCenouras = GameObject.FindObjectOfType<BuffarAndNerffar_Cenouras>();
        playerMovimento = GameObject.FindObjectOfType<Player_Movimento>();

        cenouraAzul = GameObject.FindObjectOfType<Cenoura_Azul>();
        cenouraLaranja = GameObject.FindObjectOfType<Cenoura_Laranja>();
        cenouraPreta = GameObject.FindObjectOfType<Cenoura_Preta>();
        cenouraVerde = GameObject.FindObjectOfType<Cenoura_Verde>();

        superCenouraLaranja = GameObject.FindObjectOfType<Super_CenouraLaranja>();
        superCenouraVerde = GameObject.FindObjectOfType<Super_CenouraVerde>();
        superCenouraPreta = GameObject.FindObjectOfType<Super_CenouraPreta>();
    }

    public void CoragemMaxima() //Metodo coragem maxima
    {
        playerMovimento.SetPlayerVelocidade(+20);
        playerMovimento.SetPlayerForcaPulo(+45);

        buffarAndNerffarCenouras.BuffarDanoCenouras(20, 60);
    }

    public void AtributosNormais() //Atributos Padroes
    {
        playerMovimento.SetPlayerVelocidade(+15);
        playerMovimento.SetPlayerForcaPulo(+35);

        cenouraLaranja.SetDano(10);
        cenouraPreta.SetDano(30);

        cenouraLaranja.SetCura(30);
        cenouraPreta.SetCura(10);

        superCenouraLaranja.SetDano(20);
        superCenouraPreta.SetDano(80);
    }

    public void MedoMaximo() //Medo Maximo
    {
        playerMovimento.SetPlayerVelocidade(+30);
        playerMovimento.SetPlayerForcaPulo(+40);

        buffarAndNerffarCenouras.BuffarCuraCenouras(40, 60);
    }
}