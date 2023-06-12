using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chave : MonoBehaviour
{
    Teletransporte teletransporte;
    
    void Awake()
    {
       teletransporte = GameObject.FindObjectOfType<Teletransporte>();
    }

    void OnTriggerEnter2D(Collider2D _player)
    {
        if (_player.gameObject.tag == "Player")
        {
            //teletransporte.pegouChave = true;
        }
            
    }
}
