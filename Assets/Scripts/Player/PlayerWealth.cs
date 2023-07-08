using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerWealth : MonoBehaviour
{
    public int points;

    public void addLoot(int score)
    {
        points = points + score;
    }



}
