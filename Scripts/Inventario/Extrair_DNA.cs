using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Extrair_DNA : MonoBehaviour
{
    public int[] quantidade;
    public int probabilidade;
    public int randomProbabilidade;
    Inventario inventario;
    Seleciona_Itens selecionaItens;
    Cenoura_Azul cenouraAzul;
    Cenoura_Laranja cenouraLaranja;
    Cenoura_Preta cenouraPreta;
    Cenoura_Verde cenouraVerde;
    bool abriu;
    public GameObject telaExtracao;
    public Text[] quantidadeTexto;
    public Text resultadoProbabilidade;

    DNA_Azul dnaAzul;
    DNA_Laranja dnaLaranja;
    DNA_Preto dnaPreto;
    DNA_Verde dnaVerde;

    void Awake()
    {
        inventario = GameObject.FindObjectOfType<Inventario>();
        selecionaItens = GameObject.FindObjectOfType<Seleciona_Itens>();

        cenouraAzul = GameObject.FindObjectOfType<Cenoura_Azul>();
        cenouraLaranja = GameObject.FindObjectOfType<Cenoura_Laranja>();
        cenouraPreta = GameObject.FindObjectOfType<Cenoura_Preta>();
        cenouraVerde = GameObject.FindObjectOfType<Cenoura_Verde>();

        dnaAzul = GameObject.FindObjectOfType<DNA_Azul>();
        dnaLaranja = GameObject.FindObjectOfType<DNA_Laranja>();
        dnaPreto = GameObject.FindObjectOfType<DNA_Preto>();
        dnaVerde = GameObject.FindObjectOfType<DNA_Verde>();
    }

    void Update()
    {
        resultadoProbabilidade.text = " " + randomProbabilidade + "% = " + probabilidade;

        quantidadeTexto[0].text = "x " + quantidade[0];
        quantidadeTexto[1].text = "x " + quantidade[1];
        quantidadeTexto[2].text = "x " + quantidade[2];
        quantidadeTexto[3].text = "x " + quantidade[3];

        if (Input.GetKeyUp(KeyCode.G) && abriu == false)
        {
            telaExtracao.SetActive(true);
            abriu = true;
        }
        else if (Input.GetKeyUp(KeyCode.G) && abriu == true)
        {
            telaExtracao.SetActive(false);
            abriu = false;
        }
    }

    public void ProbabilidadeDNA()
    {
        randomProbabilidade = Random.Range(0, 100);

        if (randomProbabilidade >= 75)
        {
            probabilidade = 4;
        }
        else if (randomProbabilidade >= 50)
        {
            probabilidade = 3;
        }
        else if (randomProbabilidade >= 25)
        {
            probabilidade = 2;
        }
        else if (randomProbabilidade <= 24)
        {
            probabilidade = 1;
        }
    }

    public void BotaoExtrairDNA()
    {
        
        Debug.Log("Clicou no botão extrair");

        switch (inventario.listaItens[selecionaItens.contagem].GetNome())//No inventario na lista de itens usando a contagem da selecao de itens para ver se existe algum item com um nome
        {
            case "Cenoura Azul" :
                if (cenouraAzul.GetQuantidade() > 0) //Se o numero de cenouras azuis for maior q zero entao :
                {
                    cenouraAzul.SetQuantidade(-1); //Usa uma cenoura azul
                    //Cria DNA Azul
                    Debug.Log("Extraiu DNA azul");

                    ProbabilidadeDNA();
                    quantidade[0] += probabilidade; //Cria DNA´S de acordo com a probabilidade
                    dnaAzul.SetQuantidade(+probabilidade);
                }
                break;
            case "Cenoura Laranja" :
                if (cenouraLaranja.GetQuantidade() > 0)
                {
                    cenouraLaranja.SetQuantidade(-1);
                    //Cria DNA Laranja
                    Debug.Log("Extraiu DNA laranja");

                    ProbabilidadeDNA();
                    quantidade[1] += probabilidade;
                    dnaLaranja.SetQuantidade(+probabilidade);
                }

                break;
            case "Cenoura Preta" :
                if (cenouraPreta.GetQuantidade() > 0)
                {
                    cenouraPreta.SetQuantidade(-1);
                    //Cria DNA Preto
                    Debug.Log("Extraiu DNA Preto");

                    ProbabilidadeDNA();
                    quantidade[2] += probabilidade;
                    dnaPreto.SetQuantidade(+probabilidade);
                }

                break;
            case "Cenoura Verde" :
                if (cenouraVerde.GetQuantidade() > 0)
                {
                    cenouraVerde.SetQuantidade(-1);
                    //Cria DNA Verde
                    Debug.Log("Extraiu DNA Verde");

                    ProbabilidadeDNA();
                    quantidade[3] += probabilidade;
                    dnaVerde.SetQuantidade(+probabilidade);
                }
                break;
                default:
                Debug.Log("Cenoura não encontrada");
                break;
        
        }
     
    }

}
