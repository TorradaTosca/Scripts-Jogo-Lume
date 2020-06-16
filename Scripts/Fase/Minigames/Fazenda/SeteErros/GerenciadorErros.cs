using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GerenciadorErros : MonoBehaviour
{
    public GameObject[] erros;
    public GameObject botoesPlaca;
    public GameObject telaErrosEncontrados;
    public GameObject inProg;

    private MetodosGerais metodos;
    private bool achados = false;

    private void Start()
    {
        metodos = transform.GetComponent<MetodosGerais>();
    }
    // Update is called once per frame
    void Update()
    {
        if ((ErrosEncontrados()) && (!achados))
        {
            achados = true;
            telaErrosEncontrados.SetActive(true);

            if(inProg.GetComponent<IntermediadorProgresso>().RequisitarEventoFaseAtual() == 1)
                inProg.GetComponent<IntermediadorProgresso>().AumentarEventoFaseAtual();

            foreach(Transform botao in botoesPlaca.transform)
            {
                metodos.AlternarEstadoFuncional(botao.gameObject);
            }
            transform.GetComponent<MngMusicaFase>().TocarMusicaShot();
        }
    }

    bool ErrosEncontrados()
    {
        bool verificador = true;

        foreach (GameObject erro in erros)
        {
            if (!erro.GetComponent<Erro>().GetEncontrado())
            {
                verificador = false;
                break;
            }
        }

        return verificador;
    }

    public void ResetarErros()
    {
        foreach (GameObject erro in erros)
        {
            erro.GetComponent<Erro>().SetEncontrado(false);
            erro.GetComponent<Image>().enabled = false;
            achados = false;
        }
    }
}
