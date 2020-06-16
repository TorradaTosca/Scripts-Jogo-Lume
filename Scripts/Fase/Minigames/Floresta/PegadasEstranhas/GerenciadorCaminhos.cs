using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GerenciadorCaminhos : MonoBehaviour
{
    public GameObject inProg;
    public GameObject logger;
    public AudioClip somVitoria;
    public AudioClip somDerrota;
    public AudioClip somCerto;
    public AudioClip somErrado;
    public Text textoVidas;
    public Text textoPegadas;
    public GameObject botoesOpcoes;
    public MetodosGerais metodosGerais;
    public GameObject telaVitoria;
    public GameObject telaDerrota;
    public GameObject[] botoesCaminho;
    public GameObject[] caminhosIndo;
    public GameObject[] caminhosVindo;
    private int cenasCaminhadas = 0;
    private int vidas = 3;
    private int timer = -1;
    private bool congelado = false;

    // Start is called before the first frame update
    void Start()
    {
        GerarCaminhos();
    }

    // Update is called once per frame
    void Update()
    {
        textoVidas.text = vidas.ToString();
        textoPegadas.text = (10 - cenasCaminhadas).ToString();
        if (!congelado)
        {
            ChecarEscolhaCaminho();

            if (timer >= 0)
            {
                if (timer == 0)
                {
                    GerarCaminhos();
                }
                timer--;
            }
        }
    }

    void ChecarEscolhaCaminho()
    {
        foreach (GameObject caminho in botoesCaminho)
        {
            if (caminho.GetComponent<Caminho>().GetClicado() && (caminho.GetComponent<Caminho>().GetConteudo() == "curupira"))
            {
                cenasCaminhadas++;
                ResetarCaminhos();
                timer = 60;
                transform.GetComponent<AudioSource>().clip = somCerto;
                transform.GetComponent<AudioSource>().Play();
                break;
            }
            else if (caminho.GetComponent<Caminho>().GetClicado() && (caminho.GetComponent<Caminho>().GetConteudo() == "distracao"))
            {
                vidas--;
                ResetarCaminhos();
                timer = 60;
                transform.GetComponent<AudioSource>().clip = somErrado;
                transform.GetComponent<AudioSource>().Play();
                logger.GetComponent<LoggerPegadasEstranhas>().ErrouTrilha();
                break;
            }
        }

        if (vidas <= 0)
        {
            telaDerrota.SetActive(true);
            foreach (Transform botao in botoesOpcoes.transform)
            {
                metodosGerais.GetComponent<MetodosGerais>().AlternarEstadoFuncional(botao.gameObject);
            }
            congelado = true;
            transform.GetComponent<AudioSource>().clip = somDerrota;
            transform.GetComponent<AudioSource>().Play();
        }
        else if (cenasCaminhadas >= 10)
        {
            telaVitoria.SetActive(true);
            foreach (Transform botao in botoesOpcoes.transform)
            {
                metodosGerais.GetComponent<MetodosGerais>().AlternarEstadoFuncional(botao.gameObject);
            }
            congelado = true;
            if(inProg.GetComponent<IntermediadorProgresso>().RequisitarEventoFaseAtual() == 1)
                inProg.GetComponent<IntermediadorProgresso>().AumentarEventoFaseAtual();
            transform.GetComponent<AudioSource>().clip = somVitoria;
            transform.GetComponent<AudioSource>().Play();
        }
    }

    void GerarCaminhos()
    {
        int distracao = 2;

        int rng = Random.Range(0, botoesCaminho.Length);
        botoesCaminho[rng].GetComponent<Caminho>().SetVazio(false);
        botoesCaminho[rng].GetComponent<Caminho>().SetConteudo("curupira".ToLower());
        caminhosIndo[rng].SetActive(true);

        while (distracao > 0)
        {
            rng = Random.Range(0, botoesCaminho.Length);

            if (botoesCaminho[rng].GetComponent<Caminho>().GetVazio())
            {
                botoesCaminho[rng].GetComponent<Caminho>().SetConteudo("distracao".ToLower());
                botoesCaminho[rng].GetComponent<Caminho>().SetVazio(false);
                caminhosVindo[rng].SetActive(true);
                distracao--;
            }
        }
    }

    void ResetarCaminhos()
    {
        foreach (GameObject botao in botoesCaminho)
        {
            botao.GetComponent<Caminho>().SetClicado(false);
            botao.GetComponent<Caminho>().SetConteudo(" ");
            botao.GetComponent<Caminho>().SetVazio(true);
        }
        foreach (GameObject caminho in caminhosIndo)
        {
            caminho.SetActive(false);
        }
        foreach (GameObject caminho in caminhosVindo)
        {
            caminho.SetActive(false);
        }
    }

    public void ResetarMinigame()
    {
        ResetarCaminhos();
        cenasCaminhadas = 0;
        vidas = 3;
        timer = -1;
        congelado = false;
        GerarCaminhos();
    }
}
