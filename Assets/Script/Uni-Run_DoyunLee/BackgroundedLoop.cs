using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundedLoop : MonoBehaviour
{
    // 왼쪽 끝으로 이동한 배경을 오른쪽 끝으로 재배치하는 스크립트

    float width; // 배경의 가로 길이

    void Awake()
    {
        // 가로 길이를 측정하는 처리
        // BoxCollider2D 컴포넌트의 Size 필드의 x 값을 가로 길이로 사용
        BoxCollider2D backgroundCollider = this.GetComponent<BoxCollider2D>();
        width = backgroundCollider.size.x;
    }

    void Update()
    {
        // 현재 위치가 원점에서 왼쪽으로 width 이상 이동했을 때 위치를 재배치
        if (this.transform.position.x <= -width)
        {
            Reposition();
        }
    }

    // 위치를 재배치하는 메서드
    void Reposition()
    {
        // 현재 위치에서 오른쪽으로 가로 길이 * 2만큼 이동
        Vector2 offset = new Vector2(width * 2f, 0);
        this.transform.position = (Vector2)this.transform.position + offset;
    }
}
