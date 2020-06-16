using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoggerPegadasEstranhas : MonoBehaviour
{
    float tempoInicio;
    int ajudaRequisitada;
    int vidasPerdidas;
    List<PartidaPegadasEstranhas> listaContainer;
    void Start()
    {
        listaContainer = new List<PartidaPegadasEstranhas>();
    }
    public void MarcarTempoInicio()
    {
        tempoInicio = Time.time;
    }
    public void TerminouMinigame()
    {
        PartidaPegadasEstranhas ppe = new PartidaPegadasEstranhas();
        ppe.tempoDecorridoSegundo = Time.time - tempoInicio;
        ppe.cliquesBotaoAjuda = ajudaRequisitada;
        ppe.vidasPerdidas = vidasPerdidas;
        ppe.concluiuMinigame = true;
        listaContainer.Add(ppe);

        tempoInicio = 0f;
        ajudaRequisitada = 0;
        vidasPerdidas = 0;
    }
    public void AbandonouMinigame()
    {
        PartidaPegadasEstranhas ppe = new PartidaPegadasEstranhas();
        ppe.tempoDecorridoSegundo = Time.time - tempoInicio;
        ppe.cliquesBotaoAjuda = ajudaRequisitada;
        ppe.vidasPerdidas = vidasPerdidas;
        ppe.concluiuMinigame = false;
        listaContainer.Add(ppe);

        tempoInicio = 0f;
        ajudaRequisitada = 0;
        vidasPerdidas = 0;
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
    public void ErrouTrilha()
    {
        vidasPerdidas++;
    }
    public List<PartidaPegadasEstranhas> GetListaContainer()
    {
        return listaContainer;
    }
    public void LimparLista()
    {
        listaContainer = new List<PartidaPegadasEstranhas>();
    }
}

[Serializable]
public class PartidaPegadasEstranhas
{
    public int numeroPartida;
    public float tempoDecorridoSegundo;
    public int vidasPerdidas;
    public int cliquesBotaoAjuda;
    public bool concluiuMinigame;
}