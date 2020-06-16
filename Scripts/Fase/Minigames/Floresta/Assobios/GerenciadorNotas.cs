using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.CoreModule;

public class GerenciadorNotas : MonoBehaviour
{
    public GameObject inProg;
    public Text textoNotas;
    public Text textoSequencia;
    public GameObject logger;
    public AudioClip somVitoria;
    public AudioClip somErrado;
    public AudioClip assobioA;
    public AudioClip assobioB;
    public AudioClip assobioC;
    public AudioClip assobioD;
    public GameObject fundoEscuro;
    public GameObject displayNota;
    public GameObject telaVitoria;
    public GameObject botoesOpcoes;
    public GameObject metodosGerais;
    public Sprite[] spritesPedra;
    private int tempoIntervalo = 120;
    private int estado = 0;
    private int acertos = 0;
    private int notaAtual = 0;
    private int[] notasGeradas;
    private bool recomecarRotinaMinigame = false;
    void Start()
    {
        notasGeradas = new int[6];
        displayNota.GetComponent<Image>().enabled = false;
        GerarNotas();
        StartCoroutine(RodarMinigame());
    }

    void Update()
    {
        textoSequencia.text = (notasGeradas.Length - acertos).ToString();
        textoNotas.text = (acertos - notaAtual + 1).ToString();
        if (recomecarRotinaMinigame)
        {
            StartCoroutine(RodarMinigame());
            recomecarRotinaMinigame = false;
        }
    }

    void GerarNotas()
    {
        /*for (int i = 0; ((i < notasGeradas.Length) && (i < acertos + 1)); i++)
        {
            int rng = Random.Range(0, 4); Debug.Log(i + "|" + rng);
            notasGeradas[i] = rng;
        }*/
        for (int i = 0; (i < notasGeradas.Length); i++)
        {
            int rng = Random.Range(0, 4); Debug.Log(i + "|" + rng);
            notasGeradas[i] = rng;
        }
    }

    public void AssobiarNota(int tom)
    {
        if (estado == 2)
        {
            if (CompararNota(tom))
            {
                AssobioCerto();
            }
            else
            {
                AssobioErrado();
                transform.GetComponent<AudioSource>().clip = somErrado;
                transform.GetComponent<AudioSource>().Play();
                logger.GetComponent<LoggerAssobios>().ErrouSequencia();
            }
        }
    }

    bool CompararNota(int tom)
    {
        if (tom == notasGeradas[notaAtual])
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    void AssobioCerto()
    {
        if (notaAtual == acertos)
        {
            //estado = 0;
            if (acertos < notasGeradas.Length - 1)
            {
                acertos++; Debug.Log("acertou");
                estado = 0;
            }
            else
            {
                estado = 3;
                telaVitoria.SetActive(true);
                foreach (Transform botao in botoesOpcoes.transform)
                {
                    metodosGerais.GetComponent<MetodosGerais>().AlternarEstadoFuncional(botao.gameObject);
                }
                if(inProg.GetComponent<IntermediadorProgresso>().RequisitarEventoFaseAtual() == 3)
                    inProg.GetComponent<IntermediadorProgresso>().AumentarEventoFaseAtual();
                transform.GetComponent<AudioSource>().clip = somVitoria;
                transform.GetComponent<AudioSource>().Play();
            }
        }
        else
        {
            notaAtual++;
        }
    }

    void AssobioErrado()
    {
        estado = 1; Debug.Log("errou");
        tempoIntervalo = 120;
        notaAtual = 0;
        //Diminuir vida ou so repetir ate conseguir? refaz o rng de qqr jeito ou repete msm?
    }

    public void ResetarMinigame()
    {
        estado = 0;
        tempoIntervalo = 120;
        acertos = 0;
        notaAtual = 0;
        telaVitoria.SetActive(false);
        GerarNotas();
        recomecarRotinaMinigame = true;

        Color c = fundoEscuro.GetComponent<Image>().color;
        c.a = 0f;
        fundoEscuro.GetComponent<Image>().color = c;
    }

    IEnumerator RodarMinigame()
    {
        while(estado < 3)
        {
            yield return new WaitForSeconds(1/60f);

            if (estado < 2)
            {
                fundoEscuro.SetActive(true);
                Image imagemFundo = fundoEscuro.GetComponent<Image>();
                if (imagemFundo.color.a < 0.5f)
                {
                    Color c = imagemFundo.color;
                    c.a += 0.01f;
                    if(c.a > 0.5f) c.a = 0.5f;
                    imagemFundo.color = c;
                }
            }
            else
            {
                Image imagemFundo = fundoEscuro.GetComponent<Image>();
                if (imagemFundo.color.a > 0f)
                {
                    Color c = imagemFundo.color;
                    c.a -= 0.01f;
                    if(c.a < 0f) c.a = 0f;
                    imagemFundo.color = c;
                }
                if (imagemFundo.color.a == 0) fundoEscuro.SetActive(false);
            }

            if (estado == 0)
            {
                //GerarNotas();
                tempoIntervalo = 180;
                notaAtual = 0;
                estado = 1;
                displayNota.GetComponent<Image>().enabled = false;
            }
            else if (estado == 1)
            {
                if (tempoIntervalo <= 60)
                {
                    switch (notasGeradas[notaAtual])
                    {
                        case 0:
                            displayNota.GetComponent<Image>().enabled = true;
                            displayNota.GetComponent<RectTransform>().localScale = new Vector3(-1f, 1f, 1f);
                            displayNota.GetComponent<Image>().sprite = spritesPedra[0];

                            if (tempoIntervalo <= 0)
                            {
                                if (notaAtual == acertos)
                                {
                                    estado = 2;
                                    notaAtual = 0;
                                    tempoIntervalo = 0;
                                    displayNota.GetComponent<Image>().enabled = false;
                                    break;
                                }

                                tempoIntervalo = 120;
                                notaAtual++;
                            }
                            else
                            { 
                            tempoIntervalo--;
                            }
                            break;

                        case 1:
                            displayNota.GetComponent<Image>().enabled = true;
                            displayNota.GetComponent<RectTransform>().localScale = new Vector3(1f, 1f, 1f);
                            displayNota.GetComponent<Image>().sprite = spritesPedra[1];

                            if (tempoIntervalo <= 0)
                            {
                                if (notaAtual == acertos)
                                {
                                    estado = 2;
                                    notaAtual = 0;
                                    tempoIntervalo = 0;
                                    displayNota.GetComponent<Image>().enabled = false;
                                    break;
                                }

                                tempoIntervalo = 120;
                                notaAtual++;
                            }
                            else
                            {
                                tempoIntervalo--;
                            }
                            break;

                        case 2:
                            displayNota.GetComponent<Image>().enabled = true;
                            displayNota.GetComponent<RectTransform>().localScale = new Vector3(-1f, 1f, 1f);
                            displayNota.GetComponent<Image>().sprite = spritesPedra[2];

                            if (tempoIntervalo <= 0)
                            {
                                if (notaAtual == acertos)
                                {
                                    estado = 2;
                                    notaAtual = 0;
                                    tempoIntervalo = 0;
                                    displayNota.GetComponent<Image>().enabled = false;
                                    break;
                                }

                                tempoIntervalo = 120;
                                notaAtual++;
                            }
                            else
                            {
                                tempoIntervalo--;
                            }
                            break;

                        case 3:
                            displayNota.GetComponent<Image>().enabled = true;
                            displayNota.GetComponent<RectTransform>().localScale = new Vector3(1f, 1f, 1f);
                            displayNota.GetComponent<Image>().sprite = spritesPedra[3];

                            if (tempoIntervalo <= 0)
                            {
                                if (notaAtual == acertos)
                                {
                                    estado = 2;
                                    notaAtual = 0;
                                    tempoIntervalo = 0;
                                    displayNota.GetComponent<Image>().enabled = false;
                                    break;
                                }

                                tempoIntervalo = 120;
                                notaAtual++;
                            }
                            else
                            {
                                tempoIntervalo--;
                            }
                            break;
                    }
                }
                else if ((tempoIntervalo > 60) && (tempoIntervalo <= 180))
                {
                    if(tempoIntervalo == 70)
                    {
                        switch (notasGeradas[notaAtual])
                        {
                            case 0:
                                transform.GetComponent<AudioSource>().clip = assobioA;
                                transform.GetComponent<AudioSource>().Play();
                            break;
                            case 1:
                                transform.GetComponent<AudioSource>().clip = assobioC;
                                transform.GetComponent<AudioSource>().Play();
                            break;
                            case 2:
                                transform.GetComponent<AudioSource>().clip = assobioB;
                                transform.GetComponent<AudioSource>().Play();
                            break;
                            case 3:
                                transform.GetComponent<AudioSource>().clip = assobioD;
                                transform.GetComponent<AudioSource>().Play();
                            break;
                        }
                    }
                    displayNota.GetComponent<Image>().enabled = false;
                    tempoIntervalo--;
                }
            }
        }
        yield return null;
    }
}
