using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [Range(0, 15)] public float moveSpeed = 0;
    public int speedCap = 15;
    private float direction;

    public float distance;
    public Rigidbody2D playerBody;

    // Update is called once per frame
    void Update()
    {
        direction = Input.GetAxisRaw("Horizontal");
        if (Input.GetButton("Horizontal"))
        {
            if (moveSpeed < speedCap && direction > 0)
            {
                moveSpeed = moveSpeed + Time.deltaTime;
            }
            else if (moveSpeed > 0 && direction < 0)
            {
                moveSpeed = moveSpeed - Time.deltaTime;
            }
        }

        distance = distance + (Time.deltaTime * moveSpeed);
        playerBody.velocity = transform.right * moveSpeed;


        if (distance > 400)
        {
            FindObjectOfType<Shop>().shopload();
        }
    }

}
