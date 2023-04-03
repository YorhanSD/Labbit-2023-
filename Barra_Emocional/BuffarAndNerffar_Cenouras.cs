using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffarAndNerffar_Cenouras : MonoBehaviour
{
    private Cenoura_Azul cenouraAzul;
    private Cenoura_Laranja cenouraLaranja;
    private Cenoura_Preta cenouraPreta;
    private Cenoura_Verde cenouraVerde;

    private Super_CenouraAzul superCenouraAzul;
    private Super_CenouraLaranja superCenouraLaranja;
    private Super_CenouraVerde superCenouraVerde;
    private Super_CenouraPreta superCenouraPreta;

    void Awake()
    {
        //As cenouras precisam estar na cena

        cenouraAzul = GameObject.FindObjectOfType<Cenoura_Azul>();
        cenouraLaranja = GameObject.FindObjectOfType<Cenoura_Laranja>();
        cenouraPreta = GameObject.FindObjectOfType<Cenoura_Preta>();
        cenouraVerde = GameObject.FindObjectOfType<Cenoura_Verde>();

        superCenouraAzul = GameObject.FindObjectOfType<Super_CenouraAzul>();
        superCenouraLaranja = GameObject.FindObjectOfType<Super_CenouraLaranja>();
        superCenouraVerde = GameObject.FindObjectOfType<Super_CenouraVerde>();
        superCenouraPreta = GameObject.FindObjectOfType<Super_CenouraPreta>();
    }

    public void BuffarDanoCenouras(int _Buff1, int _Buff2)
    {
        cenouraLaranja.SetDano(_Buff1);
        cenouraPreta.SetDano(_Buff2);

        superCenouraLaranja.SetDano(_Buff1);
        superCenouraPreta.SetDano(_Buff2);
    }
    public void BuffarCuraCenouras(int _Buff1, int _Buff2)
    {
        cenouraLaranja.SetCura(_Buff2);
        cenouraPreta.SetCura(_Buff1);
    }
}
