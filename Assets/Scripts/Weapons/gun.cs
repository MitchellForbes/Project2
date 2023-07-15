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
    public float fireRateUpdate = 0.01F;


    private void Start()
    {
        mainCam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);

        Vector3 rotation = mousePos - transform.position;

        float rot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, rot);

        timer += Time.deltaTime;

        if (timer > delayBetweenFiring && Input.GetMouseButtonDown(0))
        {
            Instantiate(Bullet, bulletTransform.position, Quaternion.identity);
            timer = 0;
        }
    }

    public void fireRate()
    {
        delayBetweenFiring -= fireRateUpdate;
        Debug.Log("firerate increased");
    }
}
