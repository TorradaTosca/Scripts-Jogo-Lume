using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoggerSeteErros : MonoBehaviour
{
    float tempoInicio;
    float tempoFinal;
    int cliquesDados;
    int ajudaRequisitada;
    bool estaRegistrando = false;
    bool concluiuMinigame;
    List<PartidaSeteErros> listaContainer;
    void Start()
    {
        listaContainer = new List<PartidaSeteErros>();
    }

    void Update()
    {
        if((estaRegistrando) && (Input.GetMouseButtonDown(0)))
        {
            cliquesDados++;
        }
    }

    public void ComecarRegistro()
    {
        tempoInicio = Time.time;
        estaRegistrando = true;
    }

    public void PararRegistro(bool concluido)
    {
        tempoFinal = Time.time;
        estaRegistrando = false;
        concluiuMinigame = concluido;

        PartidaSeteErros pse = new PartidaSeteErros();
        pse.SetTempoDecorridoSegundo(tempoFinal - tempoInicio);
        pse.SetTotalCliques(cliquesDados);
        pse.SetAjudaRequisitada(ajudaRequisitada);
        pse.SetConcluiuMinigame(concluiuMinigame);
        listaContainer.Add(pse);

        tempoInicio = 0f;
        tempoFinal = 0f;
        cliquesDados = 0;
        ajudaRequisitada = 0;
        concluiuMinigame = false;
    }

    public void RepetirMinigame()
    {
        PararRegistro(true);
        ComecarRegistro();
    }

    public void BotaoAjudaClicado()
    {
        ajudaRequisitada++;
    }

    public List<PartidaSeteErros> GetListaContainer()
    {
        return listaContainer;
    }

    public void LimparLista()
    {
        listaContainer = new List<PartidaSeteErros>();
    }
}

[Serializable]
public class PartidaSeteErros
{
    public int numeroPartida;
    public float tempoDecorridoSegundo;
    public int totalCliques;
    public int cliquesBotaoAjuda;
    public bool concluiuMinigame;

    public void SetNumeroPartida(int numeroPartida)
    {
        this.numeroPartida = numeroPartida;
    }

    public void SetTempoDecorridoSegundo(float tempo)
    {
        tempoDecorridoSegundo = tempo;
    }

    public void SetTotalCliques(int totalCliques)
    {
        this.totalCliques = totalCliques;
    }

    public void SetAjudaRequisitada(int cliquesBotaoAjuda)
    {
        this.cliquesBotaoAjuda = cliquesBotaoAjuda;
    }

    public void SetConcluiuMinigame(bool concluiuMinigame)
    {
        this.concluiuMinigame = concluiuMinigame;
    }
}
