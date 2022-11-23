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
    public GameObject char_Spin;
    public GameObject char_Refrigerator;
    public GameObject closeUI;
    public GameObject option;
    public GameObject exit;

    public void ButtonEvent(string value)
    {
        switch (value)
        {
            case "Start":
                EasyUI();
                NormalUI();
                HardUI();
                closeUI.SetActive(true);
                option.SetActive(false);
                break;
            case "Easy":
                char_Spin.SetActive(true);
                char_Refrigerator.SetActive(true);
                break;
            case "Normal":
                char_Spin.SetActive(true);
                char_Refrigerator.SetActive(true);
                break;
            case "Hard":
                char_Spin.SetActive(true);
                char_Refrigerator.SetActive(true);
                break;
            case "Select":
                SceneManager.LoadScene("Main");
                break;
            case "Close":
                CloseUI();
                break;
            case "Option":
                exit.SetActive(true);
                gameStartUI.SetActive(false);
                closeUI.SetActive(true);
                break;
            case "Exit":
                Application.Quit();
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

    private void CloseUI()
    {
        char_Spin.SetActive(false);
        char_Refrigerator.SetActive(false);
        easyUI.SetActive(false);
        normalUI.SetActive(false);
        hardUI.SetActive(false);
        exit.SetActive(false);
        gameStartUI.SetActive(true);
        option.SetActive(true);
    }

}
