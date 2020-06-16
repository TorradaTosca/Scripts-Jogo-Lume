using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayCutsApenas : MonoBehaviour
{
    public MngMusicaFase mngMusica;
    public GameObject cutsceneInicio;
    public GameObject cutsceneFinal;
    public GameObject intermediadorPregresso;
    public bool desativarCutscene = false;
    public int numeroEventoFinal;
    void Start()
    {
        TocarCutsceneInicio();
    }
    public void TocarCutsceneInicio()
    {
        IntermediadorProgresso inter = intermediadorPregresso.GetComponent<IntermediadorProgresso>();
        if(inter.RequisitarEventoFaseAtual() == 0)
        {
            if(!desativarCutscene)
            {
                mngMusica.pararMusicaEspera = true;
                cutsceneInicio.GetComponent<TocadorCutscene>().TocarCutscene();
            }
            inter.AumentarEventoFaseAtual();
        }
    }
    public void TocarCutsceneFinal()
    {
        IntermediadorProgresso inter = intermediadorPregresso.GetComponent<IntermediadorProgresso>();
        if(inter.RequisitarEventoFaseAtual() == numeroEventoFinal)
        {
            if(!desativarCutscene)
            {
                mngMusica.pararMusicaEspera = true;
                cutsceneFinal.GetComponent<TocadorCutscene>().TocarCutscene();
            }
            inter.AumentarEventoFaseAtual();
            inter.AumentarProgressoFase();
        }
    }
}
