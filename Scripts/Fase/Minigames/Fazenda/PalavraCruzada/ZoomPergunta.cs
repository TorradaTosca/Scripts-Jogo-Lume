using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZoomPergunta : MonoBehaviour
{
    public Text textoPergunta;

    private void OnMouseEnter()
    {
        transform.localScale = new Vector3(1.2f, 1.2f, 1f);
        textoPergunta.GetComponent<RectTransform>().sizeDelta = new Vector2(152f, 64f);
        textoPergunta.fontSize = 21;
        transform.GetComponent<MngMusicaFase>().TocarMusicaShot();
    }

    private void OnMouseExit()
    {
        transform.localScale = new Vector3(1f, 1f, 1f);
        textoPergunta.GetComponent<RectTransform>().sizeDelta = new Vector2(122.2f, 54.4f);
        textoPergunta.fontSize = 18;
    }
}
