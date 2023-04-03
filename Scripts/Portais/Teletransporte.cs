using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teletransporte : MonoBehaviour
{
    public Transform playerPosicao;
    public float coordenadaX = 605f;
    public float coordenadaY = -5f;

    void OnTriggerEnter2D(Collider2D _player){

        if(_player.gameObject.tag == "Player")
        playerPosicao.position = new Vector2(coordenadaX, coordenadaY);

    }
    
}
