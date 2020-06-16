using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ExportadorLogs : MonoBehaviour
{
    ContainerSeteErros containerSE;
    ContainerPerseguicaoSaci containerPS;
    ContainerPalavraCruzada containerPC;
    ContainerBlocosDeFeno containerBF;
    ContainerAssobios containerA;
    ContainerPegadasEstranhas containerPE;
    ContainerAcerteOFogo containerAOF;
    ContainerForca containerF;
    ContainerEscondeEsconde containerEE;
    ContainerGiraDisco containerGD;
    ContainerPinball containerP;
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        containerSE = new ContainerSeteErros();
        containerPS = new ContainerPerseguicaoSaci();
        containerPC = new ContainerPalavraCruzada();
        containerBF = new ContainerBlocosDeFeno();
        containerA = new ContainerAssobios();
        containerPE = new ContainerPegadasEstranhas();
        containerAOF = new ContainerAcerteOFogo();
        containerF = new ContainerForca();
        containerEE = new ContainerEscondeEsconde();
        containerGD = new ContainerGiraDisco();
        containerP = new ContainerPinball();
    }
    public void ExportarArquivoLogs()
    {
        LogInteracao log = CarregarLogs();
        string logJson = JsonUtility.ToJson(log, true);
        string diretorio = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop) + @"/" + "ArquivosLume" + @"/" + "LogInteração.json";
    
        if(!Directory.Exists(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop) + @"/" + "ArquivosLume"))
            Directory.CreateDirectory(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop) + @"/" + "ArquivosLume");

        using (StreamWriter writer = new StreamWriter(diretorio, false))
        {
            writer.Write(logJson);
        }
        Debug.Log(logJson);
    }

    LogInteracao CarregarLogs()
    {
        LogInteracao logInteracao = new LogInteracao();
        logInteracao.containerSeteErros = containerSE;
        logInteracao.containerPerseguicaoSaci = containerPS;
        logInteracao.containerPalavraCruzada = containerPC;
        logInteracao.containerBlocosDeFeno = containerBF;
        logInteracao.containerAssobios = containerA;
        logInteracao.containerPegadasEstranhas = containerPE;
        logInteracao.containerAcerteOFogo = containerAOF;
        logInteracao.containerForca = containerF;
        logInteracao.containerEscondeEsconde = containerEE;
        logInteracao.containerGiraDisco = containerGD;
        logInteracao.containerPinball = containerP;
        return logInteracao;
    }

    public void ImportarLoggerSeteErros()
    {
        GameObject loggerSE = GameObject.FindWithTag("LoggerSeteErros");
        containerSE.SetListaPartidas(loggerSE.GetComponent<LoggerSeteErros>().GetListaContainer());
        loggerSE.GetComponent<LoggerSeteErros>().LimparLista();
    }
    public void ImportarLoggerPerseguicaoSaci()
    {
        GameObject loggerPS = GameObject.FindWithTag("LoggerPerseguicaoSaci");
        containerPS.SetListaPartidas(loggerPS.GetComponent<LoggerPerseguicaoSaci>().GetListaContainer());
        loggerPS.GetComponent<LoggerPerseguicaoSaci>().LimparLista();
    }
    public void ImportarLoggerPalavraCruzada()
    {
        GameObject loggerPC = GameObject.FindWithTag("LoggerPalavraCruzada");
        containerPC.SetListaPartidas(loggerPC.GetComponent<LoggerPalavraCruzada>().GetListaContainer());
        loggerPC.GetComponent<LoggerPalavraCruzada>().LimparLista();
    }
    public void ImportarLoggerBlocosDeFeno()
    {
        GameObject loggerBF = GameObject.FindWithTag("LoggerBlocosDeFeno");
        containerBF.SetListaPartidas(loggerBF.GetComponent<LoggerBlocosDeFeno>().GetListaContainer());
        loggerBF.GetComponent<LoggerBlocosDeFeno>().LimparLista();
    }
    public void ImportarLoggerAssobios()
    {
        GameObject loggerA = GameObject.FindWithTag("LoggerAssobios");
        containerA.SetListaPartidas(loggerA.GetComponent<LoggerAssobios>().GetListaContainer());
        loggerA.GetComponent<LoggerAssobios>().LimparLista();
    }
    public void ImportarLoggerPegadasEstranhas()
    {
        GameObject loggerPE = GameObject.FindWithTag("LoggerPegadasEstranhas");
        containerPE.SetListaPartidas(loggerPE.GetComponent<LoggerPegadasEstranhas>().GetListaContainer());
        loggerPE.GetComponent<LoggerPegadasEstranhas>().LimparLista();
    }
    public void ImportarLoggerAcerteOFogo()
    {
        GameObject loggerAOF = GameObject.FindWithTag("LoggerWhack");
        containerAOF.SetListaPartidas(loggerAOF.GetComponent<LoggerWhackAMole>().GetListaContainer());
        loggerAOF.GetComponent<LoggerWhackAMole>().LimparLista();
    }
    public void ImportarLoggerForca()
    {
        GameObject loggerF = GameObject.FindWithTag("LoggerForca");
        containerF.SetListaPartidas(loggerF.GetComponent<LoggerForca>().GetListaContainer());
        loggerF.GetComponent<LoggerForca>().LimparLista();
    }
    public void ImportarLoggerEscondeEsconde()
    {
        GameObject loggerEE = GameObject.FindWithTag("LoggerEscondeEsconde");
        containerEE.SetListaPartidas(loggerEE.GetComponent<LoggerEscondeEsconde>().GetListaContainer());
        loggerEE.GetComponent<LoggerEscondeEsconde>().LimparLista();
    }
    public void ImportarLoggerGiraDisco()
    {
        GameObject loggerGD = GameObject.FindWithTag("LoggerGiraDisco");
        containerGD.SetListaPartidas(loggerGD.GetComponent<LoggerGiraDisco>().GetListaContainer());
        loggerGD.GetComponent<LoggerGiraDisco>().LimparLista();
    }
    public void ImportarLoggerPinball()
    {
        GameObject loggerP = GameObject.FindWithTag("LoggerPinball");
        containerP.SetListaPartidas(loggerP.GetComponent<LoggerPinball>().GetListaContainer());
        loggerP.GetComponent<LoggerPinball>().LimparLista();
    }
}

[Serializable]
class LogInteracao
{
    public ContainerSeteErros containerSeteErros;
    public ContainerPerseguicaoSaci containerPerseguicaoSaci;
    public ContainerPalavraCruzada containerPalavraCruzada;
    public ContainerBlocosDeFeno containerBlocosDeFeno;
    public ContainerAssobios containerAssobios;
    public ContainerPegadasEstranhas containerPegadasEstranhas;
    public ContainerAcerteOFogo containerAcerteOFogo;
    public ContainerForca containerForca;
    public ContainerEscondeEsconde containerEscondeEsconde;
    public ContainerGiraDisco containerGiraDisco;
    public ContainerPinball containerPinball;
}

[Serializable]
public class ContainerSeteErros
{
    int numeroPartida = 1;
    public List<PartidaSeteErros> listaPartidas;

    public ContainerSeteErros()
    {
        listaPartidas = new List<PartidaSeteErros>();
    }

    public void SetListaPartidas(List<PartidaSeteErros> listaPartidas)
    {
        foreach(PartidaSeteErros pse in listaPartidas)
        {
            pse.numeroPartida = this.numeroPartida;
            this.listaPartidas.Add(pse);
            this.numeroPartida++;
        }
    }
}

[Serializable]
public class ContainerPerseguicaoSaci
{
    int numeroPartida = 1;
    public List<PartidaPerseguicaoSaci> listaPartidas;

    public ContainerPerseguicaoSaci()
    {
        listaPartidas = new List<PartidaPerseguicaoSaci>();
    }

    public void SetListaPartidas(List<PartidaPerseguicaoSaci> listaPartidas)
    {
        foreach(PartidaPerseguicaoSaci pps in listaPartidas)
        {
            pps.numeroPartida = this.numeroPartida;
            this.listaPartidas.Add(pps);
            this.numeroPartida++;
        }
    }
}

[Serializable]
public class ContainerPalavraCruzada
{
    int numeroPartida = 1;
    public List<PartidaPalavraCruzada> listaPartidas;

    public ContainerPalavraCruzada()
    {
        listaPartidas = new List<PartidaPalavraCruzada>();
    }

    public void SetListaPartidas(List<PartidaPalavraCruzada> listaPartidas)
    {
        foreach(PartidaPalavraCruzada pps in listaPartidas)
        {
            pps.numeroPartida = this.numeroPartida;
            this.listaPartidas.Add(pps);
            this.numeroPartida++;
        }
    }
}

[Serializable]
public class ContainerBlocosDeFeno
{
    int numeroPartida = 1;
    public List<PartidaBlocosDeFeno> listaPartidas;

    public ContainerBlocosDeFeno()
    {
        listaPartidas = new List<PartidaBlocosDeFeno>();
    }

    public void SetListaPartidas(List<PartidaBlocosDeFeno> listaPartidas)
    {
        foreach(PartidaBlocosDeFeno pse in listaPartidas)
        {
            pse.numeroPartida = this.numeroPartida;
            this.listaPartidas.Add(pse);
            this.numeroPartida++;
        }
    }
}

[Serializable]
public class ContainerAssobios
{
    int numeroPartida = 1;
    public List<PartidaAssobios> listaPartidas;

    public ContainerAssobios()
    {
        listaPartidas = new List<PartidaAssobios>();
    }

    public void SetListaPartidas(List<PartidaAssobios> listaPartidas)
    {
        foreach(PartidaAssobios pse in listaPartidas)
        {
            pse.numeroPartida = this.numeroPartida;
            this.listaPartidas.Add(pse);
            this.numeroPartida++;
        }
    }
}

[Serializable]
public class ContainerPegadasEstranhas
{
    int numeroPartida = 1;
    public int vidasPerdidas = 0;
    public List<PartidaPegadasEstranhas> listaPartidas;

    public ContainerPegadasEstranhas()
    {
        listaPartidas = new List<PartidaPegadasEstranhas>();
    }

    public void SetListaPartidas(List<PartidaPegadasEstranhas> listaPartidas)
    {
        foreach(PartidaPegadasEstranhas pse in listaPartidas)
        {
            pse.numeroPartida = this.numeroPartida;
            this.vidasPerdidas += pse.vidasPerdidas;
            this.listaPartidas.Add(pse);
            this.numeroPartida++;
        }
    }
}

[Serializable]
public class ContainerAcerteOFogo
{
    int numeroPartida = 1;
    public int vidasPerdidas = 0;
    public List<PartidaAcerteOFogo> listaPartidas;

    public ContainerAcerteOFogo()
    {
        listaPartidas = new List<PartidaAcerteOFogo>();
    }

    public void SetListaPartidas(List<PartidaAcerteOFogo> listaPartidas)
    {
        foreach(PartidaAcerteOFogo pse in listaPartidas)
        {
            pse.numeroPartida = this.numeroPartida;
            this.vidasPerdidas += pse.vidasPerdidas;
            this.listaPartidas.Add(pse);
            this.numeroPartida++;
        }
    }
}

[Serializable]
public class ContainerForca
{
    int numeroPartida = 1;
    public List<PartidaForca> listaPartidas;

    public ContainerForca()
    {
        listaPartidas = new List<PartidaForca>();
    }

    public void SetListaPartidas(List<PartidaForca> listaPartidas)
    {
        foreach(PartidaForca pse in listaPartidas)
        {
            pse.numeroPartida = this.numeroPartida;
            this.listaPartidas.Add(pse);
            this.numeroPartida++;
        }
    }
}

[Serializable]
public class ContainerEscondeEsconde
{
    int numeroPartida = 1;
    public List<PartidaEscondeEsconde> listaPartidas;

    public ContainerEscondeEsconde()
    {
        listaPartidas = new List<PartidaEscondeEsconde>();
    }

    public void SetListaPartidas(List<PartidaEscondeEsconde> listaPartidas)
    {
        foreach(PartidaEscondeEsconde pse in listaPartidas)
        {
            pse.numeroPartida = this.numeroPartida;
            this.listaPartidas.Add(pse);
            this.numeroPartida++;
        }
    }
}

[Serializable]
public class ContainerGiraDisco
{
    int numeroPartida = 1;
    public List<PartidaGiraDisco> listaPartidas;

    public ContainerGiraDisco()
    {
        listaPartidas = new List<PartidaGiraDisco>();
    }

    public void SetListaPartidas(List<PartidaGiraDisco> listaPartidas)
    {
        foreach(PartidaGiraDisco pse in listaPartidas)
        {
            pse.numeroPartida = this.numeroPartida;
            this.listaPartidas.Add(pse);
            this.numeroPartida++;
        }
    }
}

[Serializable]
public class ContainerPinball
{
    int numeroPartida = 1;
    public List<PartidaPinball> listaPartidas;

    public ContainerPinball()
    {
        listaPartidas = new List<PartidaPinball>();
    }

    public void SetListaPartidas(List<PartidaPinball> listaPartidas)
    {
        foreach(PartidaPinball pse in listaPartidas)
        {
            pse.numeroPartida = this.numeroPartida;
            this.listaPartidas.Add(pse);
            this.numeroPartida++;
        }
    }
}