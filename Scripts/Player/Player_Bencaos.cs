using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Bencaos : MonoBehaviour
{
    Player_Vida pV;
    public SpriteRenderer sR;
    Controle_Emocional cE;

    public GameObject particulaRegeneracao;

    public GameObject escudoUltravioleta;

    [SerializeField] private bool ressuscitar = false;

    [SerializeField] private bool regeneracao = false;

    [SerializeField] private bool imunidadeUltravioleta = false;

    [SerializeField] private bool imunidadeToxicidade = false;

    private void Awake()
    {
        pV = GameObject.FindObjectOfType<Player_Vida>();
        sR = GameObject.FindObjectOfType<SpriteRenderer>();
        cE = GameObject.FindObjectOfType<Controle_Emocional>();
    }

    private void Start()
    {
        sR = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D _player)
    {
        if (_player.gameObject.tag == "Ultravioleta")
        {
            ChecaImunidadeUltravioleta();
        }
        if (_player.gameObject.tag == "BioHazard")
        {
            ChecaImunidadeToxicidade();
        }
    }

    public bool ChecaImunidadeUltravioleta()
    {
        if (GetImuneUltravioleta() == false && pV.GetImuneDano() == false)
        {
            pV.SetImuneDano(true);
            pV.barraDeVida.value -= 40;
            cE.Medo(50);
        }

        return false;
    }
    public bool ChecaImunidadeToxicidade()
    {
        if (GetImuneToxicidade() == false && pV.GetImuneDano() == false)
        {
            pV.SetImuneDano(true);
            pV.barraDeVida.value -= 40;
            cE.Medo(50);
        }

        return false;
    }

    public void Ressuscitar(bool _ressuscitar)
    {
        sR.color = Color.yellow;
        ressuscitar = _ressuscitar;
    }

    public bool GetRessuscitar()
    {
        return ressuscitar;
    }

    public void Regeneracao(bool _regeneracao)
    {
        regeneracao = _regeneracao;
        StartCoroutine(TempRegenerar());
    }

    public void SetImunidadeUltravioleta(bool _imunidadeUltravioleta)
    {
        imunidadeUltravioleta = _imunidadeUltravioleta;

        if (imunidadeUltravioleta == true)
            escudoUltravioleta.SetActive(true);
        else
            escudoUltravioleta.SetActive(false);
    }
    public void SetImunidadeToxicidade(bool _imunidadeToxicidade)
    {
        imunidadeToxicidade = _imunidadeToxicidade;
    }
    public bool GetImuneToxicidade()
    {
        return imunidadeToxicidade;
    }
    public bool GetImuneUltravioleta()
    {
        return imunidadeUltravioleta;
    }
    IEnumerator TempRegenerar()
    {
        particulaRegeneracao.SetActive(true);

        if (regeneracao == true)
        {
            for (int i = 1; i < 8; i++)
            {
                yield return new WaitForSeconds(2f);

                if (pV.barraDeVida.value < 100)
                {
                    pV.barraDeVida.value += 30;
                }
            }

            regeneracao = false;
        }

        particulaRegeneracao.SetActive(false);
    }
}
