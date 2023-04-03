using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Item : MonoBehaviour
{
    public string nome;
    public string descricao;
    public bool eSuper;
    public int quantidade;
    public int dano;
    public int cura;
    public float velocidade = 80f;
    public Rigidbody2D rigid;
    private Vector2 direcao;
    public void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }
    public void FixedUpdate() //Velocidade da cenoura
    {
        rigid.velocity = direcao * velocidade;
    }
    public void Direcao(Vector2 recebeDirecao) //Direcao da cenoura
    {
        direcao = recebeDirecao;
    }
    //--- Metodos Getters e Setters ---//
    public virtual void SetNome(string _nome) //Recebe o nome da cenoura
    {
        nome = _nome;
    }
    public virtual string GetNome() //Guarda o nome da cenoura
    {
        return nome;
    }
    public virtual void SetDano(int _dano)
    {
        dano = _dano;
    }
    public virtual int GetDano()
    {
        return dano;
    }
    public virtual void SetCura(int _cura)
    {
        cura = _cura;
    }
    public virtual int GetCura()
    {
        return cura;
    }
    public virtual void SetQuantidade(int _quantidade)
    {
        quantidade += _quantidade;
    }
    public virtual int GetQuantidade()
    {
        return quantidade;
    }
    public virtual void OnTriggerEnter2D(Collider2D _other)
    {
        if (_other.CompareTag("Inimigo") && eSuper == false)
        {
            DestruirCenoura();
        }
        else
        {
            StartCoroutine(destruicaoConometrada());
        }

        if (_other.CompareTag("Parede"))
        {
            DestruirCenoura();
        }
    }
   public virtual void DestruirCenoura()
   {
        Destroy(gameObject); //Destroi cenoura
   }

   IEnumerator destruicaoConometrada()
    {
        yield return new WaitForSeconds(2f);
    }

}
