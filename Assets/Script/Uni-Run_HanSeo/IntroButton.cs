using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroButton : MonoBehaviour
{
    public GameObject introScene;
    public GameObject introMusic;

    public void Play()
    {
        SceneManager.LoadScene("Sub",LoadSceneMode.Additive);
        introScene.SetActive(false);
        introMusic.SetActive(false);

    }

    public void Quit()
    {
        Application.Quit();
    }
}
