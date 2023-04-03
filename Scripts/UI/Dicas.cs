using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dicas : MonoBehaviour
{
    public GameObject dica;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            //dica.SetActive(true);
            //StartCoroutine(DicaTempo());
        }
    }

    IEnumerator DicaTempo()
    {
        yield return new WaitForSeconds(2f);
        dica.SetActive(false);
        Destroy(gameObject);
    }
}
