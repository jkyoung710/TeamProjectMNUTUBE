using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// DestroyZone을 빠져나가면 게임오브젝트가 파괴되는 스크립트
public class DestroyZone : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D collision)
    {
        // 나가는 게임오브젝트가 플레이어가 아니면
        if (collision.CompareTag("Player") == false)
        {
            // 파괴한다
            Destroy(collision.gameObject);
        }
    }
}
