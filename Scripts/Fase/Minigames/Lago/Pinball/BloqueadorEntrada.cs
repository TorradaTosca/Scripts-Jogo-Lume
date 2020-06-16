using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloqueadorEntrada : MonoBehaviour
{
    public GameObject bloqueio;
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            bloqueio.SetActive(true);
        }
        else
        {

        }
    }
    public void ResetarBloqueio()
    {
        bloqueio.SetActive(false);
    }
}
