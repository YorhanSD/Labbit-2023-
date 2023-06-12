using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Segue : MonoBehaviour
{
    public float segueVelocidade;
    public float yOffSet = 1f;
    public Transform playerPosicao;
    Vector3 novaPosicao;
    Controle_Emocional cE;
    public Camera cam;

    void Awake()
    {
        cE = GameObject.FindObjectOfType<Controle_Emocional>();
    }
    private void Start()
    {
        gameObject.transform.position = playerPosicao.position;
    }
    void Update()
    {
        if (cE.emocaoSlider.value >= 100)
        {
            camFar();
        }
        else if (cE.emocaoSlider.value <= 0)
        {
            camNear();
        }
        else
        {
            camNormal();
        }
    }

    private void FixedUpdate()
    {
        if (playerPosicao != null)
        {
            transform.position = Vector3.Slerp(transform.position, novaPosicao, segueVelocidade * Time.deltaTime);
            novaPosicao = new Vector3(playerPosicao.position.x, playerPosicao.position.y + yOffSet, -60);
        }
    }

    void camNear()
    {
        cam.orthographicSize = 25;
    }

    void camNormal()
    {
        cam.orthographicSize = 20;
    }

    void camFar()
    {
        cam.orthographicSize = 35;
    }

}
