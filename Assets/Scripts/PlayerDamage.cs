using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    public int playerDamage = 3;
    public float delay = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        delay = delay + Time.deltaTime;
        if (Input.GetMouseButtonDown(0) && delay >= 2)
        {
            FindObjectOfType<EnenyHealth>().damagedealt(playerDamage);
            Debug.Log("clicked");
            delay = 0;
        }

    }
}
