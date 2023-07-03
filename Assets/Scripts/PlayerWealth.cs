using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerWealth : MonoBehaviour
{
    public int loot = 0;
    public int betteerLoot = 0;

    public int costAttackNormal = 10;
    public int costHealthNormal = 10;
    public int costAttackGem = 1;
    public int costHealthGem = 1;

    public TextMeshProUGUI attackButton;
    public TextMeshProUGUI healthButton;
    public TextMeshProUGUI attackGemButton;
    public TextMeshProUGUI healthGemButton;
    public TextMeshProUGUI Coins;
    public TextMeshProUGUI Gems;
    // Update is called once per frame
    public void Update()
    {
        attackButton.text = "Cost = " + costAttackNormal;
        healthButton.text = "Cost = " + costHealthNormal;
        attackGemButton.text = "Cost = " + costAttackGem;
        healthGemButton.text = "Cost = " + costHealthGem;

        Coins.text = "Coins " + loot;
        Gems.text = "Gems " + betteerLoot;
    }


    public void addLoot(int lootAmount)
    {
        loot = loot + lootAmount;
    }


    public void addBetterLoot(int betterLootAmount)
    {
        betteerLoot = betteerLoot + betterLootAmount;
    }



    public void AttackAddLoot()
    {
        if (loot >= costAttackNormal)
        {
            FindObjectOfType<PlayerDamage>().AttackAdd();
            loot = loot - costAttackNormal;
            costAttackNormal = costAttackNormal + 10;
            attackButton.text = "Cost = " + costAttackNormal;
        }
    }

    public void healthAddLoot()
    {
        if (loot >= costHealthNormal)
        {
            FindObjectOfType<Playerhealth>().healthAdd();
            loot = loot - costHealthNormal;
            costHealthNormal = costHealthNormal + 10;
            healthButton.text = "Cost = " + costHealthNormal;
        }
    }

    public void AttackAddGem()
    {

        if (betteerLoot >= costAttackGem)
        {
            FindObjectOfType<PlayerDamage>().AttackAdd();
            betteerLoot = betteerLoot - costAttackGem;
            costAttackGem = costAttackGem + 1;
            attackGemButton.text = "Cost = " + costAttackGem;
        }
        
    }

    public void HealthAddGem()
    {
        if (betteerLoot >= costHealthGem)
        {
            FindObjectOfType<Playerhealth>().healthAdd();
            betteerLoot = betteerLoot - costHealthGem;
            costHealthGem = costHealthGem + 1;
            healthGemButton.text = "Cost = " + costHealthGem;
        }

    }
}
