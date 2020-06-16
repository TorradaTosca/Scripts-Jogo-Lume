using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caminho : MonoBehaviour
{
    private bool clicado = false;
    private bool vazio = true;
    private string conteudo = "";

    private void OnMouseDown()
    {
        SetClicado(true);
    }

    public void SetClicado(bool clicado)
    {
        this.clicado = clicado;
    }

    public bool GetClicado()
    {
        return clicado;
    }

    public void SetVazio(bool vazio)
    {
        this.vazio = vazio;
    }

    public bool GetVazio()
    {
        return vazio;
    }

    public void SetConteudo(string conteudo)
    {
        this.conteudo = conteudo;
    }

    public string GetConteudo()
    {
        return conteudo;
    }
}
