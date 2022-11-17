using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// PlayerController는 플레이어 캐릭터로서 Player 게임 오브젝트를 제어함
public class PlayerController : MonoBehaviour
{
    public AudioClip deathClip; // 사망 시 재생할 오디오 클립
    public float jumpForce = 700f; // 점프 힘

    int jumpCount = 0; // 누적 점프 횟수
    bool isGrounded = false; // 바닥에 닿았는지 나타냄
    bool isDead = false; // 사망 상태

    Rigidbody2D playerRigidbody; // 사용할 리지드바디 컴포넌트
    Animator animator; // 사용할 애니메이터 컴포넌트
    AudioSource playerAudio; // 사용할 오디오 소스 컴포넌트

    int defaultHeart = 3;
    int currentHeart;
    public GameObject heartPanel;
    public GameObject heartPrefab;
    List<GameObject> hearts;
    int maxHeartColumn = 12;

    public GameObject damageZeroEffect;

    void OnEnable()
    {
        currentHeart = 0;
        hearts = new List<GameObject>();
        if (heartPanel)
        {   
            for (int i = 0; i < defaultHeart; i++)
            {
                AddHeart();
            }
        }
    }

    void Start()
    {
        // 초기화
        // 게임 오브젝트로부터 사용할 컴포넌트들을 가져와 변수에 할당
        playerRigidbody = this.GetComponent<Rigidbody2D>();
        animator = this.GetComponent<Animator>();
        playerAudio = this.GetComponent<AudioSource>();
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
        if (Input.GetMouseButtonDown(0) && jumpCount < 2 && Time.timeScale > 0)
        {
            // 점프 횟수 증가
            jumpCount++;
            // 점프 직전에 속도를 순간적으로 제로(0, 0)로 변경
            playerRigidbody.velocity = Vector2.zero;
            // 리지드바디에 위쪽으로 힘 주기
            playerRigidbody.AddForce(new Vector2(0, jumpForce));
            // 오디오 소스 재생
            playerAudio.Play();
        }
        else if (Input.GetMouseButtonUp(0) && playerRigidbody.velocity.y > 0 && Time.timeScale > 0)
        {
            // 마우스 왼쪽 버튼에서 손을 떼는 순간 && 속도의 y값이 양수라면(위로 상승 중)
            // 현재 속도를 절반으로 변경
            playerRigidbody.velocity = playerRigidbody.velocity * 0.5f;
        }

        // 애니메이터의 Grounded 파라미터를 isGrounded 값으로 갱신
        animator.SetBool("Grounded", isGrounded);
    }

    void Die()
    {
        // 사망 처리
        // 애니메이터의 Die 트리거 파라미터를 셋
        animator.SetTrigger("Die");

        // 오디오 소스에 할당된 오디오 클립을 deathClip으로 변경
        playerAudio.clip = deathClip;
        // 사망 효과음 재생
        playerAudio.Play();

        // 속도를 제로(0, 0)로 변경
        playerRigidbody.velocity = Vector2.zero;
        // 사망 상태를 true로 변경
        isDead = true;

        // 게임 매니저의 게임오버 처리 실행
        GameManager.instance.OnPlayerDead();
    }

    void BeAttacked()
    {
        if (isDamageZero == false)
        {
            StartCoroutine("BlinkPlayer");
            DecreaseHeart();
        }        
    }
    
    IEnumerator BlinkPlayer()
    {
        int blinkingNumber = 3;
        float blinkingTime = 0.25f;

        Color32 color32 = this.GetComponent<SpriteRenderer>().color;
        for (int i = 0; i < blinkingNumber*2; i++)
        {
            if (this.GetComponent<SpriteRenderer>().color.a == 1)
            {
                this.GetComponent<SpriteRenderer>().color = new Color32(color32.r, color32.g, color32.b, 128);
            }
            else
            {
                this.GetComponent<SpriteRenderer>().color = new Color32(color32.r, color32.g, color32.b, 255);
            }
            yield return new WaitForSeconds(blinkingTime);
        }                
    }

    bool isDamageZero = false;
    void DecreaseHeart()
    {
        if (currentHeart > 0)
        {
            currentHeart--;
            Debug.Log(currentHeart.ToString());
            for (int i = 0; i < hearts.Count; i++)
            {
                if (i >= currentHeart && hearts[i].transform.GetChild(0).gameObject.activeSelf == true)
                {
                    hearts[i].transform.GetChild(0).gameObject.SetActive(false);
                }
            }

            if (currentHeart == 0)
            {
                Die();
            }
        }        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // 트리거 콜라이더를 가진 장애물과 충돌을 감지

        if (collision.tag == "Dead" && !isDead)
        {
            // 충돌한 상대방의 태그가 Dead이며 아직 사망하지 않았다면 Die() 실행
            Die();
        }

        if (collision.gameObject.CompareTag("Attack") == true && !isDead)
        {
            BeAttacked();
        }

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Dead") == true && !isDead)
        {
            Die();
        }

        if (collision.gameObject.CompareTag("Attack") == true && !isDead)
        {
            BeAttacked();
        }


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



    public void AddItem(string itemTag)
    {
        string[] tmp = itemTag.Split('_');
        string _itemName = tmp[1];

        switch (_itemName)
        {
            case "HealHeart":
                HealHeart();
                break;
            case "AddHeart":
                AddHeart();
                break;
            case "DamageZero":
                DamageZero();
                break;
            default: break;
        }
    }

    void HealHeart()
    {
        for(int i = 0; i < hearts.Count; i++)
        {
            if (hearts[i].transform.GetChild(0).gameObject.activeSelf == false)
            {
                currentHeart++;
                hearts[i].transform.GetChild(0).gameObject.SetActive(true);
                break;
            }
        }        
    }

    void AddHeart()
    {
        float gap = 5;
        int i = heartPanel.transform.childCount;
        GameObject heart = Instantiate(heartPrefab, heartPanel.transform);        
        float heartWidth = heart.GetComponent<RectTransform>().sizeDelta.x;
        float heartHeight = heart.GetComponent<RectTransform>().sizeDelta.y;
        Vector3 currentPosition = heart.GetComponent<RectTransform>().localPosition;
        float resultPosX = currentPosition.x + (heartWidth + gap) * (i % maxHeartColumn);
        float resultPosY = currentPosition.y - (heartHeight + gap) * (i / maxHeartColumn);
        heart.GetComponent<RectTransform>().localPosition = new Vector3(resultPosX, resultPosY, currentPosition.z);
        hearts.Add(heart);
        heart.transform.GetChild(0).gameObject.SetActive(false);

        HealHeart();
    }

    void DamageZero()
    {
        StartCoroutine("DamageZeroMode");
    }

    IEnumerator DamageZeroMode()
    {
        damageZeroEffect.GetComponent<ParticleSystem>().Play();
        float time = 3f;
        isDamageZero = true;
        yield return new WaitForSeconds(time);
        isDamageZero = false;
        damageZeroEffect.GetComponent<ParticleSystem>().Stop();
    }
}
