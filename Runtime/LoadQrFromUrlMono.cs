using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;

public class LoadQrFromUrlMono : MonoBehaviour
{


    public int m_size = 256;
    public string m_textProvideToUrl="Hello World";
    public string m_serverUri = "https://api.qrserver.com/v1/create-qr-code/?size={1}x{1}&data={0}";

    public string m_lastCalledUrl;
    public Texture2D m_lastDownloadedQR;

    public UnityEvent<Texture2D> m_onDownloadedQR;


    [ContextMenu("Generate QR")]
    public void GenerateFromInspectorQR()
    {
        GenerateQR(m_textProvideToUrl, m_size);
    }
    public void GenerateQR(string text, int size = 256)
    {
        m_lastCalledUrl = string.Format(m_serverUri, text, size);
        StartCoroutine(DownloadQR(m_lastCalledUrl));


    }

    [ContextMenu("Open URL")]
    public void OpenUrlOfQR() {
        m_lastCalledUrl = string.Format(m_serverUri, m_textProvideToUrl, m_size);
        Application.OpenURL(m_lastCalledUrl);
    }

    private IEnumerator DownloadQR(string url)
    {
        using (UnityWebRequest request = UnityWebRequestTexture.GetTexture(url))
        {
            yield return request.SendWebRequest();

            if (request.result != UnityWebRequest.Result.Success)
            {
                m_lastDownloadedQR = null;
            }
            else
            {
                m_lastDownloadedQR = ((DownloadHandlerTexture)request.downloadHandler).texture;
            }
            m_onDownloadedQR.Invoke(m_lastDownloadedQR);
        }
    }
}
