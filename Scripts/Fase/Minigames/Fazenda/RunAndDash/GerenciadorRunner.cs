using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GerenciadorRunner : MonoBehaviour
{
    public AudioClip somVitoria;
    public AudioClip somErrado;
    public AudioClip somAparicao;
    public GameObject inProg;
    public GameObject lumeRunner;
    public GameObject[] pontosLane;
    public GameObject obstaculo;

    public GameObject barrilObstaculos;
    public GameObject fundoRunner;
    public GameObject lumeBarra;
    public GameObject barraInteira;
    public GameObject quiz;
    public GameObject telaVitoria;
    public GameObject botoesIngame;
    public Text textoCountdown;

    private bool congelado = true;
    private bool iniciarMinigame = false;
    private float distancia = 0;
    private float destino = 3900; //1 minuto (segundos * 60 frames)
    private int cooldown = 0;
    private int tempoSpawn = 200;
    public MetodosGerais metodosGerais;
    private Vector3 lumeBarraPosInicial;

    void Start()
    {
        lumeBarraPosInicial = lumeBarra.transform.localPosition;
        /*StartCoroutine(AumentarDistancia());
        StartCoroutine(ContagemRegressiva(0.3f, "3"));
        StartCoroutine(ContagemRegressiva(1.3f, "2"));
        StartCoroutine(ContagemRegressiva(2.3f, "1"));
        StartCoroutine(ContagemRegressiva(3.3f, " "));*/
    }

    void Update()
    {
        if(iniciarMinigame)
        {
            StartCoroutine(AumentarDistancia());
            StartCoroutine(ContagemRegressiva(0.3f, "3"));
            StartCoroutine(ContagemRegressiva(1.3f, "2"));
            StartCoroutine(ContagemRegressiva(2.3f, "1"));
            StartCoroutine(ContagemRegressiva(3.3f, " "));
            iniciarMinigame = false;
        }

        if ((distancia <= destino) && (!congelado))
        {
            tempoSpawn = DefinirTempo();

            if ((distancia % tempoSpawn == 0) && (distancia < 3780) && (cooldown == 0) && (distancia > 0))
            {
                criarObstaculo();
                cooldown = 60;
            }

            if (distancia == destino)
            {
                Vector3 lanePos = pontosLane[1].transform.position;
                GameObject go = Instantiate(obstaculo, new Vector3(lanePos.x, lanePos.y + 10f, lanePos.z), Quaternion.Euler(0f, 0f, 0f));
                go.transform.localScale = new Vector3(0.2f, 0.2f, 1f);
                go.GetComponent<ObstaculoRunner>().SetSaci(true);
                go.GetComponent<BoxCollider>().size = new Vector3(1000f, 2.25f, 4f);
                congelado = true;
            }
        }

        if (!congelado)
        {
            float porcento = (float)distancia / destino;
            float novaPosLumeBarraX = -485f + (970f * porcento);
            lumeBarra.transform.localPosition = new Vector3(novaPosLumeBarraX, lumeBarra.transform.localPosition.y, lumeBarra.transform.localPosition.z);
        }
    }

    void criarObstaculo()
    {
        int lane = Mathf.RoundToInt(Random.Range(0f, 2f));

        switch (lane)
        {
            case 0:
                Vector3 lanePos0 = pontosLane[0].transform.position;
                GameObject go0 = Instantiate(obstaculo, new Vector3(lanePos0.x, lanePos0.y + 10f, lanePos0.z), Quaternion.Euler(0f, 0f, 0f));
                go0.transform.localScale = new Vector3(0.9f, 0.9f, 1f); //antes 80
                go0.transform.SetParent(barrilObstaculos.transform);
                break;

            case 1:
                Vector3 lanePos1 = pontosLane[1].transform.position;
                GameObject go1 = Instantiate(obstaculo, new Vector3(lanePos1.x, lanePos1.y + 10f, lanePos1.z), Quaternion.Euler(0f, 0f, 0f));
                go1.transform.localScale = new Vector3(0.9f, 0.9f, 1f);
                go1.transform.SetParent(barrilObstaculos.transform);
                break;

            case 2:
                Vector3 lanePos2 = pontosLane[2].transform.position;
                GameObject go2 = Instantiate(obstaculo, new Vector3(lanePos2.x, lanePos2.y + 10f, lanePos2.z), Quaternion.Euler(0f, 0f, 0f));
                go2.transform.localScale = new Vector3(0.9f, 0.9f, 1f);
                go2.transform.SetParent(barrilObstaculos.transform);
                break;
        }

        if (distancia > 1800)
        {
            int outraLane = Mathf.RoundToInt(Random.Range(0f, 2f));

            while (true)
            {
                if (outraLane == lane)
                {
                    outraLane = Mathf.RoundToInt(Random.Range(0f, 2f));
                }
                else
                {
                    break;
                }
            }

            switch (outraLane)
            {
                case 0:
                    Vector3 lanePos0 = pontosLane[0].transform.position;
                    GameObject go0 = Instantiate(obstaculo, new Vector3(lanePos0.x, lanePos0.y + 10f, lanePos0.z), Quaternion.Euler(0f, 0f, 0f));
                    go0.transform.localScale = new Vector3(0.9f, 0.9f, 1f); //antes 80
                    go0.transform.SetParent(barrilObstaculos.transform);
                    break;

                case 1:
                    Vector3 lanePos1 = pontosLane[1].transform.position;
                    GameObject go1 = Instantiate(obstaculo, new Vector3(lanePos1.x, lanePos1.y + 10f, lanePos1.z), Quaternion.Euler(0f, 0f, 0f));
                    go1.transform.localScale = new Vector3(0.9f, 0.9f, 1f);
                    go1.transform.SetParent(barrilObstaculos.transform);
                    break;

                case 2:
                    Vector3 lanePos2 = pontosLane[2].transform.position;
                    GameObject go2 = Instantiate(obstaculo, new Vector3(lanePos2.x, lanePos2.y + 10f, lanePos2.z), Quaternion.Euler(0f, 0f, 0f));
                    go2.transform.localScale = new Vector3(0.9f, 0.9f, 1f);
                    go2.transform.SetParent(barrilObstaculos.transform);
                    break;
            }
        }
        transform.GetComponent<AudioSource>().clip = somAparicao;
        transform.GetComponent<AudioSource>().volume = 0.75f;
        transform.GetComponent<MngMusicaFase>().TocarMusicaShot();
    }

    public void AtivarQuiz()
    {
        quiz.SetActive(true);
        congelado = true;
        fundoRunner.GetComponent<RepetidorFundo>().SetVelocidadeFundo(0f);
        lumeRunner.SetActive(false);
        barraInteira.SetActive(false);
        barrilObstaculos.SetActive(false);
        botoesIngame.SetActive(false);
    }

    public void QuizCorreto()
    {
        quiz.SetActive(false);
        telaVitoria.SetActive(true);

        if(inProg.GetComponent<IntermediadorProgresso>().RequisitarEventoFaseAtual() == 2)
                inProg.GetComponent<IntermediadorProgresso>().AumentarEventoFaseAtual();

        foreach (Transform obstaculo in barrilObstaculos.transform)
        {
            Destroy(obstaculo.gameObject);
        }
        transform.GetComponent<AudioSource>().volume = 0.6f;
        transform.GetComponent<AudioSource>().clip = somVitoria;
        transform.GetComponent<MngMusicaFase>().TocarMusicaShot();
    }

    public void QuizErrado()
    {
        distancia = 1201;
        quiz.SetActive(false);
        congelado = false;
        fundoRunner.GetComponent<RepetidorFundo>().SetVelocidadeFundo(0.36f);
        lumeRunner.SetActive(true);
        barraInteira.SetActive(true);
        barrilObstaculos.SetActive(true);
        botoesIngame.SetActive(true);

        foreach (Transform botao in botoesIngame.transform)
        {
            metodosGerais.AlternarEstadoFuncional(botao.gameObject);
        }

        foreach (Transform obstaculo in barrilObstaculos.transform)
        {
            Destroy(obstaculo.gameObject);
        }

        StartCoroutine(AumentarDistancia());
        transform.GetComponent<AudioSource>().clip = somErrado;
        transform.GetComponent<AudioSource>().volume = 0.75f;
        transform.GetComponent<MngMusicaFase>().TocarMusicaShot();
    }

    public void BateuNoObstaculo()
    {
        distancia -= 350;
        if (distancia < 2) distancia = 2;
    }

    public void ResetarMinigame()
    {
        foreach (Transform obstaculo in barrilObstaculos.transform)
        {
            Destroy(obstaculo.gameObject);
        }

        distancia = 0;
        congelado = false;
        cooldown = 0;
        lumeRunner.SetActive(true);
        barraInteira.SetActive(true);
        barrilObstaculos.SetActive(true);
        botoesIngame.SetActive(true);
        fundoRunner.GetComponent<RepetidorFundo>().SetVelocidadeFundo(0.36f);
        lumeRunner.transform.localPosition = pontosLane[1].transform.localPosition;
        lumeRunner.GetComponent<LumeRunner>().SetLane(1);
        lumeRunner.GetComponent<LumeRunner>().setDirecao(0);
        lumeBarra.transform.localPosition = lumeBarraPosInicial;
        iniciarMinigame = true;
    }

    int DefinirTempo()
    {
        int tempo = 0;
        if (distancia >= 0) tempo = 180;
        if (distancia > 780) tempo = 150;
        if (distancia > 1380) tempo = 120;
        if (distancia > 1980) tempo = 100;
        if (distancia > 2580) tempo = 80;
        if (distancia > 3180) tempo = 60;
        return tempo;
    }

    public void SetCongelado(bool congelado)
    {
        this.congelado = congelado;
    }

    public bool GetCongelado()
    {
        return congelado;
    }

    IEnumerator ContagemRegressiva(float tempoEspera, string tempoTexto)
    {
        yield return new WaitForSeconds(tempoEspera);
        textoCountdown.text = tempoTexto;
        //Som tempo da contagem regressiva
    }

    IEnumerator AumentarDistancia()
    {
        while (distancia < destino)
        {
            yield return new WaitForSeconds(1/60f);
            distancia++;
            if (cooldown > 0) cooldown--;
            yield return null;
        }
        yield return null;
    }
}
