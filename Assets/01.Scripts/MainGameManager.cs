<<<<<<< HEAD
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Main Unity scene fileÀ» ´ã´çÇÏ´Â °ÔÀÓ¸Å´ÏÀú
=======
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Main Unity scene file???´ë‹¹?˜ëŠ” ê²Œìž„ë§¤ë‹ˆ?€
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
    private static MainGameManager m_instance; //?±ê??´ì´ ? ë‹¹??ë³€??
>>>>>>> parent of 31943a4 (Merge branch 'main' of https://github.com/jkyoung710/TeamProjectMNUTUBE)

    public int stamina, gauge;
    public int maxStamina, maxGauge;

    public bool isGameover;

    private void OnEnable()
    {
<<<<<<< HEAD
        // º¯¼ö ÃÊ±âÈ­
=======
        // ë³€??ì´ˆê¸°??
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
