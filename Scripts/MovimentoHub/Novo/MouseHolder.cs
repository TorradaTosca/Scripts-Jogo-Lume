using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseHolder : MonoBehaviour
{
    private bool ativo = false;
    
    private void OnMouseOver()
    {
        ativo = true;
    }

    private void OnMouseExit()
    {
        ativo = false;
    }

    public bool GetAtivo()
    {
        return ativo;
    }
}
