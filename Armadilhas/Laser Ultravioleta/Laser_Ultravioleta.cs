using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
//using static UnityEditor.Experimental.GraphView.GraphView;

public class Laser_Ultravioleta : MonoBehaviour
{
    public Rigidbody2D rigid2D;

    public float velocidade = 18f;

    private bool ativar = false;

    public GameObject luz;

    public float pontoFinal;

    public bool moveDireita;

    public void Start()
    {
        rigid2D = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D _player)
    {
        if(_player.gameObject.tag == "Player")
        {
            ativar = true;
        }
    }

    private void Update()
    {
        if (ativar == true)
        {
            luz.SetActive(true);

            if (transform.position.x < pontoFinal)
            {
                moveDireita = true;
            }

            if (pontoFinal > transform.position.x)
            {
                moveDireita = false;
            }

            if (moveDireita == true)
            {
                
                transform.position = new Vector2(transform.position.x + velocidade * Time.deltaTime, transform.position.y);
            }

            if (moveDireita == false)
            {
                
                transform.position = new Vector2(transform.position.x - velocidade * Time.deltaTime, transform.position.y);
            }

            StartCoroutine(Desativar());
        }
    }

    private IEnumerator Desativar()
    {
        yield return new WaitForSeconds(1.8f);

        luz.SetActive(false);

        Destroy(gameObject);
    }
}
