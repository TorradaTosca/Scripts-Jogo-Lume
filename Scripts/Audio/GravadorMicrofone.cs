using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravadorMicrofone : MonoBehaviour
{
    private string microfone;
    private bool gravando = false;
    // Start is called before the first frame update
    void Start()
    {
        microfone = (Microphone.devices[0] != null) ? Microphone.devices[0] : "";
    }

    void Gravar()
    {
        if((microfone != "") && (!gravando))
        {
            Microphone.Start(microfone, false, 2400, 44100);
            gravando = true;
        }
    }

    void PararESalvar()
    {
        
    }
}
