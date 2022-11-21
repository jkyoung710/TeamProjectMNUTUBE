using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public GameObject gameStartUI;
    public GameObject easyUI;
    public GameObject normalUI;
    public GameObject hardUI;
    public GameObject selectUI;
    public GameObject closeUI;

    public void ButtonEvent(string value)
    {
        switch (value)
        {
            case "Start":
                EasyUI();
                NormalUI();
                HardUI();
                closeUI.SetActive(true);
                break;
            case "Easy":
                selectUI.SetActive(true);
                break;
            case "Normal":
                selectUI.SetActive(true);
                break;
            case "Hard":
                selectUI.SetActive(true);
                break;
            case "Select":
                SceneManager.LoadScene("Main");
                break;
        }
    }

    private void EasyUI()
    {
        easyUI.SetActive(true);
    }

    private void NormalUI()
    {
        normalUI.SetActive(true);
    }

    private void HardUI()
    {
        hardUI.SetActive(true);
    }

}
