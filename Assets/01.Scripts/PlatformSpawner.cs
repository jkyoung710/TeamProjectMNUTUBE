using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject[] platforms;

    public int stagePlatformsUnitCount;

    float width; // 플랫폼의 가로 길이

    // 초반에 생성한 발판을 화면 밖에 숨겨둘 위치
    Vector2 poolPosition = new Vector2(0, -25);

    void Awake()
    {
        //width = ;
    }

    void OnEnable()
    {
        SetVariables();
        SetOrder();
    }

    void Update()
    {
        // 현재 위치가 원점에서 왼쪽으로 width 이상 이동했을 때 위치를 재배치
        if (this.transform.position.x <= -width)
        {
            Reposition();
        }
    }

    void SetVariables()
    {
        stagePlatformsUnitCount = 2;
    }

    void SetOrder()
    {
        int totalPlatformCount = platforms.Length;
        
        for(int i = 0; i < stagePlatformsUnitCount*4; i++)
        {
            int randNumber = Random.Range(0, totalPlatformCount);
            Instantiate(platforms[randNumber], poolPosition, this.transform.rotation, this.transform);
        }
        
    }


    void SpawnPlatform()
    {

    }

    // 위치를 재배치하는 메서드
    void Reposition()
    {
        // 현재 위치에서 오른쪽으로 가로 길이 * 2만큼 이동
        Vector2 offset = new Vector2(width * 2f, 0);
        this.transform.position = (Vector2)this.transform.position + offset;
    }
}
