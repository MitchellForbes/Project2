using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun : MonoBehaviour
{
    private Vector3 mousePos;
    private Camera mainCam;
    public GameObject Bullet;
    public Transform bulletTransform;
    private float timer;
    public float delayBetweenFiring;


    private void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);

        Vector3 rotation = mousePos - transform.position;

        float rot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, rot);

        timer += Time.deltaTime;

        if (timer > delayBetweenFiring)
        {
            Instantiate(Bullet, bulletTransform.position, Quaternion.identity);
            timer = 0;
        }
    }
}
