using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerWealth : MonoBehaviour
{
    public int points;
    public int damageAdd = 1;

    public void addLoot(int score)
    {
        points = points + score;
    }


    public void AddDamage()
    {
        if (points > 100)
        {
            FindObjectOfType<Bullet>().bulletDamage(damageAdd);
            points -= 100;
        }
    }

    public void increaseFireRate()
    {
        if (points > 100)
        {
            FindObjectOfType<gun>().fireRate();
            points -= 100;
        }
    }


}
