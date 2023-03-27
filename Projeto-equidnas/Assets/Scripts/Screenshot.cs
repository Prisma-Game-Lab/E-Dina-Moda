using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screenshot : MonoBehaviour
{
    public void TakeScreenshot()
    {
        ScreenCapture.CaptureScreenshot("foto.jpg");
        Debug.Log("tira foto");
    }
}
