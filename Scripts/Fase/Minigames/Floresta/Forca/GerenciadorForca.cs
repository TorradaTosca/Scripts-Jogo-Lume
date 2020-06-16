using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

public class GerenciadorForca : MonoBehaviour
{
    public GameObject logger;
    public AudioClip somVitoria;
    public AudioClip somDerrota;
    public AudioClip somErrado;
    public AudioClip somCerto;
    public GameObject[] letrasForca;
    public GameObject[] partesCurupira;
    public GameObject telaDerrota;
    public GameObject botoesPlacaGrande;
    public GameObject receptorLetra;
    public Text letrasUsadas;
    public string[] palavras;
    private string letrasPalavraAtual = "";
    private List<int> palavrasJaEscolhidas;
    private int erros = 0;
    private int acertos = 0;
    private bool congelado = false;

    // Start is called before the first frame update
    void Start()
    {
      palavrasJaEscolhidas = new List<int>();
      GerarPalavra(0);
    }

    void GerarPalavra(int delay)
    {
      Debug.Log("Entrou");
      while (true)
      {
        if (delay > 0)
        {
          delay--;
        }
        else
        {
          string palavraEscolhida = "";
          int contador = 0;
          letrasPalavraAtual = "";

          while (true)
          {
            //Permitir repetição de palavras depois que todas forem usadas
            if (palavrasJaEscolhidas.Count == palavras.Length)
            {
              palavrasJaEscolhidas.Clear();
            }

            int numeroPalavra = Random.Range(0, palavras.Length);
            bool validarPalavra = true;

            if (palavrasJaEscolhidas.Contains(numeroPalavra)) validarPalavra = false;

            if (validarPalavra)
            {
              Debug.Log(numeroPalavra);
              palavraEscolhida = palavras[numeroPalavra];
              palavrasJaEscolhidas.Add(numeroPalavra);

              break;
            }
          }

          for (int i = 0; i < palavraEscolhida.ToCharArray().Length; i++)
          {
            letrasForca[i].SetActive(true);
            letrasForca[i].GetComponent<LetraForca>().SetLetraCorreta(palavraEscolhida.ToCharArray()[i]);
          }

          for (int i = palavraEscolhida.ToCharArray().Length; i < letrasForca.Length; i++)
          {
            letrasForca[i].SetActive(false);
          }

          foreach(char letra in palavraEscolhida)
          {
            bool validador = true;

            foreach(char outraLetra in letrasPalavraAtual)
            {
              if (letra == outraLetra)
              {
                validador = false;
                break;
              }
            }

            if (validador)
            {
              letrasPalavraAtual += letra;
              contador++;
            }
          }

          break;
        }
      }
      Debug.Log("Saiu");
    }

    void ChecarPalavraMontada()
    {
      string palavraFormada = "";
      int indicePalavra = palavrasJaEscolhidas[palavrasJaEscolhidas.Count-1];

      for (int i = 0; i < palavras[indicePalavra].Length; i++)
      {
        palavraFormada += letrasForca[i].GetComponent<LetraForca>().GetLetraDisplay();
      }

      //Debug.Log(palavraFormada + " | " + palavras[indicePalavra]);
      if (palavraFormada.Trim() == palavras[indicePalavra])
      {
        foreach (GameObject letra in letrasForca)
        {
          bool antes = letra.activeSelf;
          letra.SetActive(true);
          letra.GetComponent<LetraForca>().SetLetraDisplay(' ');
          letra.SetActive(antes);
        }

        for(int i = 0; i < partesCurupira.Length; i++)
        {
          partesCurupira[i].SetActive(false);
        }
        erros = 0;
        letrasUsadas.text = "";

        acertos++;
        transform.GetComponent<AudioSource>().clip = somVitoria;
        transform.GetComponent<AudioSource>().Play();
        logger.GetComponent<LoggerForca>().AcertouPalavra();
        GerarPalavra(30);
      }
    }

    public void ReceberLetraUsuario(char letraRecebida)
    {
      EscreverLetraForca(letraRecebida);
      if (erros < 6) ChecarPalavraMontada(); else AcionarGameOver();
    }

    void EscreverLetraForca(char letraRecebida)
    {
      Regex regex = new Regex("[A-ZzÇa-zç]");
      bool escreveuAlgumaLetra = false;
      bool naoEhNova = false;
      if((!letrasUsadas.text.Contains(letraRecebida.ToString())) && (regex.Match(letraRecebida.ToString()).Success))
      {
        foreach(GameObject letraForca in letrasForca)
        {
          if ((letraForca.GetComponent<LetraForca>().GetLetraCorreta() == letraRecebida)
              || ((letraForca.GetComponent<LetraForca>().GetLetraCorreta() == 'ç') && (letraRecebida == 'c')))
          {
            if(letraForca.GetComponent<LetraForca>().GetLetraDisplay() == ' ')
            {
              letraForca.GetComponent<LetraForca>().SetLetraDisplay(letraForca.GetComponent<LetraForca>().GetLetraCorreta());
              escreveuAlgumaLetra = true;
            }
            else
            {
              escreveuAlgumaLetra = true;
              naoEhNova = true;
            }
          }
        }
      }
      else
      {
        escreveuAlgumaLetra = true;
        naoEhNova = true;
      }

      if (!escreveuAlgumaLetra)
      {
        AdicionarErro(letraRecebida);
        transform.GetComponent<AudioSource>().clip = somErrado;
        transform.GetComponent<AudioSource>().Play();
      }
      else
      {
        if(!naoEhNova)
        {
          transform.GetComponent<AudioSource>().clip = somCerto;
          transform.GetComponent<AudioSource>().Play();
        }
      }
    }

    void AdicionarErro(char c)
    {
      erros++;
      letrasUsadas.text += " " + c.ToString();
      for(int i = 0; (i < partesCurupira.Length) && (i < erros); i++)
      {
        partesCurupira[i].SetActive(true);
      }
      logger.GetComponent<LoggerForca>().ErrouLetra();
    }

    public void ResetarForca()
    {
      congelado = false;
      erros = 0;
      palavrasJaEscolhidas.Clear();
      letrasPalavraAtual = "";
      letrasUsadas.text = "";
      for(int i = 0; i < partesCurupira.Length; i++)
      {
        partesCurupira[i].SetActive(false);
      }
      foreach (GameObject letra in letrasForca)
      {
        letra.GetComponent<LetraForca>().SetLetraDisplay(' ');
      }
      GerarPalavra(0);
    }

    void AcionarGameOver()
    {
      telaDerrota.SetActive(true);
      botoesPlacaGrande.SetActive(false);
      transform.GetComponent<AudioSource>().clip = somDerrota;
      transform.GetComponent<AudioSource>().Play();
      congelado = true;
    }

    public bool GetCongelado()
    {
      return congelado;
    }
}
