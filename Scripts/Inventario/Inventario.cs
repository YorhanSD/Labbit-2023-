using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventario : MonoBehaviour
{
    public GameObject telaInventario;
    public List<Item> listaItens = new List<Item>();
    Cria_Itens criaItens;

    Cenoura_Azul cenouraAzul;
    Cenoura_Laranja cenouraLaranja;
    Cenoura_Preta cenouraPreta;
    Cenoura_Verde cenouraVerde;

    Super_CenouraAzul superCenouraAzul;
    Super_CenouraLaranja superCenouraLaranja;
    Super_CenouraPreta superCenouraPreta;
    Super_CenouraVerde superCenouraVerde;

    DNA_Azul dnaAzul;
    DNA_Laranja dnaLaranja;
    DNA_Preto dnaPreto;
    DNA_Verde dnaVerde;

    bool abriu;

    private void Awake()
    {
        criaItens = FindObjectOfType<Cria_Itens>();

        cenouraAzul = GameObject.FindObjectOfType<Cenoura_Azul>();
        cenouraLaranja = GameObject.FindObjectOfType<Cenoura_Laranja>();
        cenouraPreta = GameObject.FindObjectOfType<Cenoura_Preta>();
        cenouraVerde = GameObject.FindObjectOfType<Cenoura_Verde>();

        superCenouraAzul = GameObject.FindObjectOfType<Super_CenouraAzul>();
        superCenouraLaranja = GameObject.FindObjectOfType<Super_CenouraLaranja>();
        superCenouraPreta = GameObject.FindObjectOfType<Super_CenouraPreta>();
        superCenouraVerde = GameObject.FindObjectOfType<Super_CenouraVerde>();

        dnaAzul = GameObject.FindObjectOfType<DNA_Azul>();
        dnaLaranja = GameObject.FindObjectOfType<DNA_Laranja>();
        dnaPreto = GameObject.FindObjectOfType<DNA_Preto>();
        dnaVerde = GameObject.FindObjectOfType<DNA_Verde>();
    }

    public void Update()
    {
        if (Input.GetKeyUp(KeyCode.I) && abriu == false)
        {
            telaInventario.SetActive(true);
            abriu = true;
        }
        else if (Input.GetKeyUp(KeyCode.I) && abriu == true)
        {
            telaInventario.SetActive(false);
            abriu = false;
        }
    }

    public bool AdicionaItem(Item _novoItem)
    {
        Checagem(_novoItem); //Checa para ver se o item e repetido

        return true;
    }

    public bool TiraItem(Item _novoItem, int quantidade) //Tira o item pedido de acordo com a quantidade pedida
    {
        ItemQuantidadeControle(_novoItem, quantidade); 

        return true;
    }

    public bool Checagem(Item _novoItem)
    {
        foreach (Item item in listaItens) // Procura na lista de itens o novo item
        {
            if (item.GetNome() == _novoItem.GetNome()) // Verifica se ja existe um item com esse nome
            {
                Debug.Log("O item é repetido");
                ItemQuantidadeControle(_novoItem, 1); // Controla a quantidade dos itens
                return false;
            }
        }

        // Se o item nao existir adicione a lista

        Debug.Log("O item não é repetido");
        listaItens.Add(_novoItem);
        ItemQuantidadeControle(_novoItem, 1);
        return false;
    }

    public void ItemQuantidadeControle(Item _novoItem, int _quantidade)
    {
        if (_novoItem.GetNome() != null) //Se o nome do item for diferente de nulo :
        {
            if (_novoItem.GetNome() == "Cenoura Azul")
            {
                cenouraAzul.SetQuantidade(_quantidade);
            }
            else if (_novoItem.GetNome() == "Cenoura Laranja")
            {
                cenouraLaranja.SetQuantidade(_quantidade);
            }
            else if (_novoItem.GetNome() == "Cenoura Preta")
            {
                cenouraPreta.SetQuantidade(_quantidade);
            }
            else if (_novoItem.GetNome() == "Cenoura Verde")
            {
                cenouraVerde.SetQuantidade(_quantidade);
            }
            else if (_novoItem.GetNome() == "Super Cenoura Azul")
            {
                superCenouraAzul.SetQuantidade(_quantidade);
            }
            else if (_novoItem.GetNome() == "Super Cenoura Laranja")
            {
                superCenouraLaranja.SetQuantidade(_quantidade);
            }
            else if(_novoItem.GetNome() == "Super Cenoura Preta")
            {
                superCenouraPreta.SetQuantidade(_quantidade);
            }
            else if(_novoItem.GetNome() == "Super Cenoura Verde")
            {
                superCenouraVerde.SetQuantidade(_quantidade);
            }
            else if (_novoItem.GetNome() == "DNA Azul")
            {
                dnaAzul.SetQuantidade(_quantidade);

                if(dnaAzul.GetQuantidade() > 1)
                {
                    criaItens.CriaSuperCenouraAzul();

                    TiraItem(_novoItem, -2);
                }
            }
            else if (_novoItem.GetNome() == "DNA Laranja")
            {
                dnaLaranja.SetQuantidade(_quantidade);

                if (dnaLaranja.GetQuantidade() > 1)
                {
                    criaItens.CriaSuperCenouraLaranja();
                    TiraItem(_novoItem, -2);
                }
            }
            else if (_novoItem.GetNome() == "DNA Preto")
            {
                dnaPreto.SetQuantidade(_quantidade);

                if(dnaPreto.GetQuantidade() > 1)
                {
                    criaItens.CriaSuperCenouraPreta();
                    TiraItem(_novoItem, -2);
                }
            }
            else if (_novoItem.GetNome() == "DNA Verde")
            {
                dnaVerde.SetQuantidade(_quantidade);

                if(dnaVerde.GetQuantidade() > 1)
                {
                    criaItens.CriaSuperCenouraVerde();
                    TiraItem(_novoItem, -2);
                }
            }
        }
    }
}