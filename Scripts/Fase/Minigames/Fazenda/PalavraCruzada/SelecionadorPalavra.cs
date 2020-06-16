using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelecionadorPalavra : MonoBehaviour
{
    public string palavraCerta;
    public bool selecionado = false;
    public bool clicado = false;
    public bool correto = false;
    public GameObject[] letras;
    public float offsetZ = 2f;
    private bool tocouSom = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        VerificarPalavra();
    }

    public bool GetSelecionado()
    {
        return this.selecionado;
    }
    public void SetSelecionado(bool sel)
    {
        if(sel)
        {
            GetComponent<Outline>().enabled = true;
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, -1f);
        }
        else
        {
            GetComponent<Outline>().enabled = false;
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, offsetZ);
        }
        this.selecionado = sel;
    }
    public bool GetClicado()
    {
        return clicado;
    }
    public void SetClicado(bool clicado)
    {
        this.clicado = clicado;
    }
    public bool GetCorreto()
    {
        return correto;
    }
    public void SetCorreto(bool correto)
    {
        this.correto = correto;
    }
    public GameObject[] GetLetras()
    {
        return this.letras;
    }

    void VerificarPalavra()
    {
        string palavraFormada = "";

        for (int i = 0; i < letras.Length; i++)
        {
            palavraFormada += letras[i].GetComponent<AtualizarLetra>().getLetra().ToString().ToLower();
        }

        if ((palavraFormada == palavraCerta) && (clicado))
        {
            for (int i = 0; i < letras.Length; i++)
            {
                letras[i].GetComponent<AtualizarLetra>().getComponenteImagem().color = Color.green;
            }
            correto = true;
        }
        else if ((clicado) && (selecionado))
        {
            for (int i = 0; i < letras.Length; i++)
            {
                letras[i].GetComponent<AtualizarLetra>().getComponenteImagem().color = Color.white;
            }
            correto = false;
        }
        else if (clicado)
        {
            for (int i = 0; i < letras.Length; i++)
            {
                letras[i].GetComponent<AtualizarLetra>().getComponenteImagem().color = Color.red;
            }
            correto = false;
            if(!tocouSom)
            {
                //tocar som de errado palavra ficou vermelha esse ai
                tocouSom = true;
            }
        }
    }
}
