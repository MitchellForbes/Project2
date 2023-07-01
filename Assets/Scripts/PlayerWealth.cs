using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWealth : MonoBehaviour
{
    public int loot = 0;
    public int betteerLoot = 0;

    // Update is called once per frame
    void Update()
    {

    }


    public void addLoot(int lootAmount)
    {
        loot = loot + lootAmount;
    }


    public void addBetterLoot(int betterLootAmount)
    {
        betteerLoot = betteerLoot + betterLootAmount;
    }
}
