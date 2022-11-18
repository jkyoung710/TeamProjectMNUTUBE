using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameoverText;
    public GameObject gameclearText;
    public Text timeText;
    public Text recordText;

    private float surviveTime;
    private bool isGameover;
    private bool isGameClear;
    
    void Start()
    {

        surviveTime = 0;
        isGameover = false;

    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("Sub");
            }

        if (!isGameover)
        {
            surviveTime += Time.deltaTime;
            timeText.text = "Time: " + (int)surviveTime;
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("Sub");
            }
        }

        if (!isGameClear)
        {
            surviveTime += Time.deltaTime;
            timeText.text = "Time: " + (int)surviveTime;
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("Sub");
            }
        }

    }

    public void EndGame()
    {
        isGameover = true;
        gameoverText.SetActive(true);

        float bestTime = PlayerPrefs.GetFloat("BestTime");

        if (surviveTime > bestTime)
        {
            bestTime = surviveTime;

            PlayerPrefs.SetFloat("BestTime", bestTime);
        }

        recordText.text = "Best Time: " + (int)bestTime;

    }

    public void ClearGame()
    {
        isGameClear = true;
        gameclearText.SetActive(true);

    }
}
