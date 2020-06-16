using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pad : MonoBehaviour
{
    public bool ativo;
    // Start is called before the first frame update
    void Start()
    {
        ativo = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        ativo = true;
        Debug.Log("Pad ativado");
    }

    public bool IsAtivo()
    {
        return this.ativo;
    }

    public void SetAtivo(bool setter)
    {
        this.ativo = setter;
    }
}
