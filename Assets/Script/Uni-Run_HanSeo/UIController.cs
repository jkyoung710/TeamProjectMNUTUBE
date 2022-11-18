using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{

    public GameObject menuPanel;

   public void ButtonEvent(string value)
    {
        switch (value)
        {
            case "Restart":
                SceneManager.LoadScene("Sub");
                Time.timeScale = 1f;
                break;
            case "Exit":
                Application.Quit();
                break;
            case "On":
                menuPanel.SetActive(true);
                Time.timeScale = 0f;
                break;
            case "Off":
                menuPanel.SetActive(false);
                Time.timeScale = 1f;
                break;
            case "Back":
                menuPanel.SetActive(false);
                Time.timeScale = 1f;
                SceneManager.LoadScene("Main");
                break;

        }
    }


}
