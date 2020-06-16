using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoggerWhackAMole : MonoBehaviour
{
    float tempoInicio;
    int ajudaRequisitada;
    int vidasPerdidas;
    int chamasApagadas;
    List<PartidaAcerteOFogo> listaContainer;
    void Start()
    {
        listaContainer = new List<PartidaAcerteOFogo>();
    }
    public void MarcarTempoInicio()
    {
        tempoInicio = Time.time;
    }
    public void TerminouMinigame()
    {
        PartidaAcerteOFogo ppe = new PartidaAcerteOFogo();
        ppe.tempoDecorridoSegundo = Time.time - tempoInicio;
        ppe.cliquesBotaoAjuda = ajudaRequisitada;
        ppe.vidasPerdidas = vidasPerdidas;
        ppe.chamasApagadas = chamasApagadas;
        ppe.concluiuMinigame = true;
        listaContainer.Add(ppe);

        tempoInicio = 0f;
        ajudaRequisitada = 0;
        vidasPerdidas = 0;
        chamasApagadas = 0;
    }
    public void AbandonouMinigame()
    {
        PartidaAcerteOFogo ppe = new PartidaAcerteOFogo();
        ppe.tempoDecorridoSegundo = Time.time - tempoInicio;
        ppe.cliquesBotaoAjuda = ajudaRequisitada;
        ppe.vidasPerdidas = vidasPerdidas;
        ppe.chamasApagadas = chamasApagadas;
        ppe.concluiuMinigame = false;
        listaContainer.Add(ppe);

        tempoInicio = 0f;
        ajudaRequisitada = 0;
        vidasPerdidas = 0;
        chamasApagadas = 0;
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
    public void NaoApagouTodoFogo()
    {
        vidasPerdidas++;
    }
    public void ApagouChama()
    {
        chamasApagadas++;
    }
    public List<PartidaAcerteOFogo> GetListaContainer()
    {
        return listaContainer;
    }
    public void LimparLista()
    {
        listaContainer = new List<PartidaAcerteOFogo>();
    }
}

[Serializable]
public class PartidaAcerteOFogo
{
    public int numeroPartida;
    public float tempoDecorridoSegundo;
    public int vidasPerdidas;
    public int chamasApagadas;
    public int cliquesBotaoAjuda;
    public bool concluiuMinigame;
}