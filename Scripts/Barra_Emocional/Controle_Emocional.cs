using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controle_Emocional : MonoBehaviour
{
    Buffs_Nerfs buffsNerfs;
    public Slider emocaoSlider;
    public GameObject fill;
    public GameObject[] indicador;
    public bool recarregar;

    public void Awake()
    {
        buffsNerfs = GameObject.FindObjectOfType<Buffs_Nerfs>();
    }

    public void Start()
    {
        emocaoSlider.value = 50;
    }

    void Update()
    {
        if (emocaoSlider != null)
        {

            NivelEmocional();

            if (emocaoSlider.value == 0)
            {
                indicador[0].SetActive(true);
            }
            else
            {
                indicador[0].SetActive(false);
            }

            if (emocaoSlider.value == 100)
            {
                indicador[1].SetActive(true);
            }
            else
            {
                indicador[1].SetActive(false);
            }

            if (emocaoSlider.value < 0)
            {
                emocaoSlider.value = 0;
            }

            if (emocaoSlider.value > 100)
            {
                emocaoSlider.value = 100;
            }
        }
    }

    void NivelEmocional()
    {
        if (emocaoSlider.value > 99)
        {
            buffsNerfs.CoragemMaxima();
        }

        if (emocaoSlider.value > 0 && emocaoSlider.value < 100)
        {
            buffsNerfs.AtributosNormais();
        }

        if (emocaoSlider.value < 1)
        {
            buffsNerfs.MedoMaximo();
        }
    }

    public void Medo(int _nivelMedo) //Ao tomar dano
    {
        if (emocaoSlider.value != 0 && recarregar == false)
        {
            emocaoSlider.value -= _nivelMedo;

            //ChecagemBarraEmocional();
        }
    }

    public void Coragem(int _nivelCoragem) //Ao matar um inimigo
    {
        if (emocaoSlider.value != 100 && recarregar == false)
        {
            emocaoSlider.value += _nivelCoragem;

            //ChecagemBarraEmocional();
        }
    }

    public void ChecagemBarraEmocional()
    {
        if (emocaoSlider.value <= 0)
        {
            recarregar = true;
            StartCoroutine(AumentaPontos());
        }

        if (emocaoSlider.value >= 100)
        {
            recarregar = true;
            StartCoroutine(DiminuiPontos());
        }
    }

    //Fazer o player voltar ao normal quando estiver com MEDO
    public IEnumerator AumentaPontos()
    {
        yield return new WaitForSeconds(13f); //Depois de X Segundos :

        for (int i = 50; i > emocaoSlider.value;)
        {
            fill.GetComponent<Image>().color = Color.red;

            emocaoSlider.value += 5;

            yield return new WaitForSeconds(2f);

            if (emocaoSlider.value == 50)
            {
                fill.GetComponent<Image>().color = Color.white;

                recarregar = false;
            }
        }
    }
    
    //Fazer o player voltar ao normal quando estiver com CORAGEM
    public IEnumerator DiminuiPontos()
    {
        yield return new WaitForSeconds(13f); //Depois de X Segundos :

        for (int i = 50; i < emocaoSlider.value;)
        {
            fill.GetComponent<Image>().color = Color.red;

            emocaoSlider.value -= 5;

            yield return new WaitForSeconds(2f);

            if (emocaoSlider.value == 50)
            {
                fill.GetComponent<Image>().color = Color.white;

                recarregar = false;
            }
        }
    }
}
