using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaculoRunner : MonoBehaviour
{
    public Sprite[] sprites;
    public Sprite saciSprite;
    private bool saci = false;
    // Start is called before the first frame update
    void Start()
    {
        int randNumb = Random.Range(0, sprites.Length);
        GetComponent<SpriteRenderer>().sprite = sprites[randNumb];
        if ((randNumb == 0) || (randNumb == 1))
        {
            transform.localScale = new Vector3(15f, 15f, 1f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (saci)
        {
            GetComponent<SpriteRenderer>().sprite = saciSprite;
            transform.localScale = new Vector3(0.2f, 0.2f, 1f);
        }

        if (transform.position.y > -20f)
        {
            transform.Translate(0f, -5.6f * Time.deltaTime, 0f); //antes 1.4
        }
        else
        {
            Destroy(transform.gameObject);
        }
    }

    public void SetSaci(bool saci)
    {
        this.saci = saci;
    }

    public bool GetSaci()
    {
        return saci;
    }
}
