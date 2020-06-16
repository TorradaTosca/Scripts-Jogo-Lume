using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MontadorPalavras : MonoBehaviour
{
    public GameObject inProg;
    public GameObject loggerPalavra;
    public GameObject[] palavras;
    public GameObject botoesPlaca;
    public GameObject telaParabens;
    public int palavraAtivada = -1;
    private bool tudoPreenchido = false;
    private MetodosGerais metodos;
    // Start is called before the first frame update
    void Start()
    {
        metodos = transform.GetComponent<MetodosGerais>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            ProcurarPalavraAtiva();
        }

        MontarPalavra();

        VerificarPalavras();
    }

    void ProcurarPalavraAtiva()
    {
        for (int i = 0; i < palavras.Length; i++)
        {
            if (palavras[i].GetComponent<SelecionadorPalavra>().GetSelecionado() && i != palavraAtivada)
            {
                if (palavraAtivada > -1)
                {
                    palavras[palavraAtivada].GetComponent<SelecionadorPalavra>().SetSelecionado(false);
                }
                palavraAtivada = i;
                palavras[i].GetComponent<SelecionadorPalavra>().SetClicado(true);

                for (int j = i + 1; j < palavras.Length; j++)
                {
                    palavras[j].GetComponent<SelecionadorPalavra>().SetSelecionado(false);
                }

                break;
            }
            else
            {
                palavras[i].GetComponent<SelecionadorPalavra>().SetSelecionado(false);
                if (palavraAtivada > -1)
                {
                    palavras[palavraAtivada].GetComponent<SelecionadorPalavra>().SetSelecionado(true);
                }
            }
        }
    }

    void MontarPalavra()
    {
        if (palavraAtivada > -1)
        {
            GameObject[] letra = palavras[palavraAtivada].GetComponent<SelecionadorPalavra>().GetLetras();

            foreach (char c in Input.inputString)
            {
                if (c == '\b') // backspace/delete
                {
                    int tamanho = letra.Length;

                    for (int i = tamanho - 1; i > -1; i--)
                    {
                        if (!letra[i].GetComponent<AtualizarLetra>().estaVazia())
                        {
                            char ch = ' ';
                            letra[i].GetComponent<AtualizarLetra>().setLetra(ch);
                            loggerPalavra.GetComponent<LoggerPalavraCruzada>().ApagouLetra();
                            break;
                        }
                    }
                }
                else if ((c == '\n') || (c == '\r')) // enter
                {
                    palavraAtivada = -1;
                }
                else // qualquer outra tecla
                {
                    int tamanho = letra.Length;

                    for (int i = 0; i < tamanho; i++)
                    {
                        if(i == 0)
                        {
                            if (letra[i].GetComponent<AtualizarLetra>().estaVazia())
                            {
                                EscreverLetra(i, c);
                                break;
                            }
                        }
                        else
                        {
                            if (letra[i].GetComponent<AtualizarLetra>().estaVazia())
                            {
                                char letraAnterior = letra[i-1].GetComponent<AtualizarLetra>().getLetra();

                                if (c != letraAnterior)
                                {
                                    EscreverLetra(i, c);
                                    break;
                                }
                                else if ((c == letra[i].GetComponent<AtualizarLetra>().GetLetraCerta())
                                    && (c == letraAnterior))
                                {
                                    EscreverLetra(i, c);
                                    break;
                                }
                                else if ((c != letra[i].GetComponent<AtualizarLetra>().GetLetraCerta())
                                    && (c == letraAnterior))
                                {
                                    break;
                                }
                            }
                        }
                    }
                }
            }
        }
    }

    void VerificarPalavras()
    {
        bool verificador = true;

        for (int i = 0; i < palavras.Length; i++)
        {
            if (palavras[i].GetComponent<SelecionadorPalavra>().GetCorreto())
            {
                continue;
            }
            else
            {
                verificador = false;
                break;
            }
        }

        if ((verificador) && (!tudoPreenchido))
        {
            tudoPreenchido = true;
            //telaParabens.SetActive(true);
            AtivarTelaParabens();

            if(inProg.GetComponent<IntermediadorProgresso>().RequisitarEventoFaseAtual() == 3)
                inProg.GetComponent<IntermediadorProgresso>().AumentarEventoFaseAtual();

            foreach(Transform botao in botoesPlaca.transform)
            {
                metodos.AlternarEstadoFuncional(botao.gameObject);
            }

            transform.GetComponent<MngMusicaFase>().TocarMusicaShot();
        }
    }

    public void ResetarPalavras()
    {
        foreach(GameObject palavra in palavras)
        {
            palavra.GetComponent<SelecionadorPalavra>().SetClicado(false);
            palavra.GetComponent<SelecionadorPalavra>().SetCorreto(false);
            foreach (GameObject letra in palavra.GetComponent<SelecionadorPalavra>().GetLetras())
            {
                letra.GetComponent<AtualizarLetra>().setLetra(' ');
                letra.GetComponent<AtualizarLetra>().getComponenteImagem().color = Color.white;
            }
        }
        tudoPreenchido = false;
        palavraAtivada = -1;
    }

    public void AtivarTelaParabens()
    {
        while (!telaParabens.activeSelf)
        {
            telaParabens.SetActive(true);
        }
    }
    public void DesativarTelaParabens()
    {
        while (telaParabens.activeSelf)
        {
            telaParabens.SetActive(false);
        }
    }

    void EscreverLetra(int i, char c)
    {
        GameObject[] letra = palavras[palavraAtivada].GetComponent<SelecionadorPalavra>().GetLetras();
        letra[i].GetComponent<AtualizarLetra>().setLetra(c);
    }
}
