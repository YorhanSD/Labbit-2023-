using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Campo_Eletrico : MonoBehaviour
{
    public GameObject CampoEletrico;

    public void OnTriggerEnter2D(Collider2D _cenoura)
    {
        if (_cenoura.gameObject.tag == "Cenoura")
        {
            StartCoroutine(DesativaCampoEletrico());
        }
    }

    IEnumerator DesativaCampoEletrico()
    {
        CampoEletrico.SetActive(false);

        yield return new WaitForSeconds(3);

        CampoEletrico.SetActive(true);

    }
}
