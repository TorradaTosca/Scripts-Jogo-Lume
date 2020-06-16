using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PecaTetris : MonoBehaviour
{
    public GameObject loggerBlocos;
    public Vector3 pontoRotacao;
    public bool rotacionavel;
    public GameObject geradorPecas;
    public GameObject gameover;
    public GameObject botoesPlacaGrande;
    private float tempoQueda = 0.8f;
    private float tempoAnterior;
    private float tempoAnteriorHor;
    private bool primeiroMov = true;
    private bool desabilitado = false;
    public static int altura = 11;
    public static int largura = 12;
    private static Transform[,] grid = new Transform[largura, altura + 3];
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!desabilitado)
        {
            MoverPecaHorizontalmente();
            MoverPecaVerticalmente();
            GirarPeca();
        }
    }

    void MoverPecaHorizontalmente()
    {
        if(primeiroMov)
        {
            tempoAnteriorHor = Time.time;
            if (Input.GetKey(KeyCode.RightArrow))
            {
                primeiroMov = false;
                transform.position += new Vector3(1f, 0f, 0f);
                if (!ValidarMovimento())
                {
                    transform.position -= new Vector3(1f, 0f, 0f);
                }
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                primeiroMov = false;
                transform.position += new Vector3(-1f, 0f, 0f);
                if (!ValidarMovimento())
                {
                    transform.position -= new Vector3(-1f, 0f, 0f);
                }
            }
        }
        else if (Time.time - tempoAnteriorHor >= (Input.GetKey(KeyCode.DownArrow) ? 0.1f : 0.2f))
        {
            tempoAnteriorHor = Time.time;
            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.position += new Vector3(1f, 0f, 0f);
                if (!ValidarMovimento())
                {
                    transform.position -= new Vector3(1f, 0f, 0f);
                }
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.position += new Vector3(-1f, 0f, 0f);
                if (!ValidarMovimento())
                {
                    transform.position -= new Vector3(-1f, 0f, 0f);
                }
            }
        }

        if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.LeftArrow))
        {
            tempoAnteriorHor = 0f;
            primeiroMov = true;
        }
    }

    void MoverPecaVerticalmente()
    {
        if (Time.time - tempoAnterior > (Input.GetKey(KeyCode.DownArrow) ? tempoQueda / 6 : tempoQueda))
        {
            transform.position += new Vector3(0f, -1f, 0f);
            tempoAnterior = Time.time;
            if (!ValidarMovimento())
            {
                transform.position -= new Vector3(0f, -1f, 0f);
                AdicionarNoGrid();
                desabilitado = true;

                int gerX = Mathf.RoundToInt(geradorPecas.transform.position.x);
                int gerY = Mathf.RoundToInt(geradorPecas.transform.position.y);

                if (grid[gerX, gerY] == null)
                {
                    ChecarPorLinhas();
                    geradorPecas.GetComponent<GeradorPecas>().CriarPeca();
                }
                else
                {
                    gameover.SetActive(true);
                    botoesPlacaGrande.SetActive(false);
                    geradorPecas.GetComponent<GeradorPecas>().DestruirPecas();
                    geradorPecas.GetComponent<GeradorPecas>().TocarSomDerrota();
                }
            }
        }
    }

    void GirarPeca()
    {
        if ((Input.GetKeyDown(KeyCode.UpArrow)) && (rotacionavel))
        {
            transform.RotateAround(transform.TransformPoint(pontoRotacao), new Vector3(0f, 0f, 1f), 90);
            if (!ValidarMovimento())
            {
                transform.RotateAround(transform.TransformPoint(pontoRotacao), new Vector3(0f, 0f, 1f), -90);
            }
        }
    }

    void AdicionarNoGrid()
    {
        foreach (Transform children in transform)
        {
            int arredondadoX = Mathf.RoundToInt(children.position.x);
            int arredondadoY = Mathf.RoundToInt(children.position.y);

            grid[arredondadoX, arredondadoY] = children;
        }
    }

    void ChecarPorLinhas()
    {
        for (int i = altura - 1; i >= 0; i--)
        {
            while (ExisteLinhaCheia(i))
            {
                DeletarLinha(i);
                AbaixarPecas(i);
            }
        }
    }

    void DeletarLinha(int i)
    {
        for (int j = 0; j < largura; j++)
        {
            if (grid[j, i] != null)
            {
                Destroy(grid[j, i].gameObject);
                grid[j, i] = null;
                geradorPecas.GetComponent<GeradorPecas>().AumentarPontos(10);
            }
        }
        loggerBlocos.GetComponent<LoggerBlocosDeFeno>().CompletouLinha();
    }

    void AbaixarPecas(int i)
    {
        for (int y = i; y < altura; y++)
        {
            for (int j = 0; j < largura; j++)
            {
                if ((grid[j, y] != null) && (y > 0))
                {
                    int numeroEspacos = ContarEspacosVazios(j, y);

                    grid[j, y - numeroEspacos] = grid[j, y];
                    grid[j, y] = null;
                    grid[j, y - numeroEspacos].transform.position -= new Vector3(0f, numeroEspacos, 0f);
                }
            }
        }
    }

    bool ValidarMovimento()
    {
        foreach (Transform children in transform)
        {
            int arredondadoX = Mathf.RoundToInt(children.position.x);
            int arredondadoY = Mathf.RoundToInt(children.position.y);

            if ((arredondadoX < 0) || (arredondadoX >= largura) || (arredondadoY < 0) || (arredondadoY >= altura + 3))
            {
                return false;
            }
            else if (grid[arredondadoX, arredondadoY] != null)
            {
                return false;
            }
        }

        return true;
    }

    bool ExisteLinhaCheia(int i)
    {
        for (int j = 0; j < largura; j++)
        {
            if (grid[j, i] == null)
            {
                return false;
            }
        }

        return true;
    }

    bool ExisteEspacoVazio(int x, int y)
    {
        if (y >= 0)
        {
            if (grid[x, y] != null)
            {
                return false;
            }
        }
        else
        {
            return false;
        }

        return true;
    }

    int ContarEspacosVazios(int x, int y)
    {
        int contador = 0;
        while (true)
        {
            if (ExisteEspacoVazio(x, y - 1))
            {
                contador++;
                y--;
            }
            else
            {
                break;
            }
        }

        return contador;
    }
}