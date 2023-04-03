using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    public GameObject apareceGaiola;
    public GameObject telaTutorial;
    Player_Movimento playerMovimento;
    public string[] dialogos;
    
    private void Awake()
    {
        playerMovimento = GameObject.FindObjectOfType<Player_Movimento>();
    }
    private void Start()
    {
        StartCoroutine(tela());
        StartCoroutine(gaiolaAparece());
    }

    IEnumerator tela()
    {
        telaTutorial.SetActive(true);
        yield return new WaitForSeconds(3);
        telaTutorial.SetActive(false);
    }

    IEnumerator gaiolaAparece()
    {
        yield return new WaitForSeconds(22);
        apareceGaiola.SetActive(true);
    }
}
