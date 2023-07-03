using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnenyHealth : MonoBehaviour
{

    public int health = 10;
    public int loot = 5;



    public void Update()
    {
        FindObjectOfType<Menu>().EnemyHealth(health);
    }

    public void damagedealt(int damage)
    {
        Debug.Log("Took damage");
        health = health - damage;

        if (health <= 0)
        {
            FindObjectOfType<PlayerWealth>().addLoot(loot);
            Destroy(gameObject);
        }


    }
}
   
