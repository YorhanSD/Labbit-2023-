using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Suffering : MonoBehaviour
{
    public Animator anim;
    private Player_Movimento playerMovimento;
    private void Awake()
    {
        playerMovimento = GameObject.FindObjectOfType<Player_Movimento>();
    }
    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    public void SofrendoDano()
    {
        anim.SetTrigger("Suffering");
    }

    public void PlayerParalizado()
    {
        playerMovimento.SetPlayerImobilizado(true);
    }
    
    void Update()
    {
        
    }
}
