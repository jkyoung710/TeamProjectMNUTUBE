using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// DestroyZone을 빠져나가면 게임오브젝트가 파괴되는 스크립트
public class DestroyZone : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") == false)
        {
            Destroy(collision.gameObject);
        }
    }
}
