using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GerenciadorBuracos : MonoBehaviour
{
    public GameObject inProg;
    public GameObject logger;
    public AudioClip somDerrota;
    public AudioClip somVitoria;
    public AudioClip somErrado;
    public AudioClip somCerto;
    public Text textoVida;
    public Text textoFogo;
    public Sprite buracoVazio;
    public Sprite buracoFogo;
    public GameObject[] buracos;
    public GameObject telaVitoria;
    public GameObject telaDerrota;
    public GameObject botoesTela;
    public MetodosGerais metodosGerais;
    private bool congelado = false;
    private int acertos = 0;
    private int vidas = 3;
    private int tempoGerador = 180;
    private bool recomecarRotinaMinigame = false;
    void Start()
    {
        StartCoroutine(RodarMinigame());
    }

    void Update()
    {
        if (recomecarRotinaMinigame)
        {
            StartCoroutine(RodarMinigame());
            recomecarRotinaMinigame = false;
        }
    }

    bool VerificarVazio()
    {
        bool verificador = true;
        foreach (GameObject buraco in buracos)
        {
            if (!buraco.GetComponent<Buraco>().GetVazio())
            {
                verificador = false;
                break;
            }
        }

        return verificador;
    }

    bool ExisteBuracoClicado()
    {
        bool verificador = false;
        foreach (GameObject buraco in buracos)
        {
            if (buraco.GetComponent<Buraco>().GetClicado())
            {
                verificador = true;
                break;
            }
        }

        return verificador;
    }

    void ResetarBuracos()
    {
        foreach (GameObject buraco in buracos)
        {
            buraco.GetComponent<Buraco>().SetClicado(false);
            buraco.GetComponent<Buraco>().SetConteudo(" ");
            buraco.GetComponent<Buraco>().SetVazio(true);
            buraco.GetComponent<Image>().sprite = buracoVazio;
        }
    }

    void GerarBuracos()
    {

        int buracosAMais = AjustarDificuldade();
        int rng = Random.Range(0, buracos.Length);

        buracos[rng].GetComponent<Buraco>().SetConteudo("curupira");
        buracos[rng].GetComponent<Buraco>().SetVazio(false);
        buracos[rng].GetComponent<Image>().sprite = buracoFogo;

        while (buracosAMais > 0)
        {
            rng = Random.Range(0, buracos.Length);

            if (buracos[rng].GetComponent<Buraco>().GetVazio())
            {
                buracos[rng].GetComponent<Buraco>().SetConteudo("curupira"); //Old distracao
                buracos[rng].GetComponent<Buraco>().SetVazio(false);
                buracos[rng].GetComponent<Image>().sprite = buracoFogo;
                buracosAMais--;
            }
        }

    }

    int AjustarDificuldade()
    {
        int numero = 0;
        if (acertos > 1) numero++;
        if (acertos > 6) numero++;
        if (acertos > 14) numero++;
        if (acertos > 28) numero++;
        if (acertos > 46) numero++;
        return numero;
    }

    void ChecarVitoriaDerrota()
    {
        if (vidas <= 0)
        {
            foreach (Transform botao in botoesTela.transform)
            {
                metodosGerais.AlternarEstadoFuncional(botao.gameObject);
            }
            congelado = true;
            telaDerrota.SetActive(true);
            transform.GetComponent<AudioSource>().volume = 0.7f;
            transform.GetComponent<AudioSource>().clip = somDerrota;
            transform.GetComponent<AudioSource>().Play();
        }
        else if (acertos >= 60)
        {
            foreach (Transform botao in botoesTela.transform)
            {
                metodosGerais.AlternarEstadoFuncional(botao.gameObject);
            }
            congelado = true;
            telaVitoria.SetActive(true);
            ResetarBuracos();
            if(inProg.GetComponent<IntermediadorProgresso>().RequisitarEventoFaseAtual() == 2)
                inProg.GetComponent<IntermediadorProgresso>().AumentarEventoFaseAtual();
            transform.GetComponent<AudioSource>().volume = 0.7f;
            transform.GetComponent<AudioSource>().clip = somVitoria;
            transform.GetComponent<AudioSource>().Play();
        }
    }

    public void ResetarWhackAMole()
    {
        ResetarBuracos();
        acertos = 0;
        vidas = 3;
        tempoGerador = 180;
        congelado = false;
        recomecarRotinaMinigame = true;
        //Para todas as musicas
    }

    public void SetCongelado(bool congelado)
    {
        this.congelado = congelado;
        if(congelado == false) recomecarRotinaMinigame = true;
    }

    IEnumerator RodarMinigame()
    {
        while(!congelado)
        {
            yield return new WaitForSeconds(1/60f);

            bool ativos = VerificarVazio();
            textoVida.text = vidas.ToString();
            int fogoRestante = (60 - acertos) < 0 ? 0 : (60 - acertos);
            textoFogo.text = fogoRestante.ToString();

            if (!ativos)
            {
                if (ExisteBuracoClicado() && (tempoGerador > 60))
                {
                    foreach (GameObject buraco in buracos)
                    {
                        if ((buraco.GetComponent<Buraco>().GetConteudo() == "curupira") && buraco.GetComponent<Buraco>().GetClicado())
                        {
                            //ResetarBuracos();
                            //tempoGerador = 60;
                            buraco.GetComponent<Buraco>().SetConteudo("");
                            buraco.GetComponent<Image>().sprite = buracoVazio;
                            acertos++;
                            transform.GetComponent<AudioSource>().volume = 0.6f;
                            transform.GetComponent<AudioSource>().clip = somCerto;
                            transform.GetComponent<AudioSource>().Play();
                            logger.GetComponent<LoggerWhackAMole>().ApagouChama();
                        }
                        if ((buraco.GetComponent<Buraco>().GetConteudo() == "distracao") && buraco.GetComponent<Buraco>().GetClicado())
                        {
                            ResetarBuracos();
                            tempoGerador = 150;
                            vidas--;
                        }
                    }
                    tempoGerador--;
                }
                else if (tempoGerador <= 60)
                {
                    if (tempoGerador == 60)
                    {
                        bool fogoAceso = false;
                        foreach (GameObject buraco in buracos)
                        {
                            if ((buraco.GetComponent<Buraco>().GetConteudo() == "curupira") && !buraco.GetComponent<Buraco>().GetClicado())
                            {
                                fogoAceso = true;
                                buraco.GetComponent<Buraco>().SetConteudo("");
                                buraco.GetComponent<Image>().sprite = buracoVazio;
                            }
                        }
                        if (fogoAceso)
                        {
                            vidas--;
                            transform.GetComponent<AudioSource>().volume = 0.7f;
                            transform.GetComponent<AudioSource>().clip = somErrado;
                            transform.GetComponent<AudioSource>().Play();
                            logger.GetComponent<LoggerWhackAMole>().NaoApagouTodoFogo();
                        }
                        tempoGerador--;
                    }
                    else if (tempoGerador <= 0)
                    {
                        ChecarVitoriaDerrota();
                        ResetarBuracos();
                        GerarBuracos();
                        tempoGerador = 240;
                    }
                    else
                    {
                        tempoGerador--;
                    }
                }
                else
                {
                    tempoGerador--;
                }
            }
            else
            {
                if(tempoGerador <= 0)
                {
                    GerarBuracos();
                    tempoGerador = 240;
                }
                else
                {
                    tempoGerador--;
                }
            }
        }
        yield return null;
        
    }
}
