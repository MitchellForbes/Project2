using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.SceneManagement;
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

    public Slider progress;
    public Slider Healthbar;

    bool isEnemyCurrentlyInfront = false;

    public GameObject DeathScreen;

    private void Awake()
    {
        instance = this;
    }
    
    public void LoadLevelAgian()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void Start()
    {
        
        Time.timeScale = 1.0f;
     
    }

    public Transform Check;

    Vector3 mouse_pos;
    Transform target;
    Vector3 object_pos;
    float angle;
    public bool isLocal;
    public GameObject winscreen;
    public GameObject BloodEffect;

    // Update is called once per frame
    void Update()
    {
        Shop.instance.MoneyText.text = "$"+MONEY.ToString();

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
                            Instantiate(BloodEffect, p.gameObject.transform.parent.position, p.gameObject.transform.parent.rotation);
                            Destroy(p.gameObject.transform.parent.gameObject);
                            StartCoroutine(Shake(1f,0.1f));
                        }
                    }
                }
            }
            Speed = 0;
        }

        percentageofthewayComplete += Speed * Time.deltaTime;
        gunCheck(GunTypes.minigun,1);
        gunCheck(Shop.instance.gun1,2);
        gunCheck(Shop.instance.gun2,3);
        gunCheck(Shop.instance.gun3,4);
        gunCheck(Shop.instance.gun4,5);
        gunCheck(Shop.instance.gun5,6);
        gunCheck(Shop.instance.gun6,7);
        gunCheck(Shop.instance.gun7,8);
        progress.value = percentageofthewayComplete;
        Healthbar.value = Health;

        if(Health <= 0)
        {
            DeathScreen.SetActive(true);
        }

        if(percentageofthewayComplete >= 1)
        {
            Time.timeScale = 0;
            winscreen.SetActive(true) ;
        }

        //Mouse Shoot
      
        if(Input.GetMouseButtonDown(0))
        {
            mouse_pos = Input.mousePosition;
            mouse_pos.z = -20;
            object_pos = Camera.main.WorldToScreenPoint(shootpoint.transform.position);
            mouse_pos.x = mouse_pos.x - object_pos.x;
            mouse_pos.y = mouse_pos.y - object_pos.y;
            angle = Mathf.Atan2(mouse_pos.y, mouse_pos.x) * Mathf.Rad2Deg;
            shootpoint.transform.rotation = Quaternion.Euler(0, 0, angle);

           // shootpoint.transform.LookAt(Camera.main.WorldToScreenPoint(Input.mousePosition), Vector3.forward);
            GameObject tmp = Instantiate(bullet, newShootPoint.transform.position,shootpoint.transform.rotation);
            tmp.GetComponent<Bullet1>().PlayerMode = true;

        }
        

    }
    public GameObject newShootPoint;
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
    bool slot2 = true;
    bool slot3 = true;
    bool slot4 = true;
    bool slot5 = true;
    bool slot6 = true;
    bool slot7 = true;
    bool slot8 = true;

    public GameObject shootpoint;
    IEnumerator Slot1(Collider2D c, int slotid)
    {
        slotCheck(slotid, false);
        yield return new WaitForSeconds(minigunFireRate);
        slotCheck(slotid, true);

        GameObject tmp = Instantiate(bullet, shootpoint.transform);
        tmp.GetComponent<Bullet1>().enemy = c.gameObject;
        try
        {
            shootpoint.transform.LookAt(c.transform.position);
        }
        catch (System.Exception e)
        {
            Destroy(tmp);
        }

        if (c.GetComponentInParent<EnemyMoveScript>().Damage(minigunDammage))            
        {
            Instantiate(BloodEffect, c.gameObject.transform.parent.position, c.gameObject.transform.parent.rotation);
            Destroy(c.gameObject.transform.parent.gameObject);
            MONEY += 5;
            StartCoroutine(Shake(1f, 0.1f));
        }

    }


    IEnumerator Flamethrower(Collider2D c, int slotid)
    {
        slotCheck(slotid, false);
        yield return new WaitForSeconds(flamethrowerFireRate);
        slotCheck(slotid, true);

        GameObject tmp = Instantiate(bullet, shootpoint.transform);
        tmp.GetComponent<Bullet1>().enemy = c.gameObject;
        try
        {
            shootpoint.transform.LookAt(c.transform.position);
        }
        catch (System.Exception e)
        {
            Destroy(tmp);
        }

        if (c.GetComponentInParent<EnemyMoveScript>().Damage(flamethrowerDammage))
        {
            Instantiate(BloodEffect, c.gameObject.transform.parent.position, c.gameObject.transform.parent.rotation);
            Destroy(c.gameObject.transform.parent.gameObject);
            MONEY += 5;
            StartCoroutine(Shake(1f, 0.1f));
        }

    }

    [Header("MiniGun Stats")]
    public float minigunDammage = 3;
    public float minigunFireRate = 0.05f;

    [Header("FlameThrower Stats")]
    public float flamethrowerDammage = 3;
    public float flamethrowerFireRate = 0.01f;

    

   public IEnumerator Shake (float duration, float Mag)
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
    }
    



    private bool slotCheck(int id)
    {
        switch(id)
        {
            case 1:
                return slot1;
            case 2:
                return slot2;
                case 3:
                   return slot3;
                case 4:
                return slot4;
                case 5:
                return slot5;
                case 6:
                return slot6;
                case 7:
                return slot7;
                    case 8:
                    
                return slot8;

        }
        return false;
    }

    private void slotCheck(int id,bool set)
    {
        switch (id)
        {
            case 1:
               slot1 = set;
                break;
            case 2:
                slot2 = set;
                break;
            case 3:
                slot3 = set;
                break;
            case 4:
                slot4 = set;
                break;
            case 5:
                slot5 = set;
                break;
            case 6:
                slot6 = set;
                break;
            case 7:
                slot7 = set;
                break;
            case 8:

                slot8 = set;
                break;
        }
       
    }

    private void gunCheck(GunTypes weaponSlot, int slotid)
    {
        switch (weaponSlot)
        {
            case GunTypes.minigun:
                Collider2D clossestCol = null;
                float DistanceCheck = 100;
                Collider2D[] col = Physics2D.OverlapCircleAll(van.transform.position, 6f, EnemeyLayer);

                foreach (Collider2D c in col)
                {
                    if (Vector3.Distance(van.transform.position, c.gameObject.transform.position) < DistanceCheck)
                    {
                        DistanceCheck = Vector3.Distance(van.transform.position, c.gameObject.transform.position);
                        clossestCol = c;
                    }
                }
                if (clossestCol != null && slotCheck(slotid))
                {
                    StartCoroutine(Slot1(clossestCol,slotid));
                }




                break;

            case GunTypes.flamerthrower:
                Collider2D clossestCol2 = null;
                float DistanceCheck2 = 100;
                Collider2D[] col2 = Physics2D.OverlapCircleAll(van.transform.position, 4f, EnemeyLayer);

                foreach (Collider2D c in col2)
                {
                    if (Vector3.Distance(van.transform.position, c.gameObject.transform.position) < DistanceCheck2)
                    {
                        DistanceCheck2 = Vector3.Distance(van.transform.position, c.gameObject.transform.position);
                        clossestCol2 = c;
                    }
                }
                if (clossestCol2 != null && slotCheck(slotid))
                {
                    StartCoroutine(Flamethrower(clossestCol2, slotid));
                }

                


                break;

        }





    }
















       
            

    

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(van.transform.position, 6f);
    }
}
