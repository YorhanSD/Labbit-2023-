using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class UI_ItemQuantidade : MonoBehaviour
{
    Cenoura_Azul cenouraAzul;
    Cenoura_Laranja cenouraLaranja;
    Cenoura_Preta cenouraPreta;
    Cenoura_Verde cenouraVerde;

    Super_CenouraAzul superCenouraAzul;
    Super_CenouraLaranja superCenouraLaranja;
    Super_CenouraPreta superCenouraPreta;
    Super_CenouraVerde superCenouraVerde;

    public GameObject player;
    public Text[] itemQuantidade;
    public GameObject[] imagens;

    void Awake()
    {
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
            TextoCenouraQuantidade();
            ControleQuantidade();
        }
    }

    void TextoCenouraQuantidade()
    {
        itemQuantidade[0].text = "x " + cenouraAzul.GetQuantidade();
        itemQuantidade[1].text = "x " + cenouraLaranja.GetQuantidade();
        itemQuantidade[2].text = "x " + cenouraPreta.GetQuantidade();
        itemQuantidade[3].text = "x " + cenouraVerde.GetQuantidade();

        itemQuantidade[4].text = "x " + superCenouraAzul.GetQuantidade();
        itemQuantidade[5].text = "x " + superCenouraLaranja.GetQuantidade();
        itemQuantidade[6].text = "x " + superCenouraPreta.GetQuantidade();
        itemQuantidade[7].text = "x " + superCenouraVerde.GetQuantidade();

    }
    void ControleQuantidade()
    {
        MudaCorCenouraAzul();
        MudaCorCenouraLaranja();
        MudaCorCenouraPreta();
        MudaCorCenouraVerde();

        MudaCorSuperCenouraAzul();
        MudaCorSuperCenouraLaranja();
        MudaCorSuperCenouraPreta();
        MudaCorSuperCenouraVerde();
    }

    private bool MudaCorCenouraAzul()
    {
        if (cenouraAzul.GetQuantidade() > 0)
        {
            imagens[0].GetComponent<Image>().color = Color.white;

            return false;
        }

        imagens[0].GetComponent<Image>().color = Color.black;

        return false;
    }
    private bool MudaCorCenouraLaranja()
    {
        if (cenouraLaranja.GetQuantidade() > 0)
        {
            imagens[1].GetComponent<Image>().color = Color.white;

            return false;
        }

        imagens[1].GetComponent<Image>().color = Color.black;
        
        return false;
    }
    private bool MudaCorCenouraPreta()
    {
        if (cenouraPreta.GetQuantidade() > 0)
        {
            imagens[2].GetComponent<Image>().color = Color.white;

            return false;
        }

        imagens[2].GetComponent<Image>().color = Color.black;

        return false;
    }
    private bool MudaCorCenouraVerde()
    {
        if (cenouraVerde.GetQuantidade() > 0)
        {
            imagens[3].GetComponent<Image>().color = Color.white;

            return false;
        }

        imagens[3].GetComponent<Image>().color = Color.black;

        return false;
    }

    private bool MudaCorSuperCenouraAzul()
    {
        if(superCenouraAzul.GetQuantidade() > 0)
        {
            imagens[4].GetComponent<Image>().color = Color.white;

            return false;
        }

        imagens[4].GetComponent<Image>().color = Color.black;

        return false;
    }

    private bool MudaCorSuperCenouraLaranja()
    {
        if (superCenouraLaranja.GetQuantidade() > 0)
        {
            imagens[5].GetComponent<Image>().color = Color.white;

            return false;
        }

        imagens[5].GetComponent<Image>().color = Color.black;

        return false;
    }

    private bool MudaCorSuperCenouraPreta()
    {
        if (superCenouraPreta.GetQuantidade() > 0)
        {
            imagens[6].GetComponent<Image>().color = Color.white;

            return false;
        }

        imagens[6].GetComponent<Image>().color = Color.black;

        return false;
    }

    private bool MudaCorSuperCenouraVerde()
    {
        if (superCenouraVerde.GetQuantidade() > 0)
        {
            imagens[7].GetComponent<Image>().color = Color.white;

            return false;
        }

        imagens[7].GetComponent<Image>().color = Color.black;

        return false;
    }
}
