using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReceptorLetra : MonoBehaviour
{
    public Text textoLetra;
    public GameObject objGerenciadorForca;
    private char letra = ' ';

    // Update is called once per frame
    void Update()
    {
        ReceberLetraInput();
        textoLetra.text = letra.ToString();
    }

    void ReceberLetraInput()
    {
        foreach (char c in Input.inputString)
        {
            if (c == '\b') // backspace/delete
            {
                letra = ' ';
            }
            else if ((c == '\n') || (c == '\r')) // enter
            {
                //objGerenciadorForca.GetComponent<GerenciadorForca>().ReceberLetraUsuario(letra);
            }
            else // qualquer outra tecla
            {
                if(!objGerenciadorForca.GetComponent<GerenciadorForca>().GetCongelado())
                {
                    letra = c;
                    objGerenciadorForca.GetComponent<GerenciadorForca>().ReceberLetraUsuario(letra);
                }
            }
        }
    }
}
