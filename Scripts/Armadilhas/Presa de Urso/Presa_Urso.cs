using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Presa_Urso : MonoBehaviour
{
    public int danoPresa = 30;
    Controle_Emocional controleEmocional;
    Player_Vida playerVida;
    Player_Movimento playerMovimento;
    Animator anim;
    void Awake()
    {
        playerVida = GameObject.FindObjectOfType<Player_Vida>();
        playerMovimento = GameObject.FindObjectOfType<Player_Movimento>();
        controleEmocional = GameObject.FindObjectOfType<Controle_Emocional>();
        anim = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D _player)
    {
        if (_player.gameObject.tag == "Player")
        {
            playerVida.SetImuneDano(true);

            playerMovimento.SetPlayerVelocidade(0);
            playerMovimento.GetPlayerVelocidade();
            playerMovimento.SetPlayerImobilizado(true);
            controleEmocional.Medo(50);

            anim.SetTrigger("Ativar");
            StartCoroutine(TempoImobilizado());
        }
    }

    IEnumerator TempoImobilizado()
    {
        yield return new WaitForSeconds(0.5f);
        playerVida.barraDeVida.value -= danoPresa;
        yield return new WaitForSeconds(5);
        playerMovimento.SetPlayerImobilizado(false);
        anim.SetTrigger("Desativar");

    }
}
