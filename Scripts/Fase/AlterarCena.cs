using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AlterarCena : MonoBehaviour
{
    public void MudarDeCena(string nomeDaCena)
    {
        SceneManager.LoadScene(nomeDaCena);
    }
}
