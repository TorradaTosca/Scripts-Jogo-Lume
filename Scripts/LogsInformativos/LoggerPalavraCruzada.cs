using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoggerPalavraCruzada : MonoBehaviour
{
    float tempoInicio;
    int ajudaRequisitada;
    int quantidadeLetrasApagadas;
    int quantidadePalavrasSelecionadas;
    List<PartidaPalavraCruzada> listaContainer;
    void Start()
    {
        listaContainer = new List<PartidaPalavraCruzada>();
    }

    public void MarcarTempoInicio()
    {
        tempoInicio = Time.time;
    }

    public void TerminouMinigame()
    {
        PartidaPalavraCruzada ppc = new PartidaPalavraCruzada();
        ppc.tempoDecorridoSegundo = Time.time - tempoInicio;
        ppc.quantidadeLetrasApagadas = quantidadeLetrasApagadas;
        ppc.quantidadeVezesPalavrasSelecionadas = quantidadePalavrasSelecionadas;
        ppc.cliquesBotaoAjuda = ajudaRequisitada;
        ppc.concluiuMinigame = true;
        listaContainer.Add(ppc);

        tempoInicio = 0f;
        ajudaRequisitada = 0;
        quantidadeLetrasApagadas = 0;
        quantidadePalavrasSelecionadas = 0;
    }

    public void AbandonouMinigame()
    {
        PartidaPalavraCruzada ppc = new PartidaPalavraCruzada();
        ppc.tempoDecorridoSegundo = Time.time - tempoInicio;
        ppc.quantidadeLetrasApagadas = quantidadeLetrasApagadas;
        ppc.quantidadeVezesPalavrasSelecionadas = quantidadePalavrasSelecionadas;
        ppc.cliquesBotaoAjuda = ajudaRequisitada;
        ppc.concluiuMinigame = false;
        listaContainer.Add(ppc);

        tempoInicio = 0f;
        ajudaRequisitada = 0;
        quantidadeLetrasApagadas = 0;
        quantidadePalavrasSelecionadas = 0;
    }

    public void RejogarMinigame()
    {
        TerminouMinigame();
        MarcarTempoInicio();
    }

    public void ApagouLetra()
    {
        quantidadeLetrasApagadas++;
    }
    public void SelecionouPalavra()
    {
        quantidadePalavrasSelecionadas++;
    }
    public void BotaoAjudaClicado()
    {
        ajudaRequisitada++;
    }
    public List<PartidaPalavraCruzada> GetListaContainer()
    {
        return listaContainer;
    }
    public void LimparLista()
    {
        listaContainer = new List<PartidaPalavraCruzada>();
    }
}

[Serializable]
public class PartidaPalavraCruzada
{
    public int numeroPartida;
    public float tempoDecorridoSegundo;
    public int quantidadeVezesPalavrasSelecionadas;
    public int quantidadeLetrasApagadas;
    public int cliquesBotaoAjuda;
    public bool concluiuMinigame;
}