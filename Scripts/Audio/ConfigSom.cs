using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfigSom : MonoBehaviour
{
    public AudioClip[] musicas;
    private bool somAtivo = true;
    private bool musicaAtiva = true;
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public void SetSomAtivo(bool somAtivo)
    {
        this.somAtivo = somAtivo;
    }

    public bool GetSomAtivo()
    {
        return somAtivo;
    }

    public void SetMusicaAtiva(bool musicaAtiva)
    {
        this.musicaAtiva = musicaAtiva;
    }

    public bool GetMusicaAtiva()
    {
        return musicaAtiva;
    }

    public void AlternarSom()
    {
        if (somAtivo)
        {
            somAtivo = false;
            AudioListener.volume = 0f;
        }
        else
        {
            somAtivo = true;
            AudioListener.volume = 1f;
        }
    }

    public void AlternarMusica()
    {
        if (musicaAtiva)
        {
            musicaAtiva = false;
        }
        else
        {
            musicaAtiva = true;
        }
    }
}
