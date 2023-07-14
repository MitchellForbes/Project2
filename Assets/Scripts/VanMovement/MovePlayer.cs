using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GunTypes 
{
    none,
    minigun, 
    shotgun,
    flamerthrower,
    grenadelauncher
}


public class MovePlayer : MonoBehaviour
{
    public Dictionary<int, GunTypes> weaponSlots = new();


    public GameObject Starts, End,van;

    float percentageofthewayComplete = 0;

    float Speed = 0;
    float maxSpeed = 0.05f;

    public int MONEY = 0;

    public int Health = 100;

    public static MovePlayer instance;

    bool isEnemyCurrentlyInfront = false;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        

        weaponSlots.Add(1, GunTypes.minigun);
    }

    public Transform Check;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Mathf.Lerp(Starts.transform.position.x, End.transform.position.x, percentageofthewayComplete),0,0);

        if(Input.GetKey(KeyCode.D))
        {
            Speed += 0.01f * Time.deltaTime;
            Speed = Mathf.Clamp(Speed, 0, maxSpeed);
        }else
        {
            Speed -= 0.1f * Time.deltaTime;
            Speed = Mathf.Clamp(Speed, 0, maxSpeed);
        }

        if(isEnemyCurrentlyInfront)
        {
           
            if (Speed > maxSpeed/2)
            {
                Debug.Log("enemy hit");
               Collider2D[] we = Physics2D.OverlapBoxAll(Check.position, Vector2.one * 4, 0);
                foreach(Collider2D p in we)
                {
                    if (p.CompareTag("Enemy"))
                    {
                        if (p.GetComponentInParent<EnemyMoveScript>().Damage(100))
                        {
                            Destroy(p.gameObject.transform.parent.gameObject);
                        }
                    }
                }
            }
            Speed = 0;
        }

        percentageofthewayComplete += Speed * Time.deltaTime;
        gunCheck(weaponSlots[1]);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            isEnemyCurrentlyInfront = true;
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            isEnemyCurrentlyInfront = false;
        }
    }

    public LayerMask EnemeyLayer;

    public GameObject bullet;

    bool slot1 = true;

    public GameObject shootpoint;
    IEnumerator Slot1(Collider2D c)
    {
        slot1 = false;
        yield return new WaitForSeconds(minigunFireRate);
        slot1 = true;
        shootpoint.transform.LookAt(c.transform.position);
        GameObject tmp = Instantiate(bullet, shootpoint.transform);
        tmp.GetComponent<Bullet1>().enemy = c.gameObject;
       
        
        if (c.GetComponentInParent<EnemyMoveScript>().Damage(minigunDammage))            
        {
            Destroy(c.gameObject.transform.parent.gameObject);
        }

    }


    [Header("MiniGun Stats")]
    public float minigunDammage = 3;
    public float minigunFireRate = 0.05f;



    private void gunCheck(GunTypes weaponSlot)
    {
        switch(weaponSlot)
        {
            case GunTypes.minigun:
                Collider2D clossestCol = null;
                float DistanceCheck = 100;
                Collider2D[] col = Physics2D.OverlapCircleAll(van.transform.position, 6f, EnemeyLayer);

                foreach(Collider2D c in col)
                {
                    if(Vector3.Distance(van.transform.position,c.gameObject.transform.position) < DistanceCheck)
                    {
                        DistanceCheck = Vector3.Distance(van.transform.position, c.gameObject.transform.position);
                        clossestCol = c;
                    }
                }
                if(clossestCol != null && slot1)
                {
                    StartCoroutine(Slot1(clossestCol));
                }
                



                break;
        }
            

    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(van.transform.position, 6f);
    }
}
