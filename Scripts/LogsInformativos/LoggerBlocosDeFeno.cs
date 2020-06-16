using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoggerBlocosDeFeno : MonoBehaviour
{
    float tempoInicio;
    int ajudaRequisitada;
    int numeroLinhasCompletas;
    int numeroPecasLancadas;
    List<PartidaBlocosDeFeno> listaContainer;
    void Start()
    {
        listaContainer = new List<PartidaBlocosDeFeno>();
    }
    public void MarcarTempoInicio()
    {
        tempoInicio = Time.time;
    }
    public void TerminouMinigame()
    {
        PartidaBlocosDeFeno ppc = new PartidaBlocosDeFeno();
        ppc.tempoDecorridoSegundo = Time.time - tempoInicio;
        ppc.numeroLinhasCompletas = numeroLinhasCompletas;
        ppc.numeroPecasLancadas = numeroPecasLancadas;
        ppc.cliquesBotaoAjuda = ajudaRequisitada;
        ppc.concluiuMinigame = true;
        listaContainer.Add(ppc);

        tempoInicio = 0f;
        ajudaRequisitada = 0;
        numeroLinhasCompletas = 0;
        numeroPecasLancadas = 0;
    }
    public void AbandonouMinigame()
    {
        PartidaBlocosDeFeno ppc = new PartidaBlocosDeFeno();
        ppc.tempoDecorridoSegundo = Time.time - tempoInicio;
        ppc.numeroLinhasCompletas = numeroLinhasCompletas;
        ppc.numeroPecasLancadas = numeroPecasLancadas;
        ppc.cliquesBotaoAjuda = ajudaRequisitada;
        ppc.concluiuMinigame = false;
        listaContainer.Add(ppc);

        tempoInicio = 0f;
        ajudaRequisitada = 0;
        numeroLinhasCompletas = 0;
        numeroPecasLancadas = 0;
    }
    public void RejogarMinigame()
    {
        TerminouMinigame();
        MarcarTempoInicio();
    }
    public void CompletouLinha()
    {
        numeroLinhasCompletas++;
    }
    public void LancouPeca()
    {
        numeroPecasLancadas++;
    }
    public void BotaoAjudaClicado()
    {
        ajudaRequisitada++;
    }
    public List<PartidaBlocosDeFeno> GetListaContainer()
    {
        return listaContainer;
    }
    public void LimparLista()
    {
        listaContainer = new List<PartidaBlocosDeFeno>();
    }
}

[Serializable]
public class PartidaBlocosDeFeno
{
    public int numeroPartida;
    public float tempoDecorridoSegundo;
    public int numeroLinhasCompletas;
    public int numeroPecasLancadas;
    public int cliquesBotaoAjuda;
    public bool concluiuMinigame;
}