using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHub : MonoBehaviour
{
    [SerializeField]
    public GameObject lumeHub;
    [SerializeField]
    float velocidade = 0f;
    [SerializeField]
    public Vector2 posOffset;
    [SerializeField]
    float XReferencial = 0f;
    [SerializeField]
    float chao = 0f;

    [SerializeField]
    float teto = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 posInicial = transform.position;
        Vector3 posFinal = lumeHub.transform.position;
        posFinal.x += posOffset.x;
        posFinal.y += posOffset.y; // + Mathf.Clamp(adicionalMouse, -1.5f, 1.5f);
        posFinal.z = -100f;

        if (Input.mousePosition.y >= Screen.height/2)
        {
            posFinal.y += Mathf.Clamp((Input.mousePosition.y - Screen.height/2)/100f, 0f, 1.5f);
        }
        else
        {
            posFinal.y += Mathf.Clamp(((Screen.height/2 - Input.mousePosition.y)/100f)*-1, -1.5f, 0f);
        }

        Vector3 posSuave = transform.position = Vector3.Lerp(posInicial, posFinal, velocidade * Time.deltaTime);
        Vector3 posDefinitiva = new Vector3(XReferencial, Mathf.Clamp(posSuave.y, chao, teto), -100f);
        transform.position = posDefinitiva;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(new Vector2(0f, chao), new Vector2(0f, teto));
    }
}
