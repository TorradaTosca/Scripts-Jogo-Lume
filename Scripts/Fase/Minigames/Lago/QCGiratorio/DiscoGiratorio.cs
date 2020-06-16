using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscoGiratorio : MonoBehaviour
{
    public GerenciadorDiscos gerenciadorDiscos;
    public int idDisco = 0;

    private void Start()
    {
        int angulo = Random.Range(0, 360);
        transform.localRotation = Quaternion.Euler(0, 0, angulo);
    }

    private void OnMouseDown()
    {
        gerenciadorDiscos.SetDiscoSelecionado(idDisco);
    }
}
