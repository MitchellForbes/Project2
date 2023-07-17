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

    public IEnumerator Shake(float duration, float Mag)
    {
        Vector3 org = Camera.main.transform.localPosition;
        float elapsed = 0.0f;
        while (elapsed < duration)
        {
            float x = UnityEngine.Random.Range(-1f, 1f) * Mag;
            float y = UnityEngine.Random.Range(-1f, 1f) * Mag;

            Camera.main.transform.localPosition = new Vector3(x, y, org.z);

            elapsed += Time.deltaTime;

            yield return null;
        }

        Camera.main.transform.localPosition = new Vector3(0, 0, -10f);
        Destroy(gameObject);
    }
    public GameObject BloodEffect;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            if(PlayerMode)
            {
                if(collision.gameObject.transform.parent.gameObject.GetComponent<EnemyMoveScript>().Damage(15f))
                {
                    StartCoroutine(Shake(1, 0.1f));
                    Instantiate(BloodEffect, collision.gameObject.transform.parent.position, collision.gameObject.transform.parent.rotation);
                    Destroy(collision.gameObject.transform.parent.gameObject);
                    MovePlayer.instance.MONEY += 20;
                    
                }
            }else
            {
                Destroy(gameObject);
            }

            
        }
    }
}
