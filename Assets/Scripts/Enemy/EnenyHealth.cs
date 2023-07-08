using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnenyHealth : MonoBehaviour
{

    public int health;
    public int loot = 5;




    public void damagedealt(int damage)
    {
        
        health -= damage;
        Debug.Log("Took damage");
        if (health <= 0)
        {
            FindObjectOfType<PlayerWealth>().addLoot(loot);
            Destroy(gameObject);
        }

    }
}
   
