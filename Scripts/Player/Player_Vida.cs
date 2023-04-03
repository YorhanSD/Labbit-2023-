using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
//using UnityEditor.ShaderGraph;

public class Player_Vida : MonoBehaviour
{
    public string restart;

    public TextMeshProUGUI textoVida;

    Controle_Emocional controleEmocional;

    [Range (0f,100f)] public float vidaCompleta = 100;

    private bool imuneDano;

    private bool ressuscitar = false;

    private bool regeneracao = false;

    private bool imunidadeUltravioleta;

    private MenuMorte menuMorte;

    public Slider barraDeVida;

    public Slider barraDeApoio;

    public TextMeshProUGUI textoBarraApoio;

    public Image fill;

    public SpriteRenderer sr;

    public GameObject particulaRegeneracao;

    public Transform pe;

    public AudioSource aS;
    public AudioClip audioMorte;

    private void Start()
    {
        aS = GetComponent<AudioSource>();
        sr = GetComponent<SpriteRenderer>();
    }

    public void Awake()
    {
        menuMorte = GameObject.FindObjectOfType<MenuMorte>();
        controleEmocional = GameObject.FindObjectOfType<Controle_Emocional>();
    }

    public void SetImuneDano(bool _imuneDano)
    {
        imuneDano = _imuneDano;

        if(imuneDano == true)
        {
            StartCoroutine(tempoSemTomarDano());
        }
    }
    public bool GetImuneDano()
    {
        return imuneDano;
    }

    void Update()
    {
        if (barraDeVida.value <= 0)
        {
            if(ressuscitar == true)
            {
                barraDeVida.value += 100;

                ressuscitar = false;
                sr.color = Color.white;
            }
            else 
            {
                aS.clip = audioMorte;
                aS.Play();

                menuMorte.AtivaTelaMorte();
                Destroy(gameObject);
            }
        }
    }

    public bool BarraDeApoio(bool _mostrar, int _recebeValorCura)
    {
        if (_mostrar == true && _recebeValorCura > 0 && barraDeVida.value < 100)
        {
            barraDeApoio.value = barraDeVida.value + _recebeValorCura;
            float valor = Mathf.PingPong(Time.time, 0.8f);
            fill.color = new Vector4(0, 255, 0, valor);
        }

        return false;
    }

    private IEnumerator tempoSemTomarDano()
    {
        yield return new WaitForSeconds(2);
        SetImuneDano(false);
    }

    private void OnTriggerEnter2D(Collider2D _player)
    {
        if (_player.gameObject.tag == "Ultravioleta")
        {
            if (imunidadeUltravioleta != true)
            {
                if (GetImuneDano() != true)
                {
                    SetImuneDano(true);
                    barraDeVida.value -= 40;
                    controleEmocional.Medo(50);
                }
            }
        }
    }

    public void Ressuscitar(bool _ressuscitar)
    {
        sr.color = Color.yellow;
        ressuscitar = _ressuscitar;
    }

    public void Regeneracao(bool _regeneracao)
    {
        regeneracao = _regeneracao;
        StartCoroutine(TempRegenerar());
    }

    public void ImunidadeUltravioleta(bool _imunidadeUltravioleta)
    {
        imunidadeUltravioleta = _imunidadeUltravioleta;

        StartCoroutine(TempImunidade());
    }

    IEnumerator TempRegenerar()
    {
        particulaRegeneracao.SetActive(true);

        if (regeneracao == true)
        {
            for (int i = 1; i < 8; i++)
            {
                yield return new WaitForSeconds(3f);

                if (barraDeVida.value < 100)
                {
                    barraDeVida.value += 30;
                }
            }

            regeneracao = false;
        }

        particulaRegeneracao.SetActive(false);
    }

    IEnumerator TempImunidade()
    {
        yield return new WaitForSeconds(12f);

        imunidadeUltravioleta = false;
    }

    public void RestauraVidaPlayer(int recebeCura)
    {
        barraDeVida.value += recebeCura;
    }
}
