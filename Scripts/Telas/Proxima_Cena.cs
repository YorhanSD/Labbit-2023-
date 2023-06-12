using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Proxima_Cena : MonoBehaviour
{
    public string cena;
    void Start()
    {
        StartCoroutine(esperaCena());
    }

    IEnumerator esperaCena()
    {
        yield return new WaitForSeconds(32f);
        SceneManager.LoadScene(cena);
    }
    public void BotaoPular()
    {
        SceneManager.LoadScene(cena);
    }
}
