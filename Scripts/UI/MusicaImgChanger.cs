using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicaImgChanger : MonoBehaviour
{
    public Sprite musicaTocando;
    public Sprite musicaMutada;
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
                transform.GetComponent<Image>().sprite = musicaTocando;
            }
            else
            {
                transform.GetComponent<Image>().sprite = musicaMutada;
            }
        }
    }

    public void ChamarAlternanciaMusica()
    {
        configSom.AlternarMusica();
    }
}
