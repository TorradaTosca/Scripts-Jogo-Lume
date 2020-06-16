using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class HubMovement : MonoBehaviour
{
    public GameObject lume;
    public GameObject[] pads;
    public PathCreator[] paths;

    private int destino;
    private int posicao;
    private float velocidade;
    private float distancia;

    // Start is called before the first frame update
    void Start()
    {
        velocidade = 4f;
        destino = 0;
        posicao = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if((posicao != destino) && (destino != -1))
        {
            if(posicao < destino)
            {
                if (lume.transform.position == paths[posicao].path.GetPointAtTime(0.99f))
                {
                    posicao++;
                    distancia = 0f;
                    Debug.Log("Posicao atualizada");
                }
                else
                {
                    distancia += velocidade * Time.deltaTime;
                    lume.transform.position = paths[posicao].path.GetPointAtDistance(distancia, EndOfPathInstruction.Stop);

                    //Debug.Log(lume.transform.position.ToString());
                    //Debug.Log(paths[posicao].path.GetPointAtDistance(distancia));
                }
            }
            else if (posicao > destino)
            {
                if (lume.transform.position == paths[posicao-1].path.GetPointAtTime(0.99f))
                {
                    posicao--;
                    distancia = 0f;
                    Debug.Log("Posicao atualizada");
                }
                else
                {
                    distancia -= velocidade * Time.deltaTime;
                    lume.transform.position = paths[posicao-1].path.GetPointAtDistance(distancia, EndOfPathInstruction.Stop);

                    //Debug.Log(lume.transform.position.ToString());
                    //Debug.Log(paths[posicao].path.GetPointAtDistance(distancia));
                }
            }
        }
        else
        {
            for (int i = 0; i < pads.Length; i++)
            {
                if (pads[i].GetComponent<Pad>().IsAtivo())
                {
                    if (posicao != i)
                    {
                        destino = i;

                        for (int j = 0; i < pads.Length; i++)
                        {
                            if (j != i)
                            {
                                pads[j].GetComponent<Pad>().SetAtivo(false);
                            }
                        }
                        Debug.Log("Destino criado");
                    }
                }
            }
        }
    }

    private void OnMouseUp()
    {
        for (int i = 0; i < pads.Length; i++)
        {
            if (pads[i].tag == "Pad")
            {
                if (pads[i].GetComponent<Pad>().IsAtivo())
                {
                    if(posicao != i)
                    {
                        destino = i;

                        for (int j = 0; i < pads.Length; i++)
                        {
                            if(j != i)
                            {
                                pads[j].GetComponent<Pad>().SetAtivo(false);
                            }
                        }
                        Debug.Log("Destino criado");
                    }
                    Debug.Log("Passo 3");
                }
                Debug.Log("Passo 2");
            }
            Debug.Log("Passo 1");
        }
    }
}
