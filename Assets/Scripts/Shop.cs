using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] GameObject ShopUI;


    void Update()
    {

        if (Input.GetKeyDown(KeyCode.P) && !ShopUI.activeInHierarchy)
        {
            ShopUI.SetActive(true);
            Time.timeScale = 0;

        }
        else if (Input.GetKeyDown(KeyCode.P) && ShopUI.activeInHierarchy)
        {
            ShopUI.SetActive(false);
            Time.timeScale = 1;
        }

    }



}


