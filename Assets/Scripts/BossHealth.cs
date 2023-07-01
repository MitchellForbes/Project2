using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{

    public int health = 20;
    public int betterLoot = 1;


    // Start is called before the first frame update
    void Start()
    {
    }



    public void damagedealt(int damage)
    {
        Debug.Log("Took damage");
        health = health - damage;

        if (health <= 0)
        {
            FindObjectOfType<PlayerWealth>().addBetterLoot(betterLoot);
            Destroy(gameObject);
        }

    }
}
