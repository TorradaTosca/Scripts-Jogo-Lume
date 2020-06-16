using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AtualizarLetra : MonoBehaviour
{
    public GameObject loggerPalavra;
    public Text textoLetra;
    public char letra = ' ';
    public char letraCerta = ' ';
    public GameObject palavra;
    public GameObject segundaPalavra;
    private Image componenteImagem;
    // Start is called before the first frame update
    void Start()
    {
        letra = ' ';
        textoLetra.text = letra.ToString().ToUpper();
        componenteImagem = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        textoLetra.text = letra.ToString().ToUpper();
    }

    public void setLetra(char letra)
    {
        this.letra = letra;
    }
    public char getLetra()
    {
        return letra;
    }
    public Image getComponenteImagem()
    {
        return componenteImagem;
    }
    public string getTextoLetra()
    {
        return textoLetra.text;
    }

    public char GetLetraCerta()
    {
        return letraCerta;
    }

    public bool estaVazia()
    {
        if (letra == ' ')
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void OnMouseDown()
    {
        if (palavra.GetComponent<SelecionadorPalavra>().GetSelecionado())
        {
            char c = ' ';
            setLetra(c);
            loggerPalavra.GetComponent<LoggerPalavraCruzada>().ApagouLetra();
        }

        if (segundaPalavra != null)
        {
            if ((palavra.GetComponent<SelecionadorPalavra>().GetSelecionado())
                || (segundaPalavra.GetComponent<SelecionadorPalavra>().GetSelecionado()))
            {
                char c = ' ';
                setLetra(c);
                loggerPalavra.GetComponent<LoggerPalavraCruzada>().ApagouLetra();
            }
            if ((!palavra.GetComponent<SelecionadorPalavra>().GetSelecionado())
                && (!segundaPalavra.GetComponent<SelecionadorPalavra>().GetSelecionado()))
            {
                palavra.GetComponent<SelecionadorPalavra>().SetSelecionado(true);
                transform.GetComponent<MngMusicaFase>().TocarMusicaShot();
                loggerPalavra.GetComponent<LoggerPalavraCruzada>().SelecionouPalavra();
            }
        }
        else
        {
            if (palavra.GetComponent<SelecionadorPalavra>().GetSelecionado())
            {
                char c = ' ';
                setLetra(c);
                loggerPalavra.GetComponent<LoggerPalavraCruzada>().ApagouLetra();
            }
            palavra.GetComponent<SelecionadorPalavra>().SetSelecionado(true);
            transform.GetComponent<MngMusicaFase>().TocarMusicaShot();
            loggerPalavra.GetComponent<LoggerPalavraCruzada>().SelecionouPalavra();
        }
    }
}
