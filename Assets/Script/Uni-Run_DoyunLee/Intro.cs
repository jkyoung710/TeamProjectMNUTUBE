using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour
{
    public float speed = 10f; // 이동 속도
    public GameObject[] scrollingObjects;

    void Awake()
    {
        Time.timeScale = 1;
        Input.multiTouchEnabled = false;
    }

    void Update()
    {
        if (scrollingObjects.Length > 0)
        {
            for (int i = 0; i < scrollingObjects.Length; i++)
            {
                scrollingObjects[i].transform.Translate(Vector3.left * speed * Time.deltaTime);
            }            
        }        

        if (Input.GetMouseButtonUp(0) == true)
        {
            Time.timeScale = 0;
            SceneManager.LoadScene(1);
        }
    }
}
