using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet1 : MonoBehaviour
{
    public GameObject enemy = null;
    Rigidbody2D rb;
    public bool PlayerMode = false;

    IEnumerator BulletsDestroy()
    {
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }


    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.parent = null;
       rb= GetComponent<Rigidbody2D>();
        StartCoroutine(BulletsDestroy()); 
        if(PlayerMode)
        {
            rb.AddForce(transform.right * 1000);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(enemy != null)
        {

            transform.position = Vector3.MoveTowards(transform.position, enemy.transform.position, 0.1f);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            if(PlayerMode)
            {
                if(collision.gameObject.transform.parent.gameObject.GetComponent<EnemyMoveScript>().Damage(15f))
                {
                    Destroy(collision.gameObject.transform.parent.gameObject);
                    MovePlayer.instance.MONEY += 20;
                }
            }

            Destroy(gameObject);
        }
    }
}
