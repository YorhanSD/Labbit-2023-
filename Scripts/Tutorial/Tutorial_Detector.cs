using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial_Detector : MonoBehaviour
{
    public GameObject colisor;

    public GameObject caixaDialogo;

    public bool resetEmocional;

    Controle_Emocional controleEmocional;

    void Awake()
    {
        controleEmocional = GameObject.FindObjectOfType<Controle_Emocional>();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(colisor);

            caixaDialogo.SetActive(true);

            Time.timeScale = 0f;

            if (resetEmocional == true)
            {
                controleEmocional.recarregar = false;
                controleEmocional.emocaoSlider.value = 50;
            }

            Destroy(gameObject);
        }
    }
}
