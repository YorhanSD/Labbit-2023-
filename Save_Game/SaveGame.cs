using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveGame
{
    private float playerPosicaoX;
    private float playerPosicaoY;
    private int salvaQuantidade;
    private int contador = 0;

    public void SetPlayerPosicaoX(float _playerPosicaoX)
    {
        playerPosicaoX = _playerPosicaoX;
    }
    public float GetPlayerPosicaoX()
    {
        return playerPosicaoX;
    }

    public void SetPlayerPosicaoY(float _playerPosicaoY)
    {
        playerPosicaoY = _playerPosicaoY;
    }
    public float GetPlayerPosicaoY()
    {
        return playerPosicaoY;
    }

    public void SetSalvaQuantidade(int _salvaQuantidade)
    {
        salvaQuantidade = _salvaQuantidade;
    }

    public int GetSalvaQuantidade()
    {
        return salvaQuantidade;
    }

}
