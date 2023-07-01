using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{

    private float delay = 0;
    public int enemyDamage = 2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        delay = delay + Time.deltaTime;

        if (delay >= 5)
        {
            FindObjectOfType<Playerhealth>().damagedealt(enemyDamage);
            delay = 0;
        }
    }
}
