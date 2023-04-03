using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuMorte : MonoBehaviour
{
    public GameObject efeitosVisuais;
    public GameObject telaMorte;
    public GameObject telaPergunta;
    public string restart;
    
    public void AtivaTelaMorte()
    {
        Time.timeScale = 0f;
        telaMorte.SetActive(true);
    }
    public void BotaoCancelar()
    {
        telaPergunta.SetActive(false);
    }
    public void BotaoReiniciar()
    {
        SceneManager.LoadScene(restart);
    }
    public void BotaoAbrirPergunta()
    {
        telaPergunta.SetActive(true);
    }

    public void BotaoSairJogo()
    {
        // Editor unity
        //UnityEditor.EditorApplication.isPlaying = false;

        //Jogo compilado - comentar a linha acima e descomentar a abaixo antes de gerar a build
        Application.Quit();
        //Debug.Log("Saiu");
    }
}
