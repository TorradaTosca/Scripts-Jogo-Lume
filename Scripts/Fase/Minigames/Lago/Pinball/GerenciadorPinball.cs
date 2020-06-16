using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GerenciadorPinball : MonoBehaviour
{
    public GameObject bolinha;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            bolinha.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, Random.Range(2500f, 2751f)));
        }
    }
}
