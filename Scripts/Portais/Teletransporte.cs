using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teletransporte : MonoBehaviour
{
    [Header("Controles do Teletransporte")]

    private Player_PegaItens playerPegaItens;
    private Player_Bencaos playerBencaos;

    public GameObject cam;
    public GameObject tela;
    public string nomeFase;
    public string carregaCena;
    public TextMeshProUGUI textoFase;
    public Transform playerPosicao;
    public float coordenadaX;
    public float coordenadaY;
    public GameObject feedbackPorta;
    public bool portaTrancada;
    public bool ultimaPorta;

    private void Awake()
    {
        playerPegaItens = GameObject.FindObjectOfType<Player_PegaItens>();
        playerBencaos = GameObject.FindObjectOfType<Player_Bencaos>();
    }
    private void Update()
    {
        if (nomeFase != null && textoFase != null)
        {
            textoFase.text = "" + nomeFase;
        }
    }
    //IEnumerator ExibeTela()
    //{
        /*
        tela.SetActive(true);
        yield return new WaitForSeconds(2);
        tela.SetActive(false);
        */
    //}
    void OnTriggerEnter2D(Collider2D _player)
    {
        if (_player.gameObject.tag == "Player")
        {
            if(portaTrancada == false)
            {
                PlayerTeleporte();
            }
            else
            {
                if(playerPegaItens.pegouChave == true)
                {
                    playerPegaItens.pegouChave = false;
                    PlayerTeleporte();
                }
                else
                {
                    feedbackPorta.SetActive(true);
                }
            }
        }
    }
    private void OnTriggerExit2D(Collider2D _player)
    {
        if (_player.gameObject.tag == "Player" && playerPegaItens.pegouChave == false && feedbackPorta != null)
        {
            feedbackPorta.SetActive(false);
        }
    }

    void PlayerTeleporte()
    {
        playerPosicao.position = new Vector2(coordenadaX, coordenadaY);

        cam.transform.position = playerPosicao.position;

        playerBencaos.SetImunidadeToxicidade(false);
        playerBencaos.SetImunidadeUltravioleta(false);

        if (tela != null)
        {
            //StartCoroutine(ExibeTela());
        }

        if (ultimaPorta)
        {
            SceneManager.LoadScene("Cutscene_Final");
        }
    }
}
