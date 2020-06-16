using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Erro : MonoBehaviour
{
    private bool encontrado;

    private void OnMouseDown()
    {
        if (!transform.GetComponent<Image>().enabled)
        {
            transform.GetComponent<Image>().enabled = true;
        }
        if(!encontrado)
        {
            transform.GetComponent<MngMusicaFase>().TocarMusicaShot();
        }
        encontrado = true;
    }

    public void SetEncontrado(bool enc)
    {
        encontrado = enc;
    }

    public bool GetEncontrado()
    {
        return encontrado;
    }
}
