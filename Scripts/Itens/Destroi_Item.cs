using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroi_Item : MonoBehaviour
{
    bool podeDestruir = false;
    public void Update()
    {
        //Ao pressionar a tecla enter pode destruir o item se as condicoes forem atendidas
        if (Input.GetKeyUp(KeyCode.Return) && podeDestruir == true || Input.GetKeyUp(KeyCode.E) && podeDestruir == true || Input.GetKeyUp("joystick button 2") && podeDestruir == true)
        {
            //Destroy(gameObject, 0.1f);
        }
    }

    private void OnTriggerEnter2D(Collider2D _player)
    {
        if (_player.gameObject.tag == "Player")
        {
            //podeDestruir = true;
            Destroy(gameObject);
        }
    }

    private void OnExitEnter2D(Collider2D _player)
    {
        if (_player.gameObject.tag == "Player")
        {
            //podeDestruir = false;
        }
    }
}
