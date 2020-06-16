using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class MovimentoLumeHub : MonoBehaviour
{
    public float testeTempo = 0;
    public GameObject[] hubPads;
    public PathCreator caminho;
    public int destino = -1;
    public int posicao = 0;
    public float distanciaTempo = 0f;
    private float velocidadeTempo = 0.002f;
    private Animator animator;
    public bool emMovimento = false;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (emMovimento)
        {
            if (destino > posicao)
            {
                distanciaTempo += velocidadeTempo * 80 * Time.deltaTime;
                Vector3 novoPonto = caminho.path.GetPointAtTime(distanciaTempo, EndOfPathInstruction.Stop);
                transform.position = new Vector3(novoPonto.x, novoPonto.y, transform.position.z);
                animator.SetBool("DeCostas", true);
            }
            else if (destino < posicao)
            {
                distanciaTempo -= velocidadeTempo * 80 * Time.deltaTime;
                Vector3 novoPonto = caminho.path.GetPointAtTime(distanciaTempo, EndOfPathInstruction.Stop);
                transform.position = new Vector3(novoPonto.x, novoPonto.y, transform.position.z);
                animator.SetBool("DeCostas", false);
            }
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            transform.position = caminho.path.GetPointAtTime(testeTempo, EndOfPathInstruction.Stop);
        }
    }

    public void ResetarDestino()
    {
        destino = -1;

        foreach(GameObject pad in hubPads)
        {
            pad.GetComponent<PadHub>().SetDestino(false);
        }
    }

    public void MoverParaDestino(int padID)
    {
        destino = padID;
        emMovimento = true;
        Debug.Log("em movimento");
    }

    public void DestinoAlcancado()
    {
        emMovimento = false;
        Vector3 padPos = hubPads[destino].GetComponent<Transform>().position;
        transform.position = new Vector3(padPos.x, padPos.y + 1.2f, transform.position.z);
        animator.SetBool("DeCostas", false);
    }

    public void SetPosicao(int posicao)
    {
        this.posicao = posicao;
    }

    public int GetPosicao()
    {
        return posicao;
    }
}
