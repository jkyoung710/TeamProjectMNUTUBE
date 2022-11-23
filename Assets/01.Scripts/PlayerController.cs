using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce; // 점프 힘
    public float fallingForce; // 낙하 힘

    int jumpCount = 0; // 누적 점프 횟수
    bool isGrounded = false; // 바닥에 닿았는지 나타냄
    bool isDead = false; // 사망 상태

    Rigidbody2D playerRigidbody; // 사용할 리지드바디 컴포넌트

    void OnEnable()
    {
        // 초기화
        isDead = false;
        jumpForce = 700f;
        fallingForce = -1f;

        MainEventBus.Subscribe(MainEventType.PlayerDead, ChangeIsDead);    
    }

    void OnDisable()
    {
        MainEventBus.Unsubscribe(MainEventType.PlayerDead, ChangeIsDead);
    }

    void Start()
    {               
        // 게임 오브젝트로부터 사용할 컴포넌트들을 가져와 변수에 할당
        playerRigidbody = this.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // 사용자 입력을 감지하고 점프하는 처리
        if (isDead)
        {
            // 사망 시 처리를 더 이상 진행하지 않고 종료
            return;
        }

        // 마우스 왼쪽 버튼을 눌렀으며 && 최대 점프 횟수(2)에 도달하지 않았다면
        if (Input.GetMouseButtonDown(0) && jumpCount < 2)
        {
            // 점프 횟수 증가
            jumpCount++;
            // 점프 직전에 속도를 순간적으로 제로(0, 0)로 변경
            playerRigidbody.velocity = Vector2.zero;
            // 리지드바디에 위쪽으로 힘 주기
            playerRigidbody.AddForce(new Vector2(0, jumpForce));
        }
        else if (Input.GetMouseButtonUp(0) && playerRigidbody.velocity.y > 0)
        {
            // 마우스 왼쪽 버튼에서 손을 떼는 순간 && 속도의 y값이 양수라면(위로 상승 중)
            // 현재 속도를 절반으로 변경
            playerRigidbody.velocity = playerRigidbody.velocity * 0.5f;
        }

        if (isGrounded == false && jumpCount > 0)
        {
            playerRigidbody.AddForce(new Vector2(0, fallingForce));
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // 바닥에 닿았음을 감지하는 처리

        // 어떤 콜라이더와 닿았으며, 충돌 표면이 위쪽을 보고 있으면
        if (collision.contacts[0].normal.y > 0.7f)
        {
            // isGrounded를 true로 변경하고, 누적 점프 횟수를 0으로 리셋
            isGrounded = true;
            jumpCount = 0;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        // 바닥에서 벗어났음을 감지하는 처리

        // 어떤 콜라이더에서 떼어진 경우 isGrounded를 false로 변경
        isGrounded = false;
    }

    void ChangeIsDead()
    {
        isDead = true;
    }
}
