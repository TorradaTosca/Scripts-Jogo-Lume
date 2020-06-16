using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AutoDestruicao : MonoBehaviour
{
    public Sprite[] spritesNotasMusicais;
    public float tempoSegundos;
    public Image imagem;
    // Start is called before the first frame update
    void Start()
    {
        tempoSegundos = tempoSegundos * 60;

        imagem.sprite = spritesNotasMusicais[Random.Range(0, spritesNotasMusicais.Length)];
    }

    // Update is called once per frame
    void Update()
    {
        if (tempoSegundos <= 0)
        {
            Destroy(gameObject);
        }
        else
        {
            transform.Translate(0f, 3.5f * Time.deltaTime, 0f);
            tempoSegundos--;
        }
    }
}
