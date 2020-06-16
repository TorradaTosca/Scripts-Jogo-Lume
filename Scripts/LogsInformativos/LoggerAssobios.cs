using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoggerAssobios : MonoBehaviour
{
    float tempoInicio;
    int ajudaRequisitada;
    int errosQuiz;
    int errosSequencia;
    List<PartidaAssobios> listaContainer;
    void Start()
    {
        listaContainer = new List<PartidaAssobios>();
    }
    public void MarcarTempoInicio()
    {
        tempoInicio = Time.time;
    }
    public void TerminouMinigame()
    {
        PartidaAssobios pa = new PartidaAssobios();
        pa.tempoDecorridoSegundo = Time.time - tempoInicio;
        pa.errosQuiz = errosQuiz;
        pa.errosSequencia = errosSequencia;
        pa.cliquesBotaoAjuda = ajudaRequisitada;
        pa.concluiuMinigame = true;
        listaContainer.Add(pa);

        tempoInicio = 0f;
        ajudaRequisitada = 0;
        errosQuiz = 0;
        errosSequencia = 0;
    }
    public void AbandonouMinigame()
    {
        PartidaAssobios pa = new PartidaAssobios();
        pa.tempoDecorridoSegundo = Time.time - tempoInicio;
        pa.errosQuiz = errosQuiz;
        pa.errosSequencia = errosSequencia;
        pa.cliquesBotaoAjuda = ajudaRequisitada;
        pa.concluiuMinigame = false;
        listaContainer.Add(pa);

        tempoInicio = 0f;
        ajudaRequisitada = 0;
        errosQuiz = 0;
        errosSequencia = 0;
    }
    public void RejogarMinigame()
    {
        TerminouMinigame();
        MarcarTempoInicio();
    }
    public void BotaoAjudaClicado()
    {
        ajudaRequisitada++;
    }
    public void ErrouQuiz()
    {
        errosQuiz++;
    }
    public void ErrouSequencia()
    {
        errosSequencia++;
    }
    public List<PartidaAssobios> GetListaContainer()
    {
        return listaContainer;
    }
    public void LimparLista()
    {
        listaContainer = new List<PartidaAssobios>();
    }
}

[Serializable]
public class PartidaAssobios
{
    public int numeroPartida;
    public float tempoDecorridoSegundo;
    public int errosQuiz;
    public int errosSequencia;
    public int cliquesBotaoAjuda;
    public bool concluiuMinigame;
}