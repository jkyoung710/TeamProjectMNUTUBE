using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

// 게임오버 상태를 표현하고, 게임 점수와 UI를 관리하는 게임 매니저
// 씬에는 단 하나의 게임 매니저만 존재할 수 있음
public class GameManager : MonoBehaviour
{
    public static GameManager instance; // 싱글턴을 할당할 전역 변수

    public bool isGameover = false; // 게임오버 상태
    public TextMeshProUGUI scoreText; // 점수를 출력할 UI 텍스트
    public TextMeshProUGUI gameoverUI; // 게임오버 시 활성화할 UI 게임 오브젝트

    int score = 0; // 게임 점수


    bool isAdded = false;
    float addedTime;
    float scoreScale = 1f;

    public GameObject countDownNumber;
    int count = 3;
    int currentCount;
    List<string> coList;

    public Image timeBar;
    bool isCountDown = false;

    // 게임 시작과 동시에 싱글턴을 구성
    void Awake()
    {
        currentTimeScale = 1f;
        Time.timeScale = 0;

        // 싱글턴 변수 instance가 비어 있는가?
        if (instance == null)
        {
            // instance가 비어 있다면(null) 그곳에 자기 자신을 할당
            instance = this;
        }
        else
        {
            // instance에 이미 다른 GameManager 오브젝트가 할당되어 있는 경우

            // 씬에 두 개 이상의 GameManager 오브젝트가 존재한다는 의미
            // 싱글턴 오브젝트는 하나만 존재해야 하므로 자신의 게임 오브젝트를 파괴
            Debug.LogWarning("씬에 두 개 이상의 게임 매니저가 존재합니다!");
            Destroy(gameObject);
        }
    }

    void OnEnable()
    {
        isAdded = false;
        addedTime = 0f;
        scoreScale = 1f;
    }

    void Start()
    {
        CountDownSeconds();
    }

    void Update()
    {
        // 게임오버 상태에서 게임을 재시작할 수 있게 하는 처리
        if (isGameover && Input.GetMouseButton(0))
        {
            // 게임오버 상태에서 마우스 왼쪽 버튼을 클릭하면 현재 씬 재시작
            RestartGame();
        }

        if (isAdded == true)
        {            
            addedTime -= Time.deltaTime;
            if (addedTime <= 0f)
            {
                isAdded = false;
                addedTime = 0f;
                scoreScale = 1f;
            }
        }

        if (isCountDown == true)
        {
            timeBar.fillAmount -= Time.unscaledDeltaTime;
        }
    }

    // 점수를 증가시키는 메서드
    public void AddScore(int newScore)
    {
        // 게임오버가 아니라면
        if (!isGameover)
        {
            // 점수를 증가
            score += (int)(newScore*scoreScale);
            scoreText.text = $"Score : {score}";

            // 추가 점수를 획득할 수 있는 시간 부여
            SetAddedTime();
        }
    }

    // 플레이어 캐릭터 사망 시 게임오버를 실행하는 메서드
    public void OnPlayerDead()
    {
        isGameover = true;
        gameoverUI.gameObject.SetActive(true);
    }



    void SetAddedTime()
    {
        scoreScale *= 1.5f;
        addedTime = 1f;
        isAdded = true;
    }

    float currentTimeScale;
    public void ToggleMenuPanel(GameObject menuPanel)
    {
        if (Time.timeScale != 0)
        {
            currentTimeScale = Time.timeScale;
            OnMenuPanel(menuPanel);
        }
        else
        {
            OffMenuPanel(menuPanel);
        }
    }    

    void OnMenuPanel(GameObject menuPanel)
    {
  
        Time.timeScale = 0;
        menuPanel.SetActive(true);
    }

    void OffMenuPanel(GameObject menuPanel)
    {        
        menuPanel.SetActive(false);        
        CountDownSeconds();        
    }

    void CountDownSeconds()
    {
        coList = new List<string>();
        currentCount = count;        
        StartCoroutine("CountDown");                        
    }
    
    IEnumerator CountDown()
    {
        if (coList.Count == 0)
        {
            coList.Add("CountDown");
            countDownNumber.SetActive(true);
            for (int i = 0; i < count; i++)
            {
                ResetCountDownBar();
                ChangeCountDownNumber();
                ChangeCountDownBar();
                yield return new WaitForSecondsRealtime(1f);
            }            
            Time.timeScale = currentTimeScale;
            countDownNumber.SetActive(false);
            isCountDown = false;
            coList.Clear();
        }        
    }

    void ChangeCountDownNumber()
    {
        countDownNumber.GetComponentInChildren<TextMeshProUGUI>().text = currentCount--.ToString();
    }

    
    void ResetCountDownBar()
    {
        timeBar.fillAmount = 1f;
    }

    void ChangeCountDownBar()
    {
        isCountDown = true;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GotoIntroScene()
    {
        SceneManager.LoadScene("Intro");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
