using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Anotacoes : MonoBehaviour
{
    public GameObject caixaDialogo;
    private bool podeFechar = false;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && podeFechar == true || Input.GetKeyUp(KeyCode.Return) && podeFechar == true)
        {
            BotaoFechaAnotacao();
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            podeFechar = true;

            caixaDialogo.SetActive(true);

            //Time.timeScale = 0f;
        }
    }

    public void BotaoFechaAnotacao()
    {
        Destroy(gameObject);
        Time.timeScale = 1f;
    }
}
