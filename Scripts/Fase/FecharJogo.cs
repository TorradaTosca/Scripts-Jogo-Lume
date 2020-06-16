using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FecharJogo : MonoBehaviour
{
    public void FecharOJogo()
    {
        Application.Quit();
        Debug.Log("Jogo fechado");
    }
}
