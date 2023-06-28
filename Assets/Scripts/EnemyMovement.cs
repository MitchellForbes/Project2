using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed = 1.5f;
    public Rigidbody2D rb;



    // Update is called once per frame

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        rb.velocity = -transform.right * moveSpeed;

    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("StopBox"))
        {
            moveSpeed = 0;
            Debug.Log("Hit Box");
        }
    }
}
