using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CriarNotaMusicalEfeito : MonoBehaviour
{
    public GameObject nota;
    public GameObject objetoPai;

    public void CriarNotaMusical()
    {
        GameObject a = Instantiate(nota, transform.position, Quaternion.identity);
        a.transform.SetParent(objetoPai.transform);
        a.transform.localPosition = transform.localPosition;
        a.transform.localScale = new Vector3(1f, 1f, 1f);
        transform.GetComponent<AudioSource>().Play();
    }
}
