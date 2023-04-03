using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Abre_Alcapao : MonoBehaviour
{
    public Transform playerPosicao;

    public float coordenadaX = 605f;
    public float coordenadaY = -5f;

    public bool podeAbrir = false;

    private void Update()
    {
        /*
        if (Input.GetKeyUp(KeyCode.Return) && podeAbrir == true || Input.GetKeyUp(KeyCode.E) && podeAbrir == true || Input.GetKeyUp("joystick button 3") && podeAbrir == true)
        {
            playerPosicao.position = new Vector2(coordenadaX, coordenadaY);
        }
        */
        
    }
    public void OnTriggerEnter2D(Collider2D _player)
    {
        if (_player.gameObject.tag == "Player")
        {
            playerPosicao.position = new Vector2(coordenadaX, coordenadaY);
        }
    }

    /*
    public void OnTriggerExit2D(Collider2D _player)
    {
        if (_player.gameObject.tag == "Player")
        {
            podeAbrir = false;
        }
    }
    */
}
