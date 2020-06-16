using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class TocadorCutscene : MonoBehaviour
{
    public bool tocarEmSequencia = true;
    public bool mudarCenaAoCompletar = false;
    public string nomeCena = "Hub";
    public bool tocarAoIniciar = false;
    public bool desativarObjetoAoTerminar = false;
    public MngMusicaFase mngMusica;
    public GameObject objetoADesativar;
    public VideoClip[] videos;
    public RenderTexture[] texturasVideos;
    public GameObject[] imagensVideo;
    public GameObject configuracaoSom;
    private VideoPlayer videoPlayer;
    private int numeroVideo = 0;
    void Start()
    {
        if(tocarAoIniciar)
        {
            TocarCutscene();
        }
    }
    public void TocarCutscene()
    {
        videoPlayer = GetComponent<VideoPlayer>();
        videoPlayer.loopPointReached += EndReached;

        if(configuracaoSom == null)
        {
            configuracaoSom = GameObject.FindWithTag("AudioConfig");
        }
        if(!configuracaoSom.GetComponent<ConfigSom>().GetSomAtivo()) videoPlayer.SetDirectAudioVolume(ushort.Parse(numeroVideo.ToString()), 0f);
        else videoPlayer.SetDirectAudioVolume(ushort.Parse(numeroVideo.ToString()), 0.8f);

        videoPlayer.clip = videos[numeroVideo];
        videoPlayer.targetTexture = texturasVideos[numeroVideo];
        imagensVideo[numeroVideo].SetActive(true);
        videoPlayer.Prepare();
        videoPlayer.Play();
    }
    void EndReached(VideoPlayer vp)
    {
        numeroVideo++;
        if((numeroVideo < videos.Length) && (tocarEmSequencia))
        {
            foreach(GameObject gm in imagensVideo)
            {
                gm.SetActive(false);
            }
            TocarCutscene();
        }
        else if(mudarCenaAoCompletar)
        {
            SceneManager.LoadScene(nomeCena);
        }
        else if(desativarObjetoAoTerminar)
        {
            objetoADesativar.SetActive(false);
            if(mngMusica != null) mngMusica.TocarMusicaLoop();
        }
        else
        {
            foreach(GameObject gm in imagensVideo)
            {
                gm.SetActive(false);
            }
        }
    }
}
