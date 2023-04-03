using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Argola : MonoBehaviour
{
    public GameObject detector;

    public void OnTriggerEnter2D(Collider2D _player)
    {
        if (_player.gameObject.CompareTag("Player"))
        {
           StartCoroutine(EsperarII());
        }
    }
    public void OnTriggerExit2D(Collider2D _player)
    {
        if (_player.gameObject.CompareTag("Player"))
        {
           StartCoroutine(Esperar());
        }
    }

    IEnumerator Esperar(){

        yield return new WaitForSeconds(1f);
        detector.SetActive(false);
    }
    IEnumerator EsperarII(){

        yield return new WaitForSeconds(0.1f);
        detector.SetActive(true);
    }
    
}
