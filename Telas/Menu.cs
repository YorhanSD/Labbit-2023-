using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement; //necess�rio para ter controle das cenas
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public string cena;
    public string voltarCena;
    public string cenaFases;
    public string novoJogo;
    private bool isPaused;

    public GameObject painelPausa;
    public GameObject painelOpcoes;
    public GameObject painelControles;
    public GameObject painelResolucoes;
    public GameObject painelGraficos;
    public GameObject painelAudio;

    void Start()
    {
        Time.timeScale = 1f;
    }
    void PauseScreen()
    {
        if (isPaused)
        {
            isPaused = false;
            Time.timeScale = 1f;
            painelPausa.SetActive(false);
            //Cursor.lockState = CursorLockMode.Locked;
            //Cursor.visible = false;
        }
        else
        {
            isPaused = true;
            Time.timeScale = 0f;
            painelPausa.SetActive(true);
            //Cursor.lockState = CursorLockMode.None;
            //Cursor.visible = true;
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown("joystick button 7"))
        {
            PauseScreen();
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene(cena); //coloca o nome da cena em MenuManager
    }

    public void QuitGame()
    {
        // Editor unity
        //UnityEditor.EditorApplication.isPlaying = false;

        //Jogo compilado - comentar a linha acima e descomentar a abaixo antes de gerar a build
       Application.Quit();
    }

    public void ShowOptions()
    {
        painelOpcoes.SetActive(true);
    }
    public void BotaoVoltarPause()
    {
        Time.timeScale = 1f;
        painelPausa.SetActive(false);
    }
    public void BotaoVoltarMenu()
    {
        painelOpcoes.SetActive(false);
        painelResolucoes.SetActive(false);
        painelControles.SetActive(false);
        painelGraficos.SetActive(false);
        painelAudio.SetActive(false);
    }

    public void PainelResolucoes()
    {
        painelResolucoes.SetActive(true);
    }

    public void PainelControles()
    {
        painelControles.SetActive(true);
    }

    public void PainelGraficos()
    {
        painelGraficos.SetActive(true);
    }

    public void PainelAudio()
    {
        painelAudio.SetActive(true);
    }

    public void JogoSalvo()
    {
        SceneManager.LoadScene(cenaFases);
    }

    public void BotaoVoltar()
    {
        SceneManager.LoadScene(voltarCena);   
    }

    public void BotaoNovoJogo()
    {
        RemoveJogoSalvo();
        SceneManager.LoadScene(novoJogo);
    }

    public void RemoveJogoSalvo()
    {
        string caminho = Application.persistentDataPath;

        if (File.Exists(caminho + "/labbitJogoSalvo.save"))
        {
            File.Delete(caminho + "/labbitJogoSalvo.save");
        }
    }
}
