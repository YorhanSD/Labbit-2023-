using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial_Botoes: MonoBehaviour
{
    public GameObject[] caixaDialogo;

    public void BotaoFechaCaixa()
    {
        Destroy(caixaDialogo[0]);
        Time.timeScale = 1f;

    }
    public void BotaoFechaCaixa2()
    {
        Destroy(caixaDialogo[1]);
        Time.timeScale = 1f;
    }

    public void BotaoFechaCaixa3()
    {
        Destroy(caixaDialogo[2]);
        Time.timeScale = 1f;
    }
}
