using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GeradorPecas : MonoBehaviour
{
    public GameObject loggerBlocos;
    public AudioClip somPontoGanho;
    public AudioClip somPecaColocada;
    public AudioClip somDerrota;
    public GameObject[] pecas;
    public GameObject[] estrelas;
    public GameObject canvas;
    public GameObject gameover;
    public GameObject botoesPlacaGrande;
    private int pontos = 0;
    private GameObject pecaProxima;
    private GameObject pecaEmJogo;
    // Start is called before the first frame update
    void Start()
    {
        CriarPeca();
    }

    public void CriarPeca()
    {
        if(pecaProxima != null)
        {
            pecaEmJogo = pecaProxima;
            pecaEmJogo.GetComponent<PecaTetris>().enabled = true;
            pecaEmJogo.transform.localScale = new Vector3(1f, 1f, 1f);
            pecaEmJogo.transform.localPosition = new Vector3(0f, 0f, -1f);
        }
        else
        {
            Vector3 posicaoPeca = new Vector3(transform.position.x, transform.position.y, -1f);
            GameObject a = Instantiate(pecas[Random.Range(0, pecas.Length)], posicaoPeca, Quaternion.identity);
            a.GetComponent<PecaTetris>().geradorPecas = transform.gameObject;
            a.GetComponent<PecaTetris>().gameover = gameover;
            a.GetComponent<PecaTetris>().botoesPlacaGrande = botoesPlacaGrande;
            a.GetComponent<PecaTetris>().loggerBlocos = loggerBlocos;
            a.transform.SetParent(canvas.transform, true);
            pecaEmJogo = a;
        }

        Vector3 posPeca = new Vector3(-18.4f, -8.65f, -1f);
        GameObject b = Instantiate(pecas[Random.Range(0, pecas.Length)], posPeca, Quaternion.identity);
        b.transform.localScale = new Vector3(1.4f, 1.4f, 1f);
        b.GetComponent<PecaTetris>().geradorPecas = transform.gameObject;
        b.GetComponent<PecaTetris>().gameover = gameover;
        b.GetComponent<PecaTetris>().botoesPlacaGrande = botoesPlacaGrande;
        b.GetComponent<PecaTetris>().enabled = false;
        b.GetComponent<PecaTetris>().loggerBlocos = loggerBlocos;
        b.transform.SetParent(canvas.transform, true);
        b.transform.localPosition = posPeca;
        pecaProxima = b;

        transform.GetComponent<AudioSource>().clip = somPecaColocada;
        transform.GetComponent<AudioSource>().Play();
        loggerBlocos.GetComponent<LoggerBlocosDeFeno>().LancouPeca();
    }

    public void DestruirPecas()
    {
        foreach(Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }

    public void ResetarMinigame()
    {
        //DestruirPecas();
        pontos = 0;
        pecaEmJogo = null;
        pecaProxima = null;
        CriarPeca();
    }

    public void AumentarPontos(int pontosNovos)
    {
        pontos += pontosNovos;
        transform.GetComponent<AudioSource>().clip = somPontoGanho;
        transform.GetComponent<AudioSource>().Play();
    }

    public int GetPontos()
    {
        return pontos;
    }

    public void SetPontos(int pontos)
    {
        this.pontos = pontos;
    }

    public void TocarSomDerrota()
    {
        transform.GetComponent<AudioSource>().clip = somDerrota;
        transform.GetComponent<AudioSource>().Play();
    }
}
