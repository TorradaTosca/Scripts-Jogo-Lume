using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PontuadorPinball : MonoBehaviour
{
    public AudioClip somBolinha;
    public int ponto = 0;
    public GameObject vala;
    
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Player"))
        {
            vala.GetComponent<Vala>().AumentarPontos(ponto);
            transform.GetComponent<AudioSource>().volume = 0.7f;
            transform.GetComponent<AudioSource>().clip = somBolinha;
            transform.GetComponent<AudioSource>().Play();
        }
        else
        {
            //LOL
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player"))
        {
            vala.GetComponent<Vala>().AumentarPontos(ponto);
            transform.GetComponent<AudioSource>().volume = 0.7f;
            transform.GetComponent<AudioSource>().clip = somBolinha;
            transform.GetComponent<AudioSource>().Play();
        }
        else
        {
            //LOL
        }
    }
}
