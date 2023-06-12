using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Graficos : MonoBehaviour
{
    public Toggle botaoFPS;
    public TextMeshProUGUI textoFPS;
    public GameObject contadorFPS;
    public void BotaoUltra()
    {
        QualitySettings.SetQualityLevel(6);
    }
    public void BotaoHigh()
    {
        QualitySettings.SetQualityLevel(5);
    }
    public void BotaoMedium()
    {
        QualitySettings.SetQualityLevel(2);
    }
    public void BotaoLow()
    {
        QualitySettings.SetQualityLevel(1);
    }
    public void BotaoVeryLow()
    {
        QualitySettings.SetQualityLevel(0);
    }
    public void CalculaFPS()
    {
        textoFPS.text = "FPS " + (1f / Time.deltaTime).ToString("00");
    }
    private void Start()
    {
        InvokeRepeating(nameof(CalculaFPS), 0f, 1f);
    }
    private void Update()
    {
        if(botaoFPS.isOn == true && botaoFPS != null)
        {
            contadorFPS.SetActive(true);
        }
        else
        {
            contadorFPS.SetActive(false);
        }
    }
}
