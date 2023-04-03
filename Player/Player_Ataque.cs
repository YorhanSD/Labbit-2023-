using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Ataque : MonoBehaviour
{
    public GameObject[] cenouraPrefab;
    private int contador = 0;
    private Inventario inventario;
    private Atirar_Cenoura atirarCenoura;
    private Player_Movimento playerMovimento;
    private Player_Vida playerVida;
    private Cria_Itens criaItens;
    private Animator anim;
    public AudioSource aS;
    public AudioClip audioAtaque;
    public AudioClip audioCura;
    bool podeAtacar = true;

    private void Awake()
    { 
        anim = GetComponent<Animator>();
        atirarCenoura = GameObject.FindObjectOfType<Atirar_Cenoura>();
        playerMovimento = GameObject.FindObjectOfType<Player_Movimento>();
        playerVida = GameObject.FindObjectOfType<Player_Vida>();
        inventario = GameObject.FindObjectOfType<Inventario>();
        criaItens = GameObject.FindObjectOfType<Cria_Itens>();

    }

    private void Start()
    {
        aS = GetComponent<AudioSource>();
    }

    IEnumerator EsperaAnimacaoAtaque()
    {
        anim.SetTrigger("Hitting");
        yield return new WaitForSeconds(0.3f);
        podeAtacar = true;
        CenouraMovimento();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X) || Input.GetMouseButtonDown(1) || Input.GetKeyDown("joystick button 5") && podeAtacar == true) // Controle do tiro
        {
            podeAtacar = false;

            if (atirarCenoura.GetPodeAtirar() == true)
            {
                aS.clip = audioAtaque;
                aS.Play();

                if (atirarCenoura.GetItem().GetQuantidade() > 0)
                {
                    VerificaCenoura(atirarCenoura.GetItem());
                    atirarCenoura.SetPodeAtirar(false);
                    atirarCenoura.GetPodeAtirar();
                    inventario.TiraItem(atirarCenoura.GetItem(),-1);
                    StartCoroutine(EsperaAnimacaoAtaque());
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.C) || Input.GetKeyDown("joystick button 4")) // Controle comer cenoura
        {
            if (atirarCenoura.GetPodeAtirar() == true)
            {
                if (atirarCenoura.GetItem().GetQuantidade() > 0)
                {
                    aS.clip = audioCura;
                    aS.Play();

                    atirarCenoura.SetPodeAtirar(false);
                    atirarCenoura.GetPodeAtirar();

                    playerVida.barraDeVida.value += atirarCenoura.GetItem().GetCura();

                    if (atirarCenoura.GetItem().GetNome() == "Super Cenoura Preta")
                    {
                        playerVida.Ressuscitar(true);
                    }
                    else if (atirarCenoura.GetItem().GetNome() == "Super Cenoura Laranja")
                    {
                        playerVida.Regeneracao(true);
                    }
                    else if (atirarCenoura.GetItem().GetNome() == "Super Cenoura Azul")
                    {
                        playerVida.ImunidadeUltravioleta(true);
                    }
                    else if (atirarCenoura.GetItem().GetNome() == "Super Cenoura Verde")
                    {
                        criaItens.CriaCenouraVerde();
                    }
                    inventario.TiraItem(atirarCenoura.GetItem(),-1);
                }
            }
        }
    }

    public void VerificaCenoura(Item _item)
    {
        switch (_item.GetNome())
        {
            case "Cenoura Azul":
                contador = 0;
                break;
            case "Cenoura Laranja":
                contador = 1;
                break;
            case "Cenoura Preta":
                contador = 2;
                break;
            case "Cenoura Verde":
                contador = 3;
                break;
            case "Super Cenoura Azul":
                contador = 4;
                break;
            case "Super Cenoura Laranja":
                contador = 5;
                break;
            case "Super Cenoura Preta":
                contador = 6;
                break;
            case "Super Cenoura Verde":
                contador = 7;
                break;
        }
    }

    public void CenouraMovimento()
    {
        //cria um clone de uma cenoura no ponto de disparo
        //Atira a cenoura conforme a direcao do player
        GameObject cenouraTemp = (GameObject)(Instantiate(cenouraPrefab[contador], playerMovimento.pontoDisparo.transform.position, Quaternion.identity));

        if (playerMovimento.ladoDireito)
        {
            cenouraTemp.GetComponent<Item>().Direcao(Vector2.right);
        }
        else
        {
            //Direciona a cenoura conforme a direcao que o personagem aponta
            //Chama o metodo inicializar com o componente de direcao do script da cenoura 
            cenouraTemp.GetComponent<Item>().Direcao(Vector2.left);
        }
    }
}
