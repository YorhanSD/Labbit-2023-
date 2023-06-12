using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;


public class Efeitos_Visuais : MonoBehaviour
{
    Controle_Emocional controleEmocional;

    public GameObject medoTela;
    public GameObject coragemTela;
    public GameObject luzGlobal;

    public Image[] imagens;

    void Awake()
    {
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

        //imagens[0].color = Color.gray;
    }

    public void AtivaTelaCoragem() 
    {
        luzGlobal.SetActive(false);
        coragemTela.SetActive(true);

        //float valor = Mathf.PingPong(Time.time, 1f);
        
        //imagens[0].color = new Vector4(255, 0, 0, valor);
    }

    public void AtivaTelaMedo()
    {
        luzGlobal.SetActive(false);
        medoTela.SetActive(true);

        //float valor = Mathf.PingPong(Time.time, 1f);
       
        //imagens[0].color = new Vector4(0, 255, 0, valor);
    }
}
