using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Playerhealth : MonoBehaviour
{
    public int Health = 10;
    public TextMeshProUGUI healthUI;
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        healthUI.text = "Player health: " + Health;
    }
    public void damagedealt(int damage)
    {
        Health = Health - damage;
        Debug.Log("player took damage");

        if (Health <= 0)
        {
            FindObjectOfType<Menu>().Back();
        }
    }

    public void healthAdd()
    {
        Health = Health + 3;
    }
}
