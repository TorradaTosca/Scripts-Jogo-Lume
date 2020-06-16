using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class SalvarHistoria : MonoBehaviour
{
    DateTime data;
    public InputField txtNome;
    public InputField txtTurma;
    public InputField txtTitulo;
    public InputField txtTexto;
    public Texture2D imagemFundo;
    public GameObject carregadorImagem;
    private string nome;
    private string turma;
    private string titulo;
    private string texto;
    private string diretorio;
    private string imagemBase64;

    void Start()
    {
        nome = txtNome.text;
        turma = txtTurma.text;
        titulo = txtTitulo.text;
        texto = txtTexto.text;
        diretorio = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop) + @"/" + "ArquivosLume" + "História" + "_" + nome + ".html";
    }

    public void SalvarArquivoTexto()
    {
        nome = txtNome.text;
        turma = txtTurma.text;
        titulo = txtTitulo.text;
        texto = txtTexto.text;
        diretorio = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop) + @"/" + "ArquivosLume" + @"/" + "História" + "_" + nome + ".html";
        if(!Directory.Exists(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop) + @"/" + "ArquivosLume"))
            Directory.CreateDirectory(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop) + @"/" + "ArquivosLume");

        using (StreamWriter writer = new StreamWriter(diretorio, false))
        {
            writer.WriteLine("<!DOCTYPE html>");
            writer.WriteLine("<html>");
            writer.WriteLine("  <head>");
            writer.WriteLine("      <style>");
            writer.WriteLine("          body{");
            writer.WriteLine("              background-image: url(\"data:image/png;base64,{0}\");", System.Convert.ToBase64String(imagemFundo.EncodeToPNG()));
            writer.WriteLine("              background-repeat: round;");
            writer.WriteLine("          }");
            writer.WriteLine("          div{");
            writer.WriteLine("              display: block;");
            writer.WriteLine("              margin: 2%;");
            writer.WriteLine("              background-color: rgba(236, 236, 236, 0.5);");
            writer.WriteLine("              align-content: center;");
            writer.WriteLine("          }");
            writer.WriteLine("          img{");
            writer.WriteLine("              display: block;");
            writer.WriteLine("              margin-left: auto;");
            writer.WriteLine("              margin-right: auto;");
            writer.WriteLine("              width: 40%;");
            writer.WriteLine("          }");
            writer.WriteLine("          .tituloLabel{");
            writer.WriteLine("              text-align: center;");
            writer.WriteLine("              align-self: center;");
            writer.WriteLine("          }");
            writer.WriteLine("      </style>");
            writer.WriteLine("  </head>");
            writer.WriteLine("  <body style=\"background-repeat: round;\">");
            writer.WriteLine("      <form>");
            writer.WriteLine("          <div>");
            writer.WriteLine("              <label for=\"nome\">Nome: </label>");
            writer.WriteLine("              <textarea id=\"nome\" name=\"caixaNome\" rows=\"1\" cols=\"50\" readonly>{0}</textarea>", nome);
            writer.WriteLine("              <label for=\"turma\">Turma: </label>");
            writer.WriteLine("              <textarea id=\"turma\" name=\"caixaTurma\" rows=\"1\" cols=\"40\" readonly>{0}</textarea>", turma);
            writer.WriteLine("              <label for=\"data\">Data: </label>");
            writer.WriteLine("              <textarea id=\"data\" name=\"caixaData\" rows=\"1\" cols=\"30\" readonly>{0}/{1}/{2}</textarea>", DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year);
            writer.WriteLine("          </div>");
            writer.WriteLine("          <div>");
            writer.WriteLine("              <label for=\"titulo\" class=\"tituloLabel\">Título: </label>");
            writer.WriteLine("              <br>");
            writer.WriteLine("              <textarea id=\"titulo\" name=\"caixaTitulo\" rows=\"1\" cols=\"150\" readonly>{0}</textarea>", titulo);
            writer.WriteLine("              <br>");
            writer.WriteLine("              <br>");
            writer.WriteLine("              <label for=\"titulo\" class=\"tituloLabel\">Texto redigido: </label>");
            writer.WriteLine("              <br>");
            writer.WriteLine("              <textarea id=\"titulo\" name=\"caixaTitulo\" rows=\"16\" cols=\"150\" readonly>{0}</textarea>", texto);
            writer.WriteLine("          </div>");
            writer.WriteLine("          <div>");
            writer.WriteLine("              <p style=\"text-align: center;\">Imagem adicionada</p>");
            writer.WriteLine("              <img src=\"data:image/png;base64,{0}\">", imagemBase64);
            writer.WriteLine("          </div>");
            writer.WriteLine("      </form>");
            writer.WriteLine("  </body>");
            writer.WriteLine("</html>");
        }
    }

    public void SetImagemBase64()
    {
        if(carregadorImagem.GetComponent<EscolherImagem>().GetImagem64() != null)
        {
            imagemBase64 = carregadorImagem.GetComponent<EscolherImagem>().GetImagem64();
        }
    }
}
