using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MainGameManager : MonoBehaviour
{
    public static MainGameManager instance
    {
        get
        {
            if (m_instance == null)
            {
                m_instance = FindObjectOfType<MainGameManager>();
            }

            return m_instance;
        }
    }

    private static MainGameManager m_instance; //ΩÃ±€≈œ¿Ã «“¥Áµ… ∫Øºˆ

    private static MainGameManager m_instance; //?±Í??¥Ïù¥ ?†Îãπ??Î≥Ä??


    public int stamina, gauge;
    public int maxStamina, maxGauge;

    public bool isGameover;

    private void OnEnable()
    {

        SetVariables();
    }

    void SetVariables()
    {
        stamina = 100;
        gauge = 0;
        maxStamina = stamina;
        maxGauge = gauge;

        isGameover = false;
    }
}
