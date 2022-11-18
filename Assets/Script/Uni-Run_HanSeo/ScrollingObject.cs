using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 게임 오브젝트를 계속 왼쪽으로 움직이는 스크립트
public class ScrollingObject : MonoBehaviour
{
    public static ScrollingObject instance;
    public float speed = 10f; // 이동 속도

    void Update()
    {
        // 게임 오브젝트를 일정 속도로 왼쪽으로 평행이동하는 처리
        // 초당 speed의 속도로 왼쪽으로 평행이동

        // 게임오버가 아니라면
        if (!GameManager.instance.isGameover)
        {
            transform.Translate
            (Vector3.left * speed * Time.deltaTime);
        }
    }
}
