<<<<<<< HEAD
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Main Unity scene fileÀ» ´ã´çÇÏ´Â °ÔÀÓ¸Å´ÏÀú
=======
ï»¿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Main Unity scene fileì„ ë‹´ë‹¹í•˜ëŠ” ê²Œìž„ë§¤ë‹ˆì €
>>>>>>> parent of 31943a4 (Merge branch 'main' of https://github.com/jkyoung710/TeamProjectMNUTUBE)
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
<<<<<<< HEAD
    private static MainGameManager m_instance; //½Ì±ÛÅÏÀÌ ÇÒ´çµÉ º¯¼ö
=======
    private static MainGameManager m_instance; //ì‹±ê¸€í„´ì´ í• ë‹¹ë  ë³€ìˆ˜
>>>>>>> parent of 31943a4 (Merge branch 'main' of https://github.com/jkyoung710/TeamProjectMNUTUBE)

    public int stamina, gauge;
    public int maxStamina, maxGauge;

    public bool isGameover;

    private void OnEnable()
    {
<<<<<<< HEAD
        // º¯¼ö ÃÊ±âÈ­
=======
        // ë³€ìˆ˜ ì´ˆê¸°í™”
>>>>>>> parent of 31943a4 (Merge branch 'main' of https://github.com/jkyoung710/TeamProjectMNUTUBE)
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
