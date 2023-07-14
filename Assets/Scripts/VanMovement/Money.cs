using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : MonoBehaviour
{
    GameObject Player;

    public bool PlayerWentIntoRange = false;

    public float speed = 0.1f;

    public int MONEY = 5;
    bool canStartNextCourtien = true;
    // Start is called before the first frame update
    void Start()
    {
        Player = MovePlayer.instance.van;
    }



    void Update()
    {
        if (PlayerWentIntoRange)
        {
            Vector3 move = Player.transform.position - transform.position;
            if (Vector3.Distance(transform.position, Player.transform.position) < 1.5)
            {

                MovePlayer.instance.MONEY = MovePlayer.instance.MONEY + MONEY;
                Destroy(this.gameObject);
                move = Vector3.zero;
            }


            move = Vector3.ClampMagnitude(move, 1);
            transform.Translate(move * speed * Time.deltaTime);



        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerWentIntoRange = true;
        }
    }
}
