using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{

    private float delay = 0;
    public int enemyDamage = 2;

    void Update()
    {
        delay = delay + Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player") && delay > 0.5)
        {
            FindObjectOfType<Playerhealth>().damagedealt(enemyDamage);
            delay = 0;
        }
    }
}
