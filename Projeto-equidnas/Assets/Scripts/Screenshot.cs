using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screenshot : MonoBehaviour
{    
    public void TakeScreenshot()
    {
        ScreenCapture.CaptureScreenshot("Sua_Equidna_" +  System.DateTime.Now.ToString("dd-MM-yy (HH-mm-ss)") + ".png");
        Debug.Log("foto tirada");
    }
}
