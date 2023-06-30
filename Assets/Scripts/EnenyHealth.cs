using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnenyHealth : MonoBehaviour
{

    public int health = 10;
    
    // Start is called before the first frame update
    void Start()
    {
    }


    public void damagedealt(int damage)
    {
        Debug.Log("Took damage");
        health = health - damage;
    }
}
