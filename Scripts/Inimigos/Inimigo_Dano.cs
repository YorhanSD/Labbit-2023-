using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo_Dano : MonoBehaviour
{
    public int danoInimigo = 30;
    Player_Vida playerVida;
    Controle_Emocional controleEmocional;
    void Awake()
    {
        playerVida = GameObject.FindObjectOfType<Player_Vida>();
        controleEmocional = GameObject.FindObjectOfType<Controle_Emocional>();
    }
    private void OnTriggerEnter2D(Collider2D _player)
    {
        if (_player.CompareTag("Player"))
        {
            if (playerVida.GetImuneDano() != true)
            {
                playerVida.SetImuneDano(true);
                playerVida.barraDeVida.value -= danoInimigo;
                controleEmocional.Medo(50);
            }
        }
    }
}
