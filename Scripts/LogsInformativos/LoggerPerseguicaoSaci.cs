using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoggerPerseguicaoSaci : MonoBehaviour
{
    float tempoInicio;
    int ajudaRequisitada;
    int batidasObstaculo;
    int errosQuiz;
    List<PartidaPerseguicaoSaci> listaContainer;
    void Start()
    {
        listaContainer = new List<PartidaPerseguicaoSaci>();
    }

    public void MarcarTempoInicio()
    {
        tempoInicio = Time.time;
    }

    public void TerminouMinigame()
    {
        PartidaPerseguicaoSaci pps = new PartidaPerseguicaoSaci();
        pps.tempoDecorridoSegundo = Time.time - tempoInicio;
        pps.errosQuiz = errosQuiz;
        pps.batidasObstaculo = batidasObstaculo;
        pps.cliquesBotaoAjuda = ajudaRequisitada;
        pps.concluiuMinigame = true;
        listaContainer.Add(pps);

        tempoInicio = 0f;
        ajudaRequisitada = 0;
        batidasObstaculo = 0;
        errosQuiz = 0;
    }

    public void AbandonouMinigame()
    {
        PartidaPerseguicaoSaci pps = new PartidaPerseguicaoSaci();
        pps.tempoDecorridoSegundo = Time.time - tempoInicio;
        pps.errosQuiz = errosQuiz;
        pps.batidasObstaculo = batidasObstaculo;
        pps.cliquesBotaoAjuda = ajudaRequisitada;
        pps.concluiuMinigame = false;
        listaContainer.Add(pps);

        tempoInicio = 0f;
        ajudaRequisitada = 0;
        batidasObstaculo = 0;
        errosQuiz = 0;
    }

    public void RejogarMinigame()
    {
        TerminouMinigame();
        MarcarTempoInicio();
    }

    public void BateuEmObstaculo()
    {
        batidasObstaculo++;
    }

    public void ErrouQuiz()
    {
        errosQuiz++;
    }

    public void BotaoAjudaClicado()
    {
        ajudaRequisitada++;
    }

    public List<PartidaPerseguicaoSaci> GetListaContainer()
    {
        return listaContainer;
    }

    public void LimparLista()
    {
        listaContainer = new List<PartidaPerseguicaoSaci>();
    }
}

[Serializable]
public class PartidaPerseguicaoSaci
{
    public int numeroPartida;
    public float tempoDecorridoSegundo;
    public int errosQuiz;
    public int batidasObstaculo;
    public int cliquesBotaoAjuda;
    public bool concluiuMinigame;
}