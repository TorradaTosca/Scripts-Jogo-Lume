using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LumeRunner : MonoBehaviour
{
    public GameObject loggerPerseguicao;
    public GameObject[] pontos;
    public int lane;
    public GameObject gerenciadorObstaculos;
    private int direcao = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.RightArrow)) && (lane < pontos.Length - 1))
        {
            direcao = 1;
            //Som de movimento do lume no runner
        }
        else if ((Input.GetKeyDown(KeyCode.LeftArrow)) && (lane > 0))
        {
            direcao = -1;
            //Som de movimento do lume no runner
        }

        if(direcao != 0)
        {
            transform.Translate(direcao * 10f * Time.deltaTime, 0f, 0f); //antes 100
            //Se tiver som de voo entre lanes coloca aqui
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstaculo"))
        {
            if (other.GetComponent<ObstaculoRunner>().GetSaci())
            {
                gerenciadorObstaculos.GetComponent<GerenciadorRunner>().AtivarQuiz();
                Debug.Log("quiz time!");
            }
            else
            {
                gerenciadorObstaculos.GetComponent<GerenciadorRunner>().BateuNoObstaculo();
                loggerPerseguicao.GetComponent<LoggerPerseguicaoSaci>().BateuEmObstaculo();
                other.GetComponent<MngMusicaFase>().TocarMusicaShot();
            }
        }
    }

    public int getDirecao()
    {
        return direcao;
    }
    public void setDirecao(int dir)
    {
        this.direcao = dir;
    }

    public int GetLane()
    {
        return lane;
    }

    public void SetLane(int lane)
    {
        this.lane = lane;

        if (this.lane > pontos.Length - 1)
        {
            this.lane = pontos.Length - 1;
        }

        if (this.lane < 0) {
            this.lane = 0;
        }
    }
}
