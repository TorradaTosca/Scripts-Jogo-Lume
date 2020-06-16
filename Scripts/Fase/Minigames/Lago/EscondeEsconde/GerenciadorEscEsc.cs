using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GerenciadorEscEsc : MonoBehaviour
{
    public GameObject inProg;
    public Text textoBoto;
    public AudioClip somVitoria;
    public GameObject lumeEscEsc;
    public GameObject botoEscEsc;
    public GameObject telaVitoria;
    public GameObject botoesPlacaGrande;
    private int vezesEncontradas = 0;
    private int quantidadeVitoria = 4;

    void Update()
    {
        textoBoto.text = (quantidadeVitoria - vezesEncontradas).ToString();
    }

    public void EncontrouBoto()
    {
        int novoX = Random.Range(-527, 380);
        int novoY = Random.Range(-325, 58);
        botoEscEsc.transform.localPosition = new Vector3(novoX, novoY, 0);
        vezesEncontradas++;
        if(vezesEncontradas == quantidadeVitoria)
        {
            AtivarVitoria();
        }
    }

    void AtivarVitoria()
    {
        botoesPlacaGrande.SetActive(false);
        if(inProg.GetComponent<IntermediadorProgresso>().RequisitarEventoFaseAtual() == 1)
                inProg.GetComponent<IntermediadorProgresso>().AumentarEventoFaseAtual();
        transform.GetComponent<AudioSource>().volume = 0.7f;
        transform.GetComponent<AudioSource>().clip = somVitoria;
        transform.GetComponent<AudioSource>().Play();
        telaVitoria.SetActive(true);
        lumeEscEsc.GetComponent<MovimentoLumeEE>().SetCongelado(true);
    }

    public void ResetarMinigame()
    {
        lumeEscEsc.GetComponent<MovimentoLumeEE>().SetCongelado(false);
        vezesEncontradas = 0;
    }
}
