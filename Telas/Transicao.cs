using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transicao : MonoBehaviour
{
    Player_Movimento playerMovimento;

    public GameObject ativaTela;

    Efeitos_Visuais efeitosVisuais;

    void Awake()
    {
        playerMovimento = GameObject.FindObjectOfType<Player_Movimento>();
        efeitosVisuais = GameObject.FindObjectOfType<Efeitos_Visuais>();
    }

    private void Start()
    {
        StartCoroutine(telaTransicao());
    }

    void OnTriggerEnter2D(Collider2D _player)
    {
        if (_player.gameObject.tag == "Player")
        {
            ativaTela.SetActive(true);
            StartCoroutine(telaTransicao());
            efeitosVisuais.tutorialAtivado = false;
        }
    }

    IEnumerator telaTransicao()
    {
        yield return new WaitForSeconds(3);
        ativaTela.SetActive(false);
    }
}
