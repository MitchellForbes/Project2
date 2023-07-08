using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    // private int Counter = 0;
    public List<GameObject> spawnPoints;
    public float Delay = 2;
    public float Timer;

    [SerializeField] GameObject enemy;



    // Update is called once per frame
    void Update()
    {
       spawnPoints = new List<GameObject>(GameObject.FindGameObjectsWithTag("EnemySpawner"));
       Timer += Time.deltaTime;
       Vector2 spawnPosition = new Vector2(Random.Range(-3.0F, 3.0F), Random.Range(-3.0F, 3.0F));
       if (Timer > Delay)
        {
            foreach (GameObject spawnPoint in spawnPoints)
            {
                Instantiate(enemy, spawnPoint.transform.position, Quaternion.identity);
            }
            Timer = 0;
        }

    }
}
