using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public GameObject player;
    public GameObject feedbackSalvamento;

    public Cenoura_Laranja cenouraLaranja;
    public Cenoura_Preta cenouraPreta;

    public bool podeAbrir;

    private void Awake()
    {
        carregaJogoSalvo();
    }
    public void carregaJogoSalvo()
    {
        SaveGame carregar = JogoSalvo();

        if (JogoSalvo() != null)
        {
            player.transform.position = new Vector2(carregar.GetPlayerPosicaoX(), carregar.GetPlayerPosicaoY());
        }
    }

    private void OnTriggerEnter2D(Collider2D _check)
    {
        if(_check.gameObject.tag == "Player")
        {
            Salvar();
            feedbackSalvamento.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D _check)
    {
        if (_check.gameObject.tag == "Player")
        {
            feedbackSalvamento.SetActive(false);
        }
    }

    public void Salvar()
    {
        SaveGame newSave = new SaveGame();

        player.transform.position = new Vector2(player.transform.position.x, player.transform.position.y);

        newSave.SetPlayerPosicaoX(player.transform.position.x);
        newSave.SetPlayerPosicaoY(player.transform.position.y);

        Debug.Log("PosicaoPlayerX : " + newSave.GetPlayerPosicaoX() + "PosicaoPlayerY : " + newSave.GetPlayerPosicaoY());

        SalvarJogoBinario(newSave);

        SaveGame carregar = JogoSalvo();
    }

    public void SalvarJogoBinario(SaveGame _newSave)
    {
        BinaryFormatter bF = new BinaryFormatter();

        string caminho = Application.persistentDataPath;//AppData/LocalLow/SeuNome

        FileStream arquivo = File.Create(caminho + "/labbitJogoSalvo.save");

        bF.Serialize(arquivo, _newSave);

        arquivo.Close();

        Debug.Log("Jogo Salvo!");
    }

    public SaveGame JogoSalvo()
    {
        BinaryFormatter bF = new BinaryFormatter();

        string caminho = Application.persistentDataPath;

        FileStream arquivo;

        if(File.Exists(caminho + "/labbitJogoSalvo.save"))
        {
            arquivo = File.Open(caminho + "/labbitJogoSalvo.save", FileMode.Open);

            SaveGame carrega = (SaveGame)bF.Deserialize(arquivo);

            arquivo.Close();

            Debug.Log("Jogo Carregado");

            return carrega;
        }

        return null;
    }

}
