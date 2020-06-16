using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Vala : MonoBehaviour
{
    public GameObject logger;
    public AudioClip somDerrota;
    public GameObject bolinha;
    public GameObject telaDerrota;
    public GameObject botoesPlacaGrande;
    public GameObject botaoEjetar;
    public Text textoPontuacao;
    //public Text textoPontFinal;
    private float defaultX;
    private float defaultY;
    private int pontos = 0;

    void Start()
    {
        defaultX = bolinha.transform.localPosition.x;
        defaultY = bolinha.transform.localPosition.y;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            logger.GetComponent<LoggerPinball>().ColocarPontos(pontos);
            other.transform.localPosition = new Vector3(defaultX, defaultY, 0f);
            pontos = 0;
            telaDerrota.SetActive(true);
            botoesPlacaGrande.SetActive(false);
            transform.GetComponent<AudioSource>().volume = 0.7f;
            transform.GetComponent<AudioSource>().clip = somDerrota;
            transform.GetComponent<AudioSource>().Play();
        }
    }

    public void AumentarPontos(int pontos)
    {
        this.pontos += pontos;
        textoPontuacao.text = this.pontos.ToString();
    }

    public void EjetarBolinha()
    {
        bolinha.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, Random.Range(2500f, 2751f)));
        textoPontuacao.text = this.pontos.ToString();
    }

    public void ResetarMinigame()
    {
        bolinha.transform.localPosition = new Vector3(defaultX, defaultY, 0f);
        pontos = 0;
        botaoEjetar.SetActive(true);
    }
}
