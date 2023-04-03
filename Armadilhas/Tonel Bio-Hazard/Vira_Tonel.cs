using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vira_Tonel : MonoBehaviour
{
    public GameObject liquidoToxico;
    public Transform pontoDisparo;

    void Start()
    {
        StartCoroutine(vira());
    }

    IEnumerator vira()
    {
        yield return new WaitForSeconds(1f);
        StartCoroutine(dispara());
    }
    
    IEnumerator dispara()
    {
        GameObject liquidoToxicoTemp = (Instantiate(liquidoToxico, pontoDisparo.transform.position, pontoDisparo.transform.rotation));
        yield return new WaitForSeconds(6);
        Destroy(liquidoToxicoTemp);
        StartCoroutine(dispara());
    }
}
