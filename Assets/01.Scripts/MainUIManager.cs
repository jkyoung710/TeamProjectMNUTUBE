using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Main Unity scene file에 존재하는 UI 관련
public class MainUIManager : MonoBehaviour
{
    public bool isEnabledOnGUI;

    int stamina, gauge;
    int maxStamina, maxGauge;

    // 스태미너 수치에 따라 길이가 변하는 UI
    public GameObject staminaBar;
    // 게이지 수치에 따라 길이가 변하는 UI
    public GameObject gaugeBar;

    private void OnEnable()
    {
        // 스태미너 최대 수치를 불러온다
        LoadMaxStamina();
        // 게이지 최대 수치를 불러온다
        LoadMaxGauge();

        // 스태미너 수치를 불러온다
        LoadStamina();
        // 게이지 수치를 불러온다
        LoadGauge();
    }

    void LoadMaxStamina()
    {
        maxStamina = MainGameManager.instance.maxStamina;
    }

    void LoadMaxGauge()
    {
        maxGauge = MainGameManager.instance.maxGauge;
    }

    void LoadStamina()
    {
        stamina = MainGameManager.instance.stamina;
    }

    void LoadGauge()
    {
        gauge = MainGameManager.instance.gauge;
    }

    public void ChangeStaminaBarWidth()
    {
        LoadStamina(); // 스태미너를 재설정한다

        int currentWidth = (int)staminaBar.GetComponent<RectTransform>().sizeDelta.x;
        int currentHeight = (int)staminaBar.GetComponent<RectTransform>().sizeDelta.y;
        staminaBar.GetComponent<RectTransform>().sizeDelta = new Vector2(currentWidth * ((float)stamina / (float)maxStamina), currentHeight);
    }

    public void ChangeGaugeBarWidth()
    {
        LoadGauge(); // 게이지를 재설정한다

        int currentWidth = (int)gaugeBar.GetComponent<RectTransform>().sizeDelta.x;
        int currentHeight = (int)gaugeBar.GetComponent<RectTransform>().sizeDelta.y;
        gaugeBar.GetComponent<RectTransform>().sizeDelta = new Vector2(currentWidth * ((float)gauge / (float)maxGauge), currentHeight);
    }

    public void ClickMenuButton()
    {
        Debug.Log("메뉴 버튼 클릭");
    }

    void OnGUI()
    {
        if (isEnabledOnGUI == true)
        {
            if (GUILayout.Button("ChangeStamina"))
            {
                ChangeStaminaBarWidth();
            }

            if (GUILayout.Button("ChangeGaugeBar"))
            {
                ChangeGaugeBarWidth();
            }
        }
    }
}
