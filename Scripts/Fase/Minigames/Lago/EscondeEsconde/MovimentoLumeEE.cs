using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoLumeEE : MonoBehaviour
{
    public AudioClip somCerto;
    public float velocidade;
    public GerenciadorEscEsc gerenciador;
    private int horizontal;
    private int vertical;
    private bool congelado = false;
    private bool pertoBoto = false;

    void Update()
    {
        if(!congelado)
        {
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                horizontal = -1;
            }
            else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                horizontal = 1;
            }
            else
            {
                horizontal = 0;
            }
            if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
                && (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)))
                {
                    horizontal = 0;
                }

            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                vertical = 1;
            }
            else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                vertical = -1;
            }
            else
            {
                vertical = 0;
            }
            if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
                && (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)))
                {
                    vertical = 0;
                }

            if((Input.GetKeyDown(KeyCode.Space)) && (pertoBoto))
            {
                transform.GetComponent<AudioSource>().volume = 0.7f;
                transform.GetComponent<AudioSource>().clip = somCerto;
                transform.GetComponent<AudioSource>().Play();
                gerenciador.EncontrouBoto();
                pertoBoto = false;
            }
        }
    }

    void FixedUpdate()
    {
        Vector3 movimento = new Vector3(
                                        velocidade * Time.deltaTime * horizontal,
                                        velocidade * Time.deltaTime * vertical,
                                        0f
                                        );
        //transform.GetComponent<Rigidbody>().MovePosition(movimento);
        transform.GetComponent<Rigidbody>().velocity = movimento;
    }

    public void SetCongelado(bool congelado)
    {
        this.congelado = congelado;
        if(congelado)
        {
            horizontal = 0;
            vertical = 0;
        }
    }

    public void SetPertoBoto(bool pertoBoto)
    {
        this.pertoBoto = pertoBoto;
    }
}
