using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player_PegaItens : MonoBehaviour
{
    Cria_Itens criaItens;
    void Awake()
    {
        criaItens = GameObject.FindObjectOfType<Cria_Itens>();
    }
   
    private void OnTriggerEnter2D(Collider2D _Player)
    {
        if(_Player.gameObject.name == "Cenoura Azul")
        {
            criaItens.CriaCenouraAzul();
        }
        if (_Player.gameObject.name == "Cenoura Laranja")
        {
            criaItens.CriaCenouraLaranja();
        }
        if (_Player.gameObject.name == "Cenoura Preta")
        {
            criaItens.CriaCenouraPreta();
        }
        if (_Player.gameObject.name == "Cenoura Verde")
        {
            criaItens.CriaCenouraVerde();
        }
        if (_Player.gameObject.tag == "DNA Azul")
        {
            criaItens.CriaDNAAzul();
        }
        if (_Player.gameObject.tag == "DNA Laranja")
        {
            criaItens.CriaDNALaranja();
        }
        if (_Player.gameObject.tag == "DNA Preto")
        {
            criaItens.CriaDNAPreto();
        }
        if (_Player.gameObject.tag == "DNA Verde")
        {
            criaItens.CriaDNAVerde();
        }
    }
}
