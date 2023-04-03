using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnotacaoControle : MonoBehaviour
{
    public GameObject anotacao;

private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            anotacao.SetActive(true);
            StartCoroutine(Anotacao());
        }
    }

    IEnumerator Anotacao()
    {
        yield return new WaitForSeconds(2f);
        anotacao.SetActive(false);
        //Destroy(gameObject);
    }
}


