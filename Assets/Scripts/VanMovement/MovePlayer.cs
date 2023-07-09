using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{

    public GameObject Starts, End;

    float percentageofthewayComplete = 0;

    float Speed = 0;
    float maxSpeed = 0.05f;

    public int Health = 100;

    public static MovePlayer instance;

    bool isEnemyCurrentlyInfront = false;

    private void Start()
    {
        instance = this;
    }

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
            Speed = 0;
        }

        percentageofthewayComplete += Speed * Time.deltaTime;
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
}
