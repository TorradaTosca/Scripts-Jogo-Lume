using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoggerForca : MonoBehaviour
{
    float tempoInicio;
    int ajudaRequisitada;
    int letrasErradas;
    int palavrasAcertadas;
    List<PartidaForca> listaContainer;
    void Start()
    {
        listaContainer = new List<PartidaForca>();
    }
    public void MarcarTempoInicio()
    {
        tempoInicio = Time.time;
    }
    public void TerminouMinigame()
    {
        PartidaForca pf = new PartidaForca();
        pf.tempoDecorridoSegundo = Time.time - tempoInicio;
        pf.cliquesBotaoAjuda = ajudaRequisitada;
        pf.letrasErradas = letrasErradas;
        pf.palavrasAcertadas = palavrasAcertadas;
        pf.concluiuMinigame = true;
        listaContainer.Add(pf);

        tempoInicio = 0f;
        ajudaRequisitada = 0;
        letrasErradas = 0;
        palavrasAcertadas = 0;
    }
    public void AbandonouMinigame()
    {
        PartidaForca pf = new PartidaForca();
        pf.tempoDecorridoSegundo = Time.time - tempoInicio;
        pf.cliquesBotaoAjuda = ajudaRequisitada;
        pf.letrasErradas = letrasErradas;
        pf.palavrasAcertadas = palavrasAcertadas;
        pf.concluiuMinigame = false;
        listaContainer.Add(pf);

        tempoInicio = 0f;
        ajudaRequisitada = 0;
        letrasErradas = 0;
        palavrasAcertadas = 0;
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
    public void ErrouLetra()
    {
        letrasErradas++;
    }
    public void AcertouPalavra()
    {
        palavrasAcertadas++;
    }
    public List<PartidaForca> GetListaContainer()
    {
        return listaContainer;
    }
    public void LimparLista()
    {
        listaContainer = new List<PartidaForca>();
    }
}

[Serializable]
public class PartidaForca
{
    public int numeroPartida;
    public float tempoDecorridoSegundo;
    public int letrasErradas;
    public int palavrasAcertadas;
    public int cliquesBotaoAjuda;
    public bool concluiuMinigame;
}