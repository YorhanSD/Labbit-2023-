using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Super_CenouraAzul : Item
{
    public override void SetNome(string _nome)
    {
        base.SetNome(_nome);
    }
    public override string GetNome()
    {
        return base.GetNome();
    }
    public override void SetQuantidade(int _quantidade)
    {
        base.SetQuantidade(_quantidade);
    }
    public override int GetQuantidade()
    {
        return base.GetQuantidade();
    }
    public override void SetDano(int _dano)
    {
        base.SetDano(_dano);
    }
    public override int GetDano()
    {
        return base.GetDano();
    }
    public override void SetCura(int _cura)
    {
        base.SetCura(_cura);
    }
    public override int GetCura()
    {
        return base.GetCura();
    }
    public override void OnTriggerEnter2D(Collider2D _inimigo)
    {
        base.OnTriggerEnter2D(_inimigo);

        if (_inimigo.gameObject.tag == "Inimigo")
        {
            StartCoroutine(Vortex(_inimigo));
        }
    }
    public IEnumerator Vortex(Collider2D _inimigo)
    {
        if (_inimigo.gameObject.tag == "Inimigo")
        {
            _inimigo.gameObject.SetActive(false);

            yield return new WaitForSeconds(3f);

            _inimigo.gameObject.SetActive(true);
        }
    }
}
