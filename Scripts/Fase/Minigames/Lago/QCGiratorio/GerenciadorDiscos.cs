using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GerenciadorDiscos : MonoBehaviour
{
    public GameObject inProg;
    public AudioClip somVitoria;
    public GameObject telaVitoria;
    public GameObject botoesTela;
    public MetodosGerais metodosGerais;
    public GameObject[] discos;
    public int discoSelecionado = 0;
    private bool sequenciaVitoria = false;
    private bool congelado = false;

    void Update()
    {
        if (!congelado)
        {
            if (sequenciaVitoria)
            {
                ContinuarSequenciaVitoria();
            }
            else
            {
                ChecarAngulosDiscos();
            }
        }
    }

    void ChecarAngulosDiscos()
    {
        float[] anguloDisco = new float[discos.Length];
        bool[] anguloEstaCerto = new bool[discos.Length];
        bool verificador = true;
        anguloEstaCerto[0] = true;
        for (int i = 0; i < discos.Length; i++)
        {
            anguloDisco[i] = discos[i].transform.localRotation.eulerAngles.z;
        }
        for (int i = 1; i < discos.Length; i++)
        {
            if (ChecarExtremidadesAngulo(anguloDisco[0], anguloDisco[i], 4f))
            {
                anguloEstaCerto[i] = true;
            }
        }

        for(int i = 0; i < discos.Length; i++)
        {
            if (!anguloEstaCerto[i]) verificador = false;
        }
        if (verificador) AtivarVitoria();
    }

    bool ChecarExtremidadesAngulo(float anguloCerto, float anguloTestar, float margem)
    {
        anguloTestar += margem;
        anguloCerto += margem;
        if (anguloTestar >= 360f) anguloTestar -= 360f;
        if (anguloCerto >= 360f) anguloCerto -= 360f;
        float angMin = anguloCerto - margem;
        float angMax = anguloCerto + margem;

        if((anguloTestar > angMin) && (anguloTestar < angMax))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    void AtivarVitoria()
    {
        sequenciaVitoria = true;
        for(int i = 1; i < discos.Length; i++)
        {
            discos[i].GetComponent<Image>().enabled = false;
        }
    }

    void ContinuarSequenciaVitoria()
    {
        bool validador = true;
        foreach(GameObject disco in discos)
        {
            Vector3 novaRotacao = Vector3.Lerp(disco.transform.localRotation.eulerAngles, Vector3.zero, 8f * Time.deltaTime);
            disco.transform.localRotation = Quaternion.Euler(novaRotacao);

            if (disco.transform.localRotation.eulerAngles != Vector3.zero)
            {
                validador = false;
            }
        }
        if(validador)
        {
            sequenciaVitoria = false;
            telaVitoria.SetActive(true);
            foreach(Transform botao in botoesTela.transform)
            {
                metodosGerais.AlternarEstadoFuncional(botao.gameObject);
            }
            congelado = true;
            if(inProg.GetComponent<IntermediadorProgresso>().RequisitarEventoFaseAtual() == 2)
                inProg.GetComponent<IntermediadorProgresso>().AumentarEventoFaseAtual();
            transform.GetComponent<AudioSource>().volume = 0.7f;
            transform.GetComponent<AudioSource>().clip = somVitoria;
            transform.GetComponent<AudioSource>().Play();
        }
    }

    public GameObject GetDiscoAtivo()
    {
        return discos[discoSelecionado];
    }

    public void SetDiscoSelecionado(int discoSelecionado)
    {
        if (discoSelecionado < 0) discoSelecionado = 0;
        else if (discoSelecionado > discos.Length-1) discoSelecionado = 2;

        this.discoSelecionado = discoSelecionado;
    }

    public void ResetarMinigame()
    {
        discoSelecionado = 0;
        for(int i = 0; i < discos.Length; i++)
        {
            discos[i].GetComponent<Image>().enabled = true;
            discos[i].transform.localRotation = Quaternion.Euler(0f, 0f, Random.Range(0f, 360f));
        }
        congelado = false;
    }
}
