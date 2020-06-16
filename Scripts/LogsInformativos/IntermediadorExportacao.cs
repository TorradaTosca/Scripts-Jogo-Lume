using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntermediadorExportacao : MonoBehaviour
{
    public GameObject exportador;
    void Start()
    {
        exportador = GameObject.FindWithTag("ExportadorLogs");
    }
    public void Exportar()
    {
        exportador.GetComponent<ExportadorLogs>().ExportarArquivoLogs();
    }
    public void ImportarLogSeteErros()
    {
        exportador.GetComponent<ExportadorLogs>().ImportarLoggerSeteErros();
    }
    public void ImportarLogPerseguicaoSaci()
    {
        exportador.GetComponent<ExportadorLogs>().ImportarLoggerPerseguicaoSaci();
    }
    public void ImportarLogPalavraCruzada()
    {
        exportador.GetComponent<ExportadorLogs>().ImportarLoggerPalavraCruzada();
    }
    public void ImportarLogBlocosDeFeno()
    {
        exportador.GetComponent<ExportadorLogs>().ImportarLoggerBlocosDeFeno();
    }
    public void ImportarLogAssobios()
    {
        exportador.GetComponent<ExportadorLogs>().ImportarLoggerAssobios();
    }
    public void ImportarLogPegadasEstranhas()
    {
        exportador.GetComponent<ExportadorLogs>().ImportarLoggerPegadasEstranhas();
    }
    public void ImportarLogAcerteOFogo()
    {
        exportador.GetComponent<ExportadorLogs>().ImportarLoggerAcerteOFogo();
    }
    public void ImportarLogForca()
    {
        exportador.GetComponent<ExportadorLogs>().ImportarLoggerForca();
    }
    public void ImportarLogEscondeEsconde()
    {
        exportador.GetComponent<ExportadorLogs>().ImportarLoggerEscondeEsconde();
    }
    public void ImportarLogGiraDisco()
    {
        exportador.GetComponent<ExportadorLogs>().ImportarLoggerGiraDisco();
    }
    public void ImportarLogPinball()
    {
        exportador.GetComponent<ExportadorLogs>().ImportarLoggerPinball();
    }
}
