using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntermediadorProgresso : MonoBehaviour
{
    public GameObject saver;
    public GameObject[] prePontosMinigame;
    public GameObject[] textosAuxilio;
    public GameObject painelCutscenes;
    public PlayCutsApenas playCuts;
    public bool pularCutInicio = false;
    public bool hubInter = false;
    //public bool espCutFinal = false;
    void Start()
    {
        saver = GameObject.FindWithTag("ProgressTracker");
        if(!hubInter)
        {
            if((RequisitarEventoFaseAtual() == 0) && (!pularCutInicio))
            {
                painelCutscenes.SetActive(true);
                playCuts.TocarCutsceneInicio();
            }
            else
            {
                AumentarEventoFaseAtual();
            }
            ChecarProgFaseAtual();
        }
    }
    public void Salvar()
    {
        saver.GetComponent<SalvarProgresso>().SalvarJogo();
    }
    public void AumentarEventoFaseAtual()
    {
        switch(tag)
        {
            case "FaseFazenda":
                AumentarEventoFazenda();
            break;

            case "FaseFloresta":
                AumentarEventoFloresta();
            break;

            case "FaseRio":
                AumentarEventoRio();
            break;
        }
        ChecarProgFaseAtual();
        Salvar();
    }
    public int RequisitarEventoFaseAtual()
    {
        switch(tag)
        {
            case "FaseFazenda":
                return RqtEvtFazenda();

            case "FaseFloresta":
                return RqtEvtFloresta();

            case "FaseRio":
                return RqtEvtRio();
            
            default:
                return RqtEvtFazenda();
        }
    }
    public void ChecarProgFaseAtual()
    {
        int ne = RequisitarEventoFaseAtual();
        switch(tag)
        {
            case "FaseFazenda":
                if(ne >= 1)
                {
                    prePontosMinigame[0].SetActive(true);
                    textosAuxilio[0].SetActive(true);
                }
                if(ne >= 2)
                {
                    prePontosMinigame[1].SetActive(true);
                    textosAuxilio[1].SetActive(true);
                }
                if(ne >= 3)
                {
                    prePontosMinigame[2].SetActive(true);
                    textosAuxilio[2].SetActive(true);
                }
            break;

            case "FaseFloresta":
                if(ne >= 1)
                {
                    prePontosMinigame[0].SetActive(true);
                    textosAuxilio[0].SetActive(true);
                }
                if(ne >= 2)
                {
                    prePontosMinigame[1].SetActive(true);
                    textosAuxilio[1].SetActive(true);
                }
                if(ne >= 3)
                {
                    prePontosMinigame[2].SetActive(true);
                    textosAuxilio[2].SetActive(true);
                }
            break;

            case "FaseRio":
                if(ne >= 1)
                {
                    prePontosMinigame[0].SetActive(true);
                    textosAuxilio[0].SetActive(true);
                }
                if(ne >= 2)
                {
                    prePontosMinigame[1].SetActive(true);
                    textosAuxilio[1].SetActive(true);
                }
            break;
        }
    }
    public void TocarCutFinal()
    {
        //if(espCutFinal)
        //{
            switch(tag)
            {
                case "FaseFazenda":
                    if(RequisitarEventoFaseAtual() == 4)
                    {
                        painelCutscenes.SetActive(true);
                        playCuts.TocarCutsceneFinal();
                    }
                break;

                case "FaseFloresta":
                    if(RequisitarEventoFaseAtual() == 4)
                    {
                        painelCutscenes.SetActive(true);
                        playCuts.TocarCutsceneFinal();
                    }
                break;

                case "FaseRio":
                    if(RequisitarEventoFaseAtual() == 3)
                    {
                        painelCutscenes.SetActive(true);
                        playCuts.TocarCutsceneFinal();
                    }
                break;
            }
        //}
    }
    public void AumentarProgressoFase()
    {
        saver.GetComponent<SalvarProgresso>().AvancarProgFases();
        Salvar();
    }
    public void AumentarEventoFazenda()
    {
        saver.GetComponent<SalvarProgresso>().AvancarEventoFazenda();
    }
    public void AumentarEventoFloresta()
    {
        saver.GetComponent<SalvarProgresso>().AvancarEventoFloresta();
    }
    public void AumentarEventoRio()
    {
        saver.GetComponent<SalvarProgresso>().AvancarEventoRio();
    }
    public int RqtProgFases()
    {
        return saver.GetComponent<SalvarProgresso>().FasesDesbloqueadas;
    }
    public int RqtEvtFazenda()
    {
        return saver.GetComponent<SalvarProgresso>().EventosFazenda;
    }
    public int RqtEvtFloresta()
    {
        return saver.GetComponent<SalvarProgresso>().EventosFloresta;
    }
    public int RqtEvtRio()
    {
        return saver.GetComponent<SalvarProgresso>().EventosRio;
    }
}
