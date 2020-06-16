using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotoEscEsc : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<MovimentoLumeEE>().SetPertoBoto(true);
            Debug.Log("Entrou");
        }
        else
        {
            //LOL
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<MovimentoLumeEE>().SetPertoBoto(false);
            Debug.Log("Saiu");
        }
        else
        {
            //LOL
        }
    }
}
