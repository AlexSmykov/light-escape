using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public float detectionDistance, damageInterval;
    private bool playerDetected = false;
    public float damage;
    private bool contacted = false;
    private float lastDamagedAt = -100.0f;

    private PlayerController player;

    void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            contacted = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            contacted = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (contacted && Time.realtimeSinceStartup >= lastDamagedAt + damageInterval)
        {
            player.PlayerDamaged(damage);
            lastDamagedAt = Time.realtimeSinceStartup;
        }
        else if (playerDetected)
        {
            GetComponent<Rigidbody2D>().velocity = speed * (player.transform.position - transform.position).normalized;
            if (GetComponent<Rigidbody2D>().velocity.x > 0)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
            else
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
        }
        else
        {
            if ((player.transform.position - transform.position).magnitude <= detectionDistance)
            {
                playerDetected = true;
            }
        }
    }
}
