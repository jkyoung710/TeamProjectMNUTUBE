using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 플랫폼을 생성하고 배치하는 스크립트
public class PlatformSpawner : MonoBehaviour
{    
    public GameObject[] platforms; // 플랫폼 프리팹 목록
    int[] platformOrder; // 랜덤 생성된 플랫폼 순서

    public int stagePlatformsUnitCount; // 핵심 부품 사이에 배치될 플랫폼 수
    int stageLength; // 총 플랫폼 수    

    // 초반에 생성한 발판을 화면 밖에 숨겨둘 위치
    Vector2 poolPosition = new Vector2(0, -25);
    // 현재 생성된 플랫폼 목록
    public GameObject[] currentPlatforms;

    public GameObject startPlatform; // 시작 플랫폼
    // 시작 플랫폼의 가로 길이
    // 현재 모든 플랫폼의 길이가 시작 플랫폼과 동일
    public float width;
    float platformPositionY; // 시작 플랫폼의 y값

    void Awake()
    {
        // 시작 플랫폼 관련 변수 할당
        width = startPlatform.transform.localScale.x;
        platformPositionY = startPlatform.transform.position.y;
    }

    void OnEnable()
    {
        SetVariables(); // 스테이지 관련 변수 할당
        SetOrder(); // 플랫폼 생성될 순서 정함
        SpawnPlatforms(); // 플랫폼 생성
        RepositionPlatforms(); // 플랫폼 정해진 순서대로 배치
    }

    void SetVariables()
    {
        stagePlatformsUnitCount = 2;
        stageLength = (stagePlatformsUnitCount * 4) + 1;      
    }

    void SetOrder()
    {
        int totalPlatformCount = platforms.Length;
        platformOrder = new int[stageLength];

        for (int i = 1; i < stageLength; i++)
        {
            int randNumber = Random.Range(0, totalPlatformCount);            
            platformOrder[i] = randNumber;            
        }        
    }

    void SpawnPlatforms()
    {
        currentPlatforms = new GameObject[stageLength];
        currentPlatforms[0] = startPlatform;

        for (int i = 1; i < stageLength; i++)
        {
            currentPlatforms[i] = Instantiate(platforms[platformOrder[i]], poolPosition, this.transform.rotation, this.transform);
        }        
    }

    void RepositionPlatforms()
    {
        Vector2 offset = new Vector2(width, 0);

        for (int i = 1; i < currentPlatforms.Length; i++)
        {
            Vector2 position = new Vector2(currentPlatforms[i].transform.position.x, platformPositionY);
            currentPlatforms[i].transform.position = position + offset * i;
            Debug.Log("다음 플랫폼 위치 옮김");
        }        
    }
}
