using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetodosGerais : MonoBehaviour
{
    public void AlternarEstadoAtivo(GameObject objeto)
    {
        if(!objeto.activeSelf)
            objeto.SetActive(true);
        else
            objeto.SetActive(false);
    }

    public void AlternarEstadoFuncional(GameObject objeto)
    {
        if (!objeto.GetComponent<Behaviour>().enabled)
            objeto.GetComponent<Behaviour>().enabled = true;
        else
            objeto.GetComponent<Behaviour>().enabled = false;
    }
}
