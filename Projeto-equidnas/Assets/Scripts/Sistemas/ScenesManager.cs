using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ScenesManager : MonoBehaviour
{
    void Start()
    {
       AudioManager.instance.StopAllSounds();
       if(SceneManager.GetActiveScene().name == "WardrobeFunction")
        {
           StartCoroutine(AudioManager.instance.PlayLevelSounds());
        }
       else if(SceneManager.GetActiveScene().name == "Runner")
        {
            AudioManager.instance.Play("vestir_loop");
        }
    }
    public void GoToScene(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Saiu");
    }
}
