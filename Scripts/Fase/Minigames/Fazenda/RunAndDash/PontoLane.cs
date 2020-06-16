using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PontoLane : MonoBehaviour
{
    public GameObject lumeRunner;
    public int posicao;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Vector3 otherPos = other.gameObject.transform.position;
            Vector3 selfPos = transform.position;

            other.gameObject.transform.position = new Vector3(selfPos.x, selfPos.y, otherPos.z);
            other.gameObject.GetComponent<LumeRunner>().setDirecao(0);
            other.gameObject.GetComponent<LumeRunner>().lane = posicao;
        }
    }
}
