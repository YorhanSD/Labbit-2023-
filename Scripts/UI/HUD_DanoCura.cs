using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD_DanoCura : MonoBehaviour
{
    public Text[] danoTxt;
    public Text[] curaTxt;
    public GameObject[] painelHUD;

    public void HUDCenouraLaranja(int dano, int cura, bool _pegouCenoura)
    {
        danoTxt[0].text = "" + dano;
        curaTxt[0].text = "" + cura;

        if (_pegouCenoura)
        {
            painelHUD[0].SetActive(true);
        }
        else
        {
            painelHUD[0].SetActive(false);
        }
    }

    public void HUDCenouraPreta(int dano, int cura, bool _pegouCenoura)
    {
        danoTxt[1].text = "" + dano;
        curaTxt[1].text = "" + cura;

        if (_pegouCenoura)
        {
            painelHUD[1].SetActive(true);
        }
        else
        {
            painelHUD[1].SetActive(false);
        }
    }

    public void HUDCenouraAzul(int dano, int cura, bool _pegouCenoura)
    {
        danoTxt[2].text = "" + dano;
        curaTxt[2].text = "" + cura;

        if (_pegouCenoura)
        {
            painelHUD[2].SetActive(true);
        }
        else
        {
            painelHUD[2].SetActive(false);
        }
    }

    public void HUDCenouraVerde(int dano, int cura, bool _pegouCenoura)
    {
        danoTxt[3].text = "" + dano;
        curaTxt[3].text = "" + cura;

        if (_pegouCenoura)
        {
            painelHUD[3].SetActive(true);
        }
        else
        {
            painelHUD[3].SetActive(false);
        }
    }

    
}
