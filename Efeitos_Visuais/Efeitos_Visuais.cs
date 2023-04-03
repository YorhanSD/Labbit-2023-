using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;


public class Efeitos_Visuais : MonoBehaviour
{
    public bool tutorialAtivado;
    Controle_Emocional controleEmocional;

    public GameObject medoTela;
    public GameObject coragemTela;
    public GameObject luzGlobal;

    void Awake()
    {
        tutorialAtivado = true;
        controleEmocional = GameObject.FindObjectOfType<Controle_Emocional>();
    }

    void Update()
    {
        if(controleEmocional.emocaoSlider.value == 100)
        {
            AtivaTelaCoragem();
        }
        else if (controleEmocional.emocaoSlider.value == 0)
        {
            AtivaTelaMedo();
        }
        else
        {
            AtivaTelaNormal();
        }
    }

    public void AtivaTelaNormal()
    {
        coragemTela.SetActive(false);
        medoTela.SetActive(false);
        
        luzGlobal.SetActive(true);
    }

    public void AtivaTelaCoragem() 
    {
        luzGlobal.SetActive(false);
        coragemTela.SetActive(true);
    }

    public void AtivaTelaMedo()
    {
        luzGlobal.SetActive(false);
        medoTela.SetActive(true);
    }
}
