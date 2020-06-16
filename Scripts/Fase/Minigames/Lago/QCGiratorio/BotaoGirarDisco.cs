using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotaoGirarDisco : MonoBehaviour
{
    public float velocidadeGiro;
    public GerenciadorDiscos gerenciadorDiscos;
    private bool giroAtivo = false;
    private GameObject discoAlvo;
    private float rotacao = 0f;

    void Update()
    {
        if (giroAtivo)
        {
            rotacao += velocidadeGiro * Time.deltaTime;
            discoAlvo.transform.localRotation = Quaternion.Euler(0f, 0f, rotacao);
        }
    }

    private void OnMouseDown()
    {
        discoAlvo = gerenciadorDiscos.GetDiscoAtivo();
        rotacao = discoAlvo.transform.localRotation.eulerAngles.z;
        giroAtivo = true;
    }

    private void OnMouseUp()
    {
        giroAtivo = false;
    }
}
