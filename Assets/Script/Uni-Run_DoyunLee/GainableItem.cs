using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GainableItem : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") == true)
        {
            collision.gameObject.GetComponent<PlayerController>().AddItem(this.tag);
            GameManager.instance.AddScore(1);
            gameObject.SetActive(false);
        }
    }
}
