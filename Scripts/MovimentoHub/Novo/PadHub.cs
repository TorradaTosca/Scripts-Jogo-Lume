using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PadHub : MonoBehaviour
{
    public GameObject interProgressoFase;
    public GameObject placaMudarFase;
    public bool trancado = true;
    public GameObject hubLume;
    public int id = 0;
    public string nomeCena;
    public string descricaoFase;
    public Material materialPadrao;
    public Material materialTrancado;
    public bool ehUmaFaseEntravel = true;
    private bool destino = false;

    void Start()
    {
        if(interProgressoFase.GetComponent<IntermediadorProgresso>().RqtProgFases() >= id) trancado = false;
    }
    private void Update()
    {
        if (trancado)
        {
            GetComponent<SpriteRenderer>().material = materialTrancado;
        }
        else
        {
            GetComponent<SpriteRenderer>().material = materialPadrao;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if(destino)
            {
                other.GetComponent<MovimentoLumeHub>().DestinoAlcancado();
                destino = false;
                if (ehUmaFaseEntravel) placaMudarFase.GetComponent<MudarFase>().SetMostrar(true);
            }
            other.GetComponent<MovimentoLumeHub>().SetPosicao(id);
            if (ehUmaFaseEntravel)
            {
                placaMudarFase.GetComponent<MudarFase>().SetNomeFase(nomeCena);
                placaMudarFase.GetComponent<MudarFase>().AlterarDescricao(descricaoFase);
            }
        }
        else
        {
            //lol
        }
    }

    private void OnMouseDown()
    {
        if(!trancado)
        {
            if (hubLume.GetComponent<MovimentoLumeHub>().GetPosicao() != id)
            {
                hubLume.GetComponent<MovimentoLumeHub>().ResetarDestino();
                destino = true;
                hubLume.GetComponent<MovimentoLumeHub>().MoverParaDestino(id);
                placaMudarFase.GetComponent<MudarFase>().SetMostrar(false);
            }
        }
    }

    public void SetDestino(bool destino)
    {
        this.destino = destino;
    }

    public bool GetDestino()
    {
        return destino;
    }
}
