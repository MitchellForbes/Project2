using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyMoveScript : MonoBehaviour
{
     GameObject Player;

    public bool PlayerWentIntoRange = false;

    public float speed = 0.1f;

   float breavingInterval = 0;

    public int dammage = 5;
    bool canStartNextCourtien = true;
    // Start is called before the first frame update
    void Start()
    {
        Player = MovePlayer.instance.van;
        breavingInterval = Random.Range(1,3);
    }

    public Animator play;


    IEnumerator CanAttack()
    {
        canStartNextCourtien = false;
        yield return new WaitForSeconds(1);
        canStartNextCourtien = true;
        MovePlayer.instance.Health = MovePlayer.instance.Health - dammage;

    }

    IEnumerator Zombieflash()
    {
        yield return new WaitForSeconds(0.1f);
        PlayerImage.color = Color.white;
    }

    public float health = 100;

    public SpriteRenderer PlayerImage;

    public bool Damage(float damage)
    {
        health -= damage;
        PlayerImage.color = Color.red;
        StartCoroutine(Zombieflash());

        return health < 0;

    }

    float timeforbreath = 0;

    // Update is called once per frame
    void Update()
    {

        




        if(PlayerWentIntoRange)
        {
            Vector3 move = Player.transform.position - transform.position;
            if (Vector3.Distance(transform.position, Player.transform.position) < 1.5)
            {
                if (canStartNextCourtien)
                {


                    StartCoroutine("CanAttack");
                }
                move = Vector3.zero;
            }

         
            move = Vector3.ClampMagnitude(move, 1);
            transform.Translate(move * speed * Time.deltaTime);

          

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            play.Play("Breathing");
            PlayerWentIntoRange = true;
        }
    }
}
