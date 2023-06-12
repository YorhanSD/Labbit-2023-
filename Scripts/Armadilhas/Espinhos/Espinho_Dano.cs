using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Espinho_Dano : MonoBehaviour
{
    public int danoEspinho = 50;
    Controle_Emocional controleEmocional;
    Player_Vida playerVida;
    
    void Awake()
    {
        playerVida = GameObject.FindObjectOfType<Player_Vida>();
        controleEmocional = GameObject.FindObjectOfType<Controle_Emocional>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && playerVida.GetImuneDano() == false)
        {
            playerVida.SetImuneDano(true);

            playerVida.barraDeVida.value -= danoEspinho;

            controleEmocional.Medo(50);

        }
    }
}
