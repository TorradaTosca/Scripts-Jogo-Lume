using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SomImgChanger : MonoBehaviour
{
    public Sprite somTocando;
    public Sprite somMutado;
    public GameObject configuracaoSom;
    public ConfigSom configSom;
    
    private void Start()
    {
        configuracaoSom = GameObject.FindWithTag("AudioConfig");
        configSom = configuracaoSom.GetComponent<ConfigSom>();
    }

    private void Update()
    {
        if (configuracaoSom != null)
        {
            if(configSom.GetSomAtivo())
            {
                transform.GetComponent<Image>().sprite = somTocando;
            }
            else
            {
                transform.GetComponent<Image>().sprite = somMutado;
            }
        }
    }

    public void ChamarAlternanciaSom()
    {
        configSom.AlternarSom();
    }
}
