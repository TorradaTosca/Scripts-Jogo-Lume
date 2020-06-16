using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoggerPinball : MonoBehaviour
{
    float tempoInicio;
    int ajudaRequisitada;
    int pontos;
    List<PartidaPinball> listaContainer;
    void Start()
    {
        listaContainer = new List<PartidaPinball>();
    }
    public void MarcarTempoInicio()
    {
        tempoInicio = Time.time;
    }
    public void TerminouMinigame()
    {
        PartidaPinball pp = new PartidaPinball();
        pp.tempoDecorridoSegundo = Time.time - tempoInicio;
        pp.pontos = pontos;
        pp.cliquesBotaoAjuda = ajudaRequisitada;
        pp.concluiuMinigame = true;
        listaContainer.Add(pp);

        tempoInicio = 0f;
        ajudaRequisitada = 0;
        pontos = 0;
    }
    public void AbandonouMinigame()
    {
        PartidaPinball pp = new PartidaPinball();
        pp.tempoDecorridoSegundo = Time.time - tempoInicio;
        pp.pontos = pontos;
        pp.cliquesBotaoAjuda = ajudaRequisitada;
        pp.concluiuMinigame = false;
        listaContainer.Add(pp);

        tempoInicio = 0f;
        ajudaRequisitada = 0;
        pontos = 0;
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
    public void ColocarPontos(int pontos)
    {
        this.pontos = pontos;
    }
    public List<PartidaPinball> GetListaContainer()
    {
        return listaContainer;
    }
    public void LimparLista()
    {
        listaContainer = new List<PartidaPinball>();
    }
}

[Serializable]
public class PartidaPinball
{
    public int numeroPartida;
    public float tempoDecorridoSegundo;
    public int pontos;
    public int cliquesBotaoAjuda;
    public bool concluiuMinigame;
}