using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRigidbody;
    public float speed = 8f;
    public GameObject bulletPrefab;
    private float timeAfterSpawn;
    public float spawnRateMin = 0.5f;
    public float spawnRateMax = 3f;
    private float spawnRate;

    void Start()
    {
        timeAfterSpawn = 6f;
        playerRigidbody = GetComponent<Rigidbody>();
        spawnRate = Random.Range(spawnRateMin, spawnRateMax);

    }


    void Update()
    {
        /*if (Input.GetKey(KeyCode.UpArrow) == true)
        {
            playerRigidbody.AddForce(0f, 0f, speed);
        }

        if (Input.GetKey(KeyCode.DownArrow) == true)
        {
            playerRigidbody.AddForce(0f, 0f, -speed);
        }

        if (Input.GetKey(KeyCode.RightArrow) == true)
        {
            playerRigidbody.AddForce(speed, 0f, 0f);
        }

        if (Input.GetKey(KeyCode.LeftArrow) == true)
        {
            playerRigidbody.AddForce(-speed, 0f, 0f);
        }*/

        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        float xSpeed = xInput * speed;
        float zSpeed = zInput * speed;

        Vector3 newVelocity = new Vector3(xSpeed, 0f, zSpeed);
        playerRigidbody.velocity = newVelocity;

        timeAfterSpawn += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (timeAfterSpawn >= spawnRate)
            {
                timeAfterSpawn = 6f;

                GameObject playerBullet = Instantiate(bulletPrefab, transform.position, transform.rotation);

                playerBullet.transform.Translate(Vector3.forward);

                spawnRate = Random.Range(spawnRateMin, spawnRateMax);
            }
            
            
        }
    }

    public void Die()
    {
        gameObject.SetActive(false);

        GameManager gameManager = FindObjectOfType<GameManager>();
        gameManager.EndGame();

    }
}
