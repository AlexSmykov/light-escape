using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public PlayerController player;
    public float speed;
    public float detectionDistance;
    private bool playerDetected = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerDetected)
        {
            GetComponent<Rigidbody2D>().velocity = speed * (player.transform.position - transform.position).normalized;
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
