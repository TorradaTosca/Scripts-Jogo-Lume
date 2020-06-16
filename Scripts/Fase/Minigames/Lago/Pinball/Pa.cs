using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pa : MonoBehaviour
{
    public AudioClip somPa;
    public bool ehEsquerda = true;
    public float limiteMax = 0f;
    public float limiteMin = 0f;
    public float velocidade = 1f;
    private bool subindo = false;
    public float forca = 0f;
    public float forcaX = 0f;
    void Update()
    {
        if (ehEsquerda)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                subindo = true;
                StartCoroutine(MoverPa());
            }
            else if (Input.GetKeyUp(KeyCode.LeftArrow))
            {
                forca = 0;
                subindo = false;
                StartCoroutine(MoverPa());
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                subindo = true;
                StartCoroutine(MoverPa());
            }
            else if (Input.GetKeyUp(KeyCode.RightArrow))
            {
                forca = 0;
                subindo = false;
                StartCoroutine(MoverPa());
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            transform.GetComponent<AudioSource>().volume = 0.7f;
            transform.GetComponent<AudioSource>().clip = somPa;
            transform.GetComponent<AudioSource>().Play();
        }
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(forcaX, forca));
        }
    }

    IEnumerator MoverPa()
    {
        while (subindo)
        {
            yield return new WaitForSeconds(1/60f);
            if(ehEsquerda)
            {
                Vector3 rotacaoEuler = transform.localRotation.eulerAngles;
                float novoZ = rotacaoEuler.z + velocidade;
                if(novoZ < 0) novoZ += 360;
                else if(novoZ > 360) novoZ -= 360;
                if((rotacaoEuler.z == limiteMax) || (forca >= 626))
                {
                    forca = 0f;
                    forcaX = 0f;
                    yield break;
                }
                if ((novoZ >= 350) || (novoZ <= 40))
                {
                    transform.localRotation = Quaternion.Euler(new Vector3(rotacaoEuler.x, rotacaoEuler.y, novoZ));
                    forca = 625f;
                    forcaX = 50f;
                }
                else
                {
                    novoZ = limiteMax;
                    transform.localRotation = Quaternion.Euler(new Vector3(rotacaoEuler.x, rotacaoEuler.y, novoZ));
                    forca = 626f;
                    forcaX = 50f;
                }
            }
            else
            {
                Vector3 rotacaoEuler = transform.localRotation.eulerAngles;
                float novoZ = rotacaoEuler.z - velocidade;
                if(novoZ < 0) novoZ += 360;
                else if(novoZ > 360) novoZ -= 360;
                if((rotacaoEuler.z == limiteMax) || (forca >= 626))
                {
                    forca = 0f;
                    forcaX = 0f;
                    yield break;
                }
                if ((novoZ >= 320) || (novoZ <= 10))
                {
                    transform.localRotation = Quaternion.Euler(new Vector3(rotacaoEuler.x, rotacaoEuler.y, novoZ));
                    forca = 625f;
                    forcaX = -50f;
                }
                else
                {
                    novoZ = limiteMax;
                    transform.localRotation = Quaternion.Euler(new Vector3(rotacaoEuler.x, rotacaoEuler.y, novoZ));
                    forca = 626f;
                    forcaX = -50f;
                }
            }
        }
        while (!subindo)
        {
            yield return new WaitForSeconds(1/60f);
            if(ehEsquerda)
            {
                Vector3 rotacaoEuler = transform.localRotation.eulerAngles;
                float novoZ = rotacaoEuler.z - velocidade;
                if(novoZ < 0) novoZ += 360;
                else if(novoZ > 360) novoZ -= 360;
                if ((novoZ >= 350) || (novoZ <= 40))
                {
                    transform.localRotation = Quaternion.Euler(new Vector3(rotacaoEuler.x, rotacaoEuler.y, novoZ));
                }
                else
                {
                    novoZ = limiteMin;
                    transform.localRotation = Quaternion.Euler(new Vector3(rotacaoEuler.x, rotacaoEuler.y, novoZ));
                    yield break;
                }
            }
            else
            {
                Vector3 rotacaoEuler = transform.localRotation.eulerAngles;
                float novoZ = rotacaoEuler.z + velocidade;
                if(novoZ < 0) novoZ += 360;
                else if(novoZ > 360) novoZ -= 360;
                if ((novoZ >= 320) || (novoZ <= 10))
                {
                    transform.localRotation = Quaternion.Euler(new Vector3(rotacaoEuler.x, rotacaoEuler.y, novoZ));
                }
                else
                {
                    novoZ = limiteMin;
                    transform.localRotation = Quaternion.Euler(new Vector3(rotacaoEuler.x, rotacaoEuler.y, novoZ));
                    yield break;
                }
            }
        }
        yield return null;
    }
}
