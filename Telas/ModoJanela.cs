using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModoJanela : MonoBehaviour
{
    public Toggle modoJanela;
    public void BotaoModoJanela()
    {
        if (modoJanela.isOn)
        {
            Screen.fullScreen = false;
        }
        else
        {
            Screen.fullScreen = true;
        }
    }
}
