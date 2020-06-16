using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;

public class SalvarProgresso : MonoBehaviour
{
    int _fasesDesbloqueadas;
    int _eventosFazenda;
    int _eventosFloresta;
    int _eventosRio;
    public int FasesDesbloqueadas {get{return _fasesDesbloqueadas;}}
    public int EventosFazenda {get{return _eventosFazenda;}}
    public int EventosFloresta {get{return _eventosFloresta;}}
    public int EventosRio {get{return _eventosRio;}}

    void Start()
    {
        _fasesDesbloqueadas = 1;
        DontDestroyOnLoad(this.gameObject);
        CarregarJogo();
    }

    void Update()
    {
        /*if(Input.GetKey(KeyCode.LeftShift))
        {
            if(Input.GetKeyDown(KeyCode.S))
            {
                Debug.Log(_fasesDesbloqueadas.ToString() + "|" + _eventosFazenda.ToString() + "|" + _eventosFloresta.ToString() + "|" + _eventosRio);
                _fasesDesbloqueadas = 7;
                _eventosFazenda = 5;
                _eventosFloresta = 5;
                _eventosRio = 4;
                SalvarJogo();
            }
            else if(Input.GetKeyDown(KeyCode.L))
            {
                CarregarJogo();
                Debug.Log(_fasesDesbloqueadas.ToString() + "|" + _eventosFazenda.ToString() + "|" + _eventosFloresta.ToString() + "|" + _eventosRio);
            }
            else if(Input.GetKeyDown(KeyCode.R))
            {
                _fasesDesbloqueadas = 1;
                _eventosFazenda = 0;
                _eventosFloresta = 0;
                _eventosRio = 0;
                Debug.Log(_fasesDesbloqueadas.ToString() + "|" + _eventosFazenda.ToString() + "|" + _eventosFloresta.ToString() + "|" + _eventosRio);
                SalvarJogo();
            }
        }*/
    }

    public void SalvarJogo()
    {
        string diretorio = Application.persistentDataPath + @"/" + "Progresso" + @"/" + "SaveData.sav";
        if(!Directory.Exists(Application.persistentDataPath + @"/" + "Progresso"))
            Directory.CreateDirectory(Application.persistentDataPath + @"/" + "Progresso");
        using (FileStream file = File.Create(diretorio))
        {
            BinaryFormatter bf = new BinaryFormatter();
            GameData gm = new GameData();
            gm.fasesDesbloqueadas = _fasesDesbloqueadas;
            gm.eventosFazenda = _eventosFazenda;
            gm.eventosFloresta = _eventosFloresta;
            gm.eventosRio = _eventosRio;
            bf.Serialize(file, gm);
        }
    }
    void CarregarJogo()
    {
        string diretorio = Application.persistentDataPath + @"/" + "Progresso" + @"/" + "SaveData.sav";
        if(File.Exists(diretorio))
        {
            using (FileStream file = File.Open(diretorio, FileMode.Open))
            {
                BinaryFormatter bf = new BinaryFormatter();
                GameData gm = (GameData) bf.Deserialize(file);
                _fasesDesbloqueadas = gm.fasesDesbloqueadas;
                _eventosFazenda = gm.eventosFazenda;
                _eventosFloresta = gm.eventosFloresta;
                _eventosRio = gm.eventosRio;
            }
        }
        else
        {
            Debug.Log("Erro ao carregar progresso: Arquivo não existe");
        }
    }
    public void AvancarProgFases()
    {
        _fasesDesbloqueadas += 2;
    }
    public void AvancarEventoFazenda()
    {
        _eventosFazenda++;
    }
    public void AvancarEventoFloresta()
    {
        _eventosFloresta++;
    }
    public void AvancarEventoRio()
    {
        _eventosRio++;
    }
}

[Serializable]
public class GameData
{
    public int fasesDesbloqueadas;
    public int eventosFazenda;
    public int eventosFloresta;
    public int eventosRio;
}