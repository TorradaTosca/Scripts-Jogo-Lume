using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using SimpleFileBrowser;
public class EscolherImagem : MonoBehaviour
{
    public GameObject fundoEscuro;
    public GameObject placaErro;
    public GameObject placaSucesso;
    public RawImage imagemPreview;
    public RawImage imagemPreviewGrande;
    public Text[] textosSemImagem;
    string pathFile;
    string imagem64 = null;
    Texture2D textura = null;

    void Start()
    {
        FileBrowser.SetFilters(true, new FileBrowser.Filter( "Imagens", ".jpg", ".png" ));
        FileBrowser.SetDefaultFilter(".jpg");
        FileBrowser.SetExcludedExtensions(".lnk", ".tmp", ".zip", ".rar", ".exe");
        FileBrowser.AddQuickLink("Área de trabalho", System.Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop), null);
    }
    public void PesquisarArquivo()
    {
        StartCoroutine(ShowLoadDialogCoroutine());
    }
    IEnumerator ShowLoadDialogCoroutine()
    {
        fundoEscuro.SetActive(true);
        yield return FileBrowser.WaitForLoadDialog(false, false, null, "Carregar arquivo", "Carregar arquivo");
        if(FileBrowser.Success)
        {
            pathFile = FileBrowser.Result[0];
            try
            {
                var fileContent = FileBrowserHelpers.ReadBytesFromFile(FileBrowser.Result[0]);
                imagem64 = System.Convert.ToBase64String(fileContent);
                WWW www = new WWW("file:///" + pathFile);
                imagemPreview.texture = www.texture;
                imagemPreviewGrande.texture = www.texture;
                imagemPreview.gameObject.SetActive(true);
                imagemPreviewGrande.gameObject.SetActive(true);
                foreach(Text texto in textosSemImagem)
                {
                    texto.gameObject.SetActive(false);
                }
                placaSucesso.SetActive(true);
                fundoEscuro.SetActive(false);
            }
            catch(System.Exception ex)
            {
                placaErro.SetActive(true);
                fundoEscuro.SetActive(false);
                Debug.Log(ex);
            }
        }
        else
        {
            placaErro.SetActive(true);
            fundoEscuro.SetActive(false);
        }
    }
    public string GetImagem64()
    {
        return imagem64;
    }
}
