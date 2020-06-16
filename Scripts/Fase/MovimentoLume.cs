using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoLume : MonoBehaviour
{
    public bool congelado;
    private bool emMovimento;
    private float velocidade;
    public Vector3 destino;

    void Start()
    {
        congelado = false;
        emMovimento = false;
        velocidade = 12f;
        destino = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!congelado)
        {
            if (Input.GetMouseButton(0))
            {
                CriarDestino();
            }

            if (emMovimento)
            {
                Movimentacao();
            }
        }
    }

    void CriarDestino()
    {
        destino = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y,
            Camera.main.nearClipPlane));

        emMovimento = true;
    }

    void Movimentacao()
    {
        //transform.rotation = Quaternion.LookRotation(Vector3.forward, destino);
        transform.position = Vector3.MoveTowards(transform.position, destino, velocidade * Time.deltaTime);
        if (transform.position == destino)
        {
            emMovimento = false;
        }
    }

    public bool IsCongelado()
    {
        return this.congelado;
    }

    public void setCongelado(bool cong)
    {
        this.congelado = cong;
    }
}
