using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;
 
 
public class TakeScreenshot : MonoBehaviour {
 
    public GameObject ui;
    
    // Use this for initialization
    public void Screenshot () {
        StartCoroutine(UploadPNG());
        //Debug.log (encodedText);
    }
 
    IEnumerator UploadPNG() {
        //Gustavo: desabilita a UI
        ui.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        
        // We should only read the screen after all rendering is complete
        yield return new WaitForEndOfFrame();
 
        // Create a texture the size of the screen, RGB24 format
        int width = Screen.width;
        int height = Screen.height;
        var tex = new Texture2D( width, height, TextureFormat.RGB24, false );
 
        // Read screen contents into the texture
        tex.ReadPixels( new Rect(0, 0, width, height), 0, 0 );
        tex.Apply();
 
        // Encode texture into PNG
        byte[] bytes = tex.EncodeToPNG();
        Destroy( tex );
 
        //string ToBase64String byte[]
        string encodedText = System.Convert.ToBase64String (bytes);
   
        var image_url = "data:image/png;base64," + encodedText;
 
        Debug.Log (image_url);
 
        #if !UNITY_EDITOR
        openWindow(image_url);
        #endif

        //Gustavo: habilita a UI
        yield return new WaitForSeconds(0.1f);
        ui.SetActive(true);
    }
 
    [DllImport("__Internal")]
    private static extern void openWindow(string url);
 
}