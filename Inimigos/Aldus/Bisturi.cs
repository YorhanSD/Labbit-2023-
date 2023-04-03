using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bisturi : MonoBehaviour
{
    public int dano = 20;
    public float tempoDestruicao = 3f;


    private Player_Vida playerVida;
    private Controle_Emocional controleEmocional;

    void Awake()
    {
        playerVida = GameObject.FindObjectOfType<Player_Vida>();
        controleEmocional = GameObject.FindObjectOfType<Controle_Emocional>();
        
    }
    public void Start()
    {
        Destruir();
    }
 
    public void OnTriggerEnter2D(Collider2D _player)
    {
        if (_player.gameObject.tag == "Player" && playerVida.GetImuneDano() == false)
        {
            playerVida.SetImuneDano(true);
            playerVida.barraDeVida.value -= dano;
            controleEmocional.Medo(50);
            Destroy(gameObject);
        }
    }
   
    void Destruir()
    {
        Destroy(gameObject, tempoDestruicao);
    }
}
