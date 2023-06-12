using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial_Detector : MonoBehaviour
{
    public GameObject caixaDialogo;
    public GameObject colisor;
    public GameObject espinho;

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
            caixaDialogo.SetActive(true);

            if (resetEmocional == true)
            {
                controleEmocional.recarregar = false;
                controleEmocional.emocaoSlider.value = 50;
            }
            Destroy(espinho);
            Destroy(colisor);
        }
    }
}
