using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MngMusicaFase : MonoBehaviour
{
    public bool ehMusica = true;
    public bool comecarTocando = false;
    public bool comecarTocandoEmLoop = false;
    public AudioSource audioSourceFundo;
    public AudioSource audioSourceAmbiente;
    public GameObject configuracaoSom;
    public ConfigSom configSom;
    public bool pararMusicaEspera = false;
    private bool musicaLoopEspera = false;
    private bool musicaShotEspera = false;

    private void Start()
    {
        configuracaoSom = GameObject.FindWithTag("AudioConfig");
        configSom = configuracaoSom.GetComponent<ConfigSom>();

        if(comecarTocando)
        {
            if(comecarTocandoEmLoop)
            {
                TocarMusicaLoop();
            }
            else
            {
                TocarMusicaShot();
            }
        }
    }

    private void Update()
    {
        /*if((!configSom.GetMusicaAtiva()) && (ehMusica))
        {
            if(audioSourceAmbiente != null)
            {
                audioSourceAmbiente.Stop();
                if(audioSourceAmbiente.loop)
                {
                    musicaLoopEspera = true;
                }
                else
                {
                    musicaShotEspera = true;
                }
            }
            if(audioSourceFundo != null)
            {
                audioSourceFundo.Stop();
                if(audioSourceFundo.loop)
                {
                    musicaLoopEspera = true;
                }
                else
                {
                    musicaShotEspera = true;
                }
            }
        }*/

        if(configSom == null)
        {
            configuracaoSom = GameObject.FindWithTag("AudioConfig");
            configSom = configuracaoSom.GetComponent<ConfigSom>();
        }

        if (musicaLoopEspera)
        {
            musicaLoopEspera = false;
            TocarMusicaLoop();
        }
        if (musicaShotEspera)
        {
            musicaShotEspera = false;
            TocarMusicaShot();
        }
        if (pararMusicaEspera)
        {
            pararMusicaEspera = false;
            PararMusica();
        }
    }

    public void TocarMusicaLoop()
    {
        if(audioSourceAmbiente != null)
        {
            audioSourceAmbiente.loop = true;
            if (configuracaoSom != null)
            {
                if ((ehMusica) && (configSom.GetMusicaAtiva())) audioSourceAmbiente.Play();
                else if ((!ehMusica) && (configSom.GetSomAtivo())) audioSourceAmbiente.Play();
            }
            else
            {
                if (ehMusica) musicaLoopEspera = true;
            }
        }
        if(audioSourceFundo != null)
        {
            audioSourceFundo.loop = true;
            if (configuracaoSom != null)
            {
                if ((ehMusica) && (configSom.GetMusicaAtiva())) audioSourceFundo.Play();
                else if ((!ehMusica) && (configSom.GetSomAtivo())) audioSourceFundo.Play();
            }
            else
            {
                if (ehMusica) musicaLoopEspera = true;
            }
        }
    }

    public void TocarMusicaShot()
    {
        if(audioSourceAmbiente != null)
        {
            audioSourceAmbiente.loop = false;
            if (configuracaoSom != null)
            {
                if ((ehMusica) && (configSom.GetMusicaAtiva())) audioSourceAmbiente.Play();
                else if ((!ehMusica) && (configSom.GetSomAtivo())) audioSourceAmbiente.Play();
            }
            else
            {
                if (ehMusica) musicaShotEspera = true;
            }
        }
        if(audioSourceFundo != null)
        {
            audioSourceFundo.loop = false;
            if (configuracaoSom != null)
            {
                if ((ehMusica) && (configSom.GetMusicaAtiva())) audioSourceFundo.Play();
                else if ((!ehMusica) && (configSom.GetSomAtivo())) audioSourceFundo.Play();
            }
            else
            {
                if (ehMusica) musicaShotEspera = true;
            }
        }
    }

    public void PararMusica()
    {
        if(audioSourceAmbiente != null)
        {
            audioSourceAmbiente.Stop();
        }
        if(audioSourceFundo != null)
        {
            audioSourceFundo.Stop();
        }
    }

    public void AlterarVolume(float volFundo, float volAmbiente, bool fade, float novoVol, float fadeSpeed)
    {
        if (volFundo < 0) volFundo = 0;
        if (volAmbiente < 0) volAmbiente = 0;
        if (volFundo > 1) volFundo = 1;
        if (volAmbiente > 1) volAmbiente = 1;

        if(fade)
        {
            StartCoroutine(FadeVolume(novoVol, fadeSpeed));
        }
        else
        {
            audioSourceFundo.volume = volFundo;
            audioSourceAmbiente.volume = volAmbiente;
        }
    }

    IEnumerator FadeVolume(float volDestino, float spd)
    {
        while (true)
        {
            yield return new WaitForSeconds(1/60f);
            bool validadorFundo = false;
            bool validadorAmbiente = false;

            if(audioSourceFundo != null)
            {
                if(volDestino > audioSourceFundo.volume)
                {
                    audioSourceFundo.volume += spd/60;
                    if (volDestino < audioSourceFundo.volume) audioSourceFundo.volume = volDestino;
                }
                else if (volDestino < audioSourceFundo.volume)
                {
                    audioSourceFundo.volume -= spd/60;
                    if(volDestino > audioSourceFundo.volume) audioSourceFundo.volume = volDestino;
                }
                else
                {
                    validadorFundo = true;
                }
            }
            else
            {
                validadorFundo = true;
            }

            if(audioSourceAmbiente != null)
            {
                if(volDestino > audioSourceAmbiente.volume)
                {
                    audioSourceAmbiente.volume += spd/60;
                    if (volDestino < audioSourceAmbiente.volume) audioSourceAmbiente.volume = volDestino;
                }
                else if (volDestino < audioSourceAmbiente.volume)
                {
                    audioSourceAmbiente.volume -= spd/60;
                    if(volDestino > audioSourceAmbiente.volume) audioSourceAmbiente.volume = volDestino;
                }
                else
                {
                    validadorAmbiente = true;
                }
            }
            else
            {
                validadorAmbiente = true;
            }

            if((validadorFundo) && (validadorAmbiente))
            {
                yield break;
            }
        }
    }
}
