using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject[] platforms;
    int[] platformOrder;

    public int stagePlatformsUnitCount;
    int stageLength;

    public float width; // 플랫폼의 가로 길이

    // 초반에 생성한 발판을 화면 밖에 숨겨둘 위치
    Vector2 poolPosition = new Vector2(0, -25);

    public GameObject[] currentPlatforms;
    public int currentIndex;

    public GameObject startPlatform;
    float platformPositionY;

    void Awake()
    {
        width = startPlatform.transform.localScale.x;
        platformPositionY = startPlatform.transform.position.y;
    }

    void OnEnable()
    {
        SetVariables();
        SetOrder();
        SpawnPlatforms();
        RepositionPlatforms();
    }

    void SetVariables()
    {
        stagePlatformsUnitCount = 2;
        stageLength = (stagePlatformsUnitCount * 4) + 1;
        currentIndex = 0;        
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

    // 위치를 재배치하는 메서드
    void Reposition()
    {
        // 현재 위치에서 오른쪽으로 가로 길이 2배만큼 이동
        Vector2 offset = new Vector2(width, 0);
        try
        {
            Vector2 position = new Vector2(currentPlatforms[currentIndex + 2].transform.position.x, platformPositionY);
            currentPlatforms[currentIndex + 2].transform.position = position + offset;
            Debug.Log("다음 플랫폼 위치 옮김");
        }
        catch
        {
            Debug.Log("다음 플랫폼 없음");
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
