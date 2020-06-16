using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoggerEscondeEsconde : MonoBehaviour
{
    float tempoInicio;
    int ajudaRequisitada;
    List<PartidaEscondeEsconde> listaContainer;
    void Start()
    {
        listaContainer = new List<PartidaEscondeEsconde>();
    }
    public void MarcarTempoInicio()
    {
        tempoInicio = Time.time;
    }
    public void TerminouMinigame()
    {
        PartidaEscondeEsconde pee = new PartidaEscondeEsconde();
        pee.tempoDecorridoSegundo = Time.time - tempoInicio;
        pee.cliquesBotaoAjuda = ajudaRequisitada;
        pee.concluiuMinigame = true;
        listaContainer.Add(pee);

        tempoInicio = 0f;
        ajudaRequisitada = 0;
    }
    public void AbandonouMinigame()
    {
        PartidaEscondeEsconde pee = new PartidaEscondeEsconde();
        pee.tempoDecorridoSegundo = Time.time - tempoInicio;
        pee.cliquesBotaoAjuda = ajudaRequisitada;
        pee.concluiuMinigame = false;
        listaContainer.Add(pee);

        tempoInicio = 0f;
        ajudaRequisitada = 0;
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
    public List<PartidaEscondeEsconde> GetListaContainer()
    {
        return listaContainer;
    }
    public void LimparLista()
    {
        listaContainer = new List<PartidaEscondeEsconde>();
    }
}

[Serializable]
public class PartidaEscondeEsconde
{
    public int numeroPartida;
    public float tempoDecorridoSegundo;
    public int cliquesBotaoAjuda;
    public bool concluiuMinigame;
}