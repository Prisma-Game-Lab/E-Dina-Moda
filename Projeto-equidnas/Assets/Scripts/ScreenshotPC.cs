using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenshotPC : MonoBehaviour
{    
    
    public GameObject ui;
    
    public void TakeScreenshot()
    {
        StartCoroutine(WaitScreenshot());
    }

    private IEnumerator WaitScreenshot()
    {
        ui.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        AudioManager.instance.Play("tira_foto");
        ScreenCapture.CaptureScreenshot("Sua_Equidna_" +  System.DateTime.Now.ToString("dd-MM-yy (HH-mm-ss)") + ".png");
        Debug.Log("foto tirada");
        yield return new WaitForSeconds(0.1f);
        ui.SetActive(true);
    }

}
