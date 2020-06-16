using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LetraForca : MonoBehaviour
{
    public Text textoLetra;
    private char letraCorreta = ' ';
    private char letraDisplay = ' ';
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        textoLetra.text = letraDisplay.ToString();
    }

    public void SetLetraCorreta(char c)
    {
        letraCorreta = c;
    }

    public char GetLetraCorreta()
    {
        return letraCorreta;
    }

    public void SetLetraDisplay(char c)
    {
        letraDisplay = c;
    }

    public char GetLetraDisplay()
    {
        return letraDisplay;
    }
}
