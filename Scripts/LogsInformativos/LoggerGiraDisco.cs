using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoggerGiraDisco : MonoBehaviour
{
    float tempoInicio;
    int ajudaRequisitada;
    int errosQuiz;
    List<PartidaGiraDisco> listaContainer;
    void Start()
    {
        listaContainer = new List<PartidaGiraDisco>();
    }
    public void MarcarTempoInicio()
    {
        tempoInicio = Time.time;
    }
    public void TerminouMinigame()
    {
        PartidaGiraDisco pgd = new PartidaGiraDisco();
        pgd.tempoDecorridoSegundo = Time.time - tempoInicio;
        pgd.errosQuiz = errosQuiz;
        pgd.cliquesBotaoAjuda = ajudaRequisitada;
        pgd.concluiuMinigame = true;
        listaContainer.Add(pgd);

        tempoInicio = 0f;
        ajudaRequisitada = 0;
        errosQuiz = 0;
    }
    public void AbandonouMinigame()
    {
        PartidaGiraDisco pgd = new PartidaGiraDisco();
        pgd.tempoDecorridoSegundo = Time.time - tempoInicio;
        pgd.errosQuiz = errosQuiz;
        pgd.cliquesBotaoAjuda = ajudaRequisitada;
        pgd.concluiuMinigame = false;
        listaContainer.Add(pgd);

        tempoInicio = 0f;
        ajudaRequisitada = 0;
        errosQuiz = 0;
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
    public List<PartidaGiraDisco> GetListaContainer()
    {
        return listaContainer;
    }
    public void LimparLista()
    {
        listaContainer = new List<PartidaGiraDisco>();
    }
}

[Serializable]
public class PartidaGiraDisco
{
    public int numeroPartida;
    public float tempoDecorridoSegundo;
    public int errosQuiz;
    public int cliquesBotaoAjuda;
    public bool concluiuMinigame;
}