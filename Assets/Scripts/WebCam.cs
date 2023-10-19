using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ZXing;

public class WebCam : MonoBehaviour
{   
    WebCamTexture webCam;
    [SerializeField] private RawImage display;
    [SerializeField] private AspectRatioFitter aspectRatioFitter;
    Result result;
    string[] data;

    private UIMainmenu uIMainmenu;

    private void Start()
    {
        ShowWebCam();
        uIMainmenu = (UIMainmenu)UIManager.Ins.dicUI[typeof(UIMainmenu)];    
    }
    private void Update()
    {
        Scan();
    }

    private void Scan()
    {
        if (webCam != null)
        {
            result = QRDecode(webCam);
            if (result != null)
            {
                data = QRValue(result);
                uIMainmenu.fillInputField(data);
                BackMainmenu();
                return;
            }
        }
    }

    private void BackMainmenu()
    {
        AppManage.Ins.Mainmenu();
    }

    private void ShowWebCam()
    {
        if (!Application.HasUserAuthorization(UserAuthorization.WebCam))
        {
            Application.RequestUserAuthorization(UserAuthorization.WebCam);
        }
        else
        {
            WebCamDevice[] webCamDevices = WebCamTexture.devices;

            if (webCamDevices.Length > 0)
            {
                webCam = new WebCamTexture(webCamDevices[0].name);
                aspectRatioFitter.aspectRatio = webCam.width / webCam.height;
                webCam.Play();
                display.texture = webCam;
            }
        }
    }

    private Result QRDecode(WebCamTexture webCam)
    {
        BarcodeReader barcodeReader = new BarcodeReader();
        Color32[] color32s = new Color32[webCam.width * webCam.height];
        webCam.GetPixels32(color32s);
        return barcodeReader.Decode(color32s, webCam.width, webCam.height);
    }

    private string[] QRValue(Result result)
    {
        string[] arrStr = result.Text.Split(',');
        return arrStr;
    }
}
