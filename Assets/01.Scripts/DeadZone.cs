using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// DeadZone과 충돌하면 게임오버가 되는 스크립트
public class DeadZone : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") == true)
        {
            MainGameManager.instance.BeGameOver();
        }
    }
}
