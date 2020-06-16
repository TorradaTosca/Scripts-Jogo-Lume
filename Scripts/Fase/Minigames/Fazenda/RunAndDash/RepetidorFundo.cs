using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepetidorFundo : MonoBehaviour
{
    public float velocidadeFundo;
    public Renderer rederizadorFundo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rederizadorFundo.material.mainTextureOffset += new Vector2(0f, velocidadeFundo * Time.deltaTime);
    }

    public void SetVelocidadeFundo(float vel)
    {
        velocidadeFundo = vel;
    }

    public float GetVelocidadeFundo()
    {
        return velocidadeFundo;
    }
}
