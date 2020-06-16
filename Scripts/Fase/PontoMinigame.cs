using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PontoMinigame : MonoBehaviour
{
    public GameObject lume;
    public GameObject minigame;
    public bool apenasClique = false;
    public GameObject botaoHub;
    public GameObject textosAuxilio;
    public GameObject celeiroA;
    public GameObject celeiroB;

    public bool ativado = false;
    public bool congelado = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((congelado) || (apenasClique))
        {
            if (!lume.GetComponent<MovimentoLume>().IsCongelado()) {
                lume.GetComponent<MovimentoLume>().setCongelado(true);
                lume.GetComponent<SpriteRenderer>().enabled = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if ((other.CompareTag("PlayerMundo")) && (!ativado))
        {
            ativado = true;
            Debug.Log("yay");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if ((other.CompareTag("PlayerMundo")) && (ativado))
        {
            EstadoMinigame(false);
            ativado = false;
            Debug.Log("nay");
        }
    }

    private void OnMouseUp()
    {
        if (apenasClique)
        {
            EstadoMinigame(true);
        }
        else
        {
            Debug.Log("click click");
            if (ativado && !congelado)
            {
                EstadoMinigame(true);
                Debug.Log("yeahh");
            }
        }
    }

    public void EstadoMinigame(bool estado)
    {
        if (apenasClique)
        {
            if (estado)
            {
                lume.GetComponent<MovimentoLume>().setCongelado(true);
                lume.GetComponent<SpriteRenderer>().enabled = false;
                botaoHub.SetActive(false);
                textosAuxilio.SetActive(false);
                celeiroA.SetActive(false);
                celeiroB.SetActive(false);
                congelado = true;
                minigame.SetActive(true);
            }
            else
            {
                lume.GetComponent<MovimentoLume>().setCongelado(false);
                lume.GetComponent<SpriteRenderer>().enabled = false;
                botaoHub.SetActive(true);
                textosAuxilio.SetActive(true);
                celeiroA.SetActive(true);
                celeiroB.SetActive(true);
                congelado = false;
                minigame.SetActive(false);
            }
        }
        else
        {
            if (estado)
            {
                lume.GetComponent<MovimentoLume>().setCongelado(true);
                lume.GetComponent<SpriteRenderer>().enabled = false;
                congelado = true;
                minigame.SetActive(true);
            }
            else
            {
                lume.GetComponent<MovimentoLume>().setCongelado(false);
                lume.GetComponent<SpriteRenderer>().enabled = true;
                congelado = false;
                minigame.SetActive(false);
            }
        }
    }
}
