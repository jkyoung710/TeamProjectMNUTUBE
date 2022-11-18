using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public float speed = 8f;
    private Rigidbody bulletrigedbody;

    void Start()
    {

        bulletrigedbody = GetComponent<Rigidbody>();
        bulletrigedbody.velocity = transform.forward * speed;

        Destroy(gameObject, 3f);
        
    }

    private void OnTriggerEnter(Collider other)
    {
     
        if (other.tag == "Enemy")
        {
            BulletSpawner bulletspawner = other.GetComponent<BulletSpawner>();

            if (bulletspawner != null)
            {
                bulletspawner.Die();
            }
        }
    }

}
