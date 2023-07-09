using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed;
    private float timer = 0;
    public int bulletLife = 5;

    public int Damage;


    private Vector3 mousePos;
    private Camera mainCam;
    private Rigidbody2D rb;

    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        rb = GetComponent<Rigidbody2D>();
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePos - transform.position;
        Vector3 rotation = transform.position - mousePos;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * bulletSpeed;

        float rot = Mathf.Atan2(rotation.y, rotation.y) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot + 45);

    }

    void Update()
    {
        timer = timer + Time.deltaTime;

        if (timer > bulletLife)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            FindObjectOfType<EnenyHealth>().damagedealt(Damage);
            Destroy(gameObject);
        }
    }


    public void bulletDamage(int increase)
    {
        Damage += increase;
        Debug.Log("damage increased");
    }
}
