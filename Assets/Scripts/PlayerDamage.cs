using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    public int playerDamage = 3;
    public float delay = 0;
    public float delayTimer; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        delay = delay + Time.deltaTime;
        if (Input.GetMouseButtonDown(0) && delay >= delayTimer && GameObject.Find("Enemy(Clone)"))
        {
            FindObjectOfType<EnenyHealth>().damagedealt(playerDamage);
            Debug.Log("clicked");
            delay = 0;
        }

        if (Input.GetMouseButtonDown(0) && delay >= delayTimer && GameObject.Find("Boss(Clone)"))
        {
            FindObjectOfType<BossHealth>().damagedealt(playerDamage);
            Debug.Log("clicked");
            delay = 0;
        }
    }


    public void AttackAdd()
    {
        playerDamage = playerDamage + 1;
    }
}
