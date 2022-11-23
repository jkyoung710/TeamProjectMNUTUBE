using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 게임 오브젝트를 계속 왼쪽으로 움직이는 스크립트
public class ScrollingObject : MonoBehaviour
{
    public float speed = 10f; // 이동 속도
    float updateSpeed;

    void OnEnable()
    {
        SetVariables(); // 변수 초기화

        // 이벤트에 등록. PlayerDead 이벤트 발행 시 이동 속도 0으로
        MainEventBus.Subscribe(MainEventType.PlayerDead, SetVariables);
        // 이벤트에 등록. PlayerOnGround 이벤트 발행 시 이동 속도 설정 값으로
        MainEventBus.Subscribe(MainEventType.PlayerOnGround, Move);
    }

    void OnDisable()
    {
        // 이벤트 해제
        MainEventBus.Unsubscribe(MainEventType.PlayerDead, SetVariables);
        MainEventBus.Unsubscribe(MainEventType.PlayerOnGround, Move);
    }

    void Update()
    {
        // 게임 오브젝트를 일정 속도로 왼쪽으로 평행이동하는 처리

        // 초당 speed의 속도로 왼쪽으로 평행이동
        transform.Translate(Vector3.left * updateSpeed * Time.deltaTime);
    }

    void SetVariables()
    {
        updateSpeed = 0;
    }

    void Move()
    {
        updateSpeed = speed;
    }
}
