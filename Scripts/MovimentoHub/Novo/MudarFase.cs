using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MudarFase : MonoBehaviour
{
    public Text textoNomeFase;
    private string nomeFase = "";
    private bool mostrar = false;
    private const float Y_MOSTRAR_MAX = 195;
    private const float Y_MOSTRAR_MIN = 555;
    private const float VELOCIDADE = 200f;
    private void Start()
    {
        StartCoroutine(SubirDescerPlaca());
    }

    public void MudarDeFase()
    {
        SceneManager.LoadScene(nomeFase);
    }

    public void SetNomeFase(string nomeFase)
    {
        this.nomeFase = nomeFase;
    }

    public string GetNomeFase()
    {
        return nomeFase;
    }

    public void SetMostrar(bool mostrar)
    {
        this.mostrar = mostrar;
    }

    public bool GetMostrar()
    {
        return mostrar;
    }

    public void AlterarDescricao(string descricao)
    {
        textoNomeFase.text = descricao;
    }

    IEnumerator SubirDescerPlaca()
    {
        while(true)
        {
            yield return new WaitForSeconds(1/60);
            if(mostrar)
            {
                if (transform.localPosition.y > Y_MOSTRAR_MAX)
                {
                    float novoY = transform.localPosition.y - 5;
                    if (novoY < Y_MOSTRAR_MAX) novoY = Y_MOSTRAR_MAX;
                    Vector3 novaPos = new Vector3(transform.localPosition.x, novoY, transform.localPosition.z);
                    transform.localPosition = Vector3.Lerp(transform.localPosition, novaPos, VELOCIDADE * Time.deltaTime);
                }
            }
            else
            {
                if (transform.localPosition.y < Y_MOSTRAR_MIN)
                {
                    float novoY = transform.localPosition.y + 5;
                    if (novoY > Y_MOSTRAR_MIN) novoY = Y_MOSTRAR_MIN;
                    Vector3 novaPos = new Vector3(transform.localPosition.x, novoY, transform.localPosition.z);
                     transform.localPosition = Vector3.Lerp(transform.localPosition, novaPos, VELOCIDADE * Time.deltaTime);
                }
            }
        }
        //yield return null;
    }
}
