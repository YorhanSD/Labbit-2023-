using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{
    private bool isPaused;
    public GameObject painelPause;
    

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown("joystick button 7"))
        {
            PauseScreen();
        }
        */
    }

    void PauseScreen()
    {
        if (isPaused)
        {
            isPaused = false;
            Time.timeScale = 1f;
            painelPause.SetActive(false);
            //Cursor.lockState = CursorLockMode.Locked;
            //Cursor.visible = false;
        }
        else
        {
            isPaused = true;
            Time.timeScale = 0f;
            painelPause.SetActive(true);
            //Cursor.lockState = CursorLockMode.None;
            //Cursor.visible = true;
        }
    }

    /*public void BackToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }*/

    public void QuitGame()
    {
        // Editor unity
        //UnityEditor.EditorApplication.isPlaying = false;

        //Jogo compilado - comentar a linha acima e descomentar a abaixo antes de gerar a build
        Application.Quit();
        //Debug.Log("Saiu");
    }

}
