using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inimigo_Vida : MonoBehaviour
{
    public float vidaCompleta = 50;
    public bool permitirDrop = true;
    public bool imunidadeCenouras = false;
    private int randomProbabilidade;

    public Text vidaTexto;
    public Slider barraDeVida;
    public GameObject[] dropItem;
    public GameObject inimigo;

    Player_Vida playerVida;
    Controle_Emocional controleEmocional;

    private Cenoura_Azul cenouraAzul;
    private Cenoura_Laranja cenouraLaranja;
    private Cenoura_Preta cenouraPreta;
    private Cenoura_Verde cenouraVerde;
    private Super_CenouraLaranja superCenouraLaranja;
    private Super_CenouraVerde superCenouraVerde;
    private Super_CenouraPreta superCenouraPreta;

    void Awake()
    {
        playerVida = GameObject.FindObjectOfType<Player_Vida>();
        controleEmocional = GameObject.FindObjectOfType<Controle_Emocional>();


        cenouraAzul = GameObject.FindObjectOfType<Cenoura_Azul>();
        cenouraLaranja = GameObject.FindObjectOfType<Cenoura_Laranja>();
        cenouraPreta = GameObject.FindObjectOfType<Cenoura_Preta>();
        cenouraVerde = GameObject.FindObjectOfType<Cenoura_Verde>();

        superCenouraLaranja = GameObject.FindObjectOfType<Super_CenouraLaranja>();
        superCenouraVerde = GameObject.FindObjectOfType<Super_CenouraVerde>();
        superCenouraPreta = GameObject.FindObjectOfType<Super_CenouraPreta>();

    }
    
    private void Update()
    {
        vidaTexto.text = vidaCompleta + " / " + barraDeVida.value;

        if (barraDeVida.value <= 0)
        {
            if (permitirDrop == true)
            {
                Drop();
            }

            GanharCoragem(50);
            Morte();
        }
    }
    private void OnTriggerEnter2D(Collider2D _other)
    {
        if (imunidadeCenouras == false)
        {
            if (_other.CompareTag("CenouraAzul"))
            {
                TomaDano(cenouraAzul.GetDano());
            }
            if (_other.CompareTag("CenouraLaranja"))
            {
                TomaDano(cenouraLaranja.GetDano());
            }
            if (_other.CompareTag("CenouraPreta"))
            {
                TomaDano(cenouraPreta.GetDano());
            }
            if (_other.CompareTag("CenouraVerde"))
            {
                TomaDano(cenouraVerde.GetDano());
            }
        }

        if (_other.CompareTag("SuperCenouraLaranja"))
        {
            TomaDano(superCenouraLaranja.GetDano());

            playerVida.barraDeVida.value += superCenouraLaranja.GetCura();
        }
        if (_other.CompareTag("SuperCenouraPreta"))
        {
            TomaDano(superCenouraPreta.GetDano());
        }
        if (_other.CompareTag("SuperCenouraVerde"))
        {
            TomaDano(superCenouraVerde.GetDano());
        }
    }
    public void Drop()
    {
        randomProbabilidade = Random.Range(0, 2);

        Instantiate(dropItem[randomProbabilidade], gameObject.transform.position, gameObject.transform.rotation);

        Debug.Log("Dropou DNA Resultado : " + randomProbabilidade);
    }
    private void TomaDano(int _dano)
    {
        barraDeVida.value -= _dano;
    }
    private void GanharCoragem(int _nivelCoragem)
    {
        controleEmocional.Coragem(_nivelCoragem);
    }
    private void Morte()
    {
        Destroy(gameObject);
    }
}
