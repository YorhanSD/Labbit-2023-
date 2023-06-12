using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataforma_Temporaria : MonoBehaviour
{
    public GameObject plataformaTemporaria;
    public float tempoSome = 1.5f;
    public void OnTriggerEnter2D(Collider2D _player)
    {
        if (_player.gameObject.CompareTag("Player"))
        {
            StartCoroutine(Sumir());
        }
    }
    public IEnumerator Sumir()
    {
        yield return new WaitForSeconds(tempoSome);
        plataformaTemporaria.SetActive(false);
        yield return new WaitForSeconds(tempoSome);
        plataformaTemporaria.SetActive(true);
    }
}
