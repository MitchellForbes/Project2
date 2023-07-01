using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public bool alive = false;
    public int Counter = 0;

    [SerializeField] GameObject enemy;
    [SerializeField] GameObject bossEnemy;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Enemy") || GameObject.Find("Enemy(Clone)") || GameObject.Find("Boss(Clone)"))
        {
            alive = true;
        }
        else
        {
            alive = false;
        }

        if (alive == false && Counter < 10)
        {
            Instantiate(enemy, new Vector3(14,-3.5f,0), Quaternion.identity);
            Counter = Counter + 1;
        }

        if (Counter == 10)
        {
            Instantiate(bossEnemy, new Vector3(14, -3.5f, 0), Quaternion.identity);
            Counter = 0;
        }
    }
}
