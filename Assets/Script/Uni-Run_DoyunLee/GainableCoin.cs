using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DoyunLee
{
    public class GainableCoin : MonoBehaviour
    {
        void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player") == true)
            {
                GameManager.instance.AddScore(3);
                gameObject.SetActive(false);
            }
        }
    }
}