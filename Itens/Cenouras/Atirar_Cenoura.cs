using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atirar_Cenoura : MonoBehaviour
{
    Item item;
    private bool atirar;
    private string nome;
    public void Awake()
    {
        item = GameObject.FindObjectOfType<Item>();
    }
    public void SetPodeAtirar(bool _atirou)
    {
        atirar = _atirou;
    }
    public bool GetPodeAtirar()
    {
        return atirar;
    }
    public void SetItem(Item _item)
    {
        item = _item;
    }
    public Item GetItem()
    {
        return item;
    }
}
