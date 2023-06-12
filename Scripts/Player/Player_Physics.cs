using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Physics : MonoBehaviour
{
    public Rigidbody2D rigid2D;
    private bool noChao;
    private bool moonPunch;
    public void SetMoonPunch(bool _moonPunch)
    {
        moonPunch = _moonPunch;
    }
    public bool GetMoonPunch()
    {
        return moonPunch;
    }
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
            rigid2D.gravityScale += 7f * Time.deltaTime;
            rigid2D.mass += 7f * Time.deltaTime;
        }
        else
        {
            rigid2D.gravityScale = 5;
            rigid2D.mass = 5;
        }
    }
}
