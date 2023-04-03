using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Physics : MonoBehaviour
{
    public Rigidbody2D rigid2D;
    private bool noChao;
    public void SetNoChao(bool _noChao)
    {
        noChao = _noChao;
    }
    public bool GetNoChao()
    {
        return noChao;
    }
    void Start()
    {
        rigid2D = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        PlayerFisica();
    }
    void PlayerFisica()
    {
        if (GetNoChao() == false)
        {
            rigid2D.gravityScale += 10f * Time.deltaTime;
            rigid2D.mass += 10f * Time.deltaTime;
        }
        else
        {
            rigid2D.gravityScale = 5;
            rigid2D.mass = 5;
        }
    }
}
