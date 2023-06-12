using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dano_Eletrico : MonoBehaviour
{
    Player_Vida playerVida;
    Controle_Emocional controleEmocional;
    public int danoEletrico;

    public void Awake()
    {
        playerVida = GameObject.FindObjectOfType<Player_Vida>();
        controleEmocional = GameObject.FindObjectOfType<Controle_Emocional>();
    }

    public void OnTriggerEnter2D(Collider2D _player)
    {
        if (_player.gameObject.tag == "Player" && playerVida.GetImuneDano() == false)
        {
            playerVida.SetImuneDano(true);
            playerVida.barraDeVida.value -= danoEletrico;
            controleEmocional.Medo(70);
        }
    }
}
