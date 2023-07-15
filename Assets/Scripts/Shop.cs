using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;




/* to anyone reading this 
 * this script was an actual nightmare to write 
 * it probably is filled with lots of small bugs 
 * but right now i cant care as i want other functions to 
 * be better before we continue 
 * but just not 
 * i dont want to write any more shop managers for games as 
 * they are the most tedious bull crap ever 
 * thank you 
 * 
 * Joshua G
 */



//i hearby name this the magic code TOUCHING THE MAGIC CODE WILL BE EXECUTION cause i dont have any idea how it works anymore and really dont want to come through this 


public class Shop : MonoBehaviour
{
    [SerializeField] GameObject ShopUI;

    public static Shop instance;

    public TMP_Text MoneyText;

    // fancy way of makeing lots of variable declerations without using an array 
    

    //text slots for the price
    public TMP_Text Slot2, Slot3, Slot4, Slot5, Slot6, Slot7, Slot8;

    //this is the text after purchesing 
    public TMP_Text Slot2text, Slot3text, Slot4text, Slot5text, Slot6text, Slot7text, Slot8text;

    public TMP_Dropdown Slot2Drop, Slot3Drop, Slot4Drop, Slot5Drop, Slot6Drop, Slot7Drop, Slot8Drop;

    //not normal naming convention but i dont care im tired and just want to get this script done
    public bool a, b, c, d, e, f, g,h;


    public GunTypes gun1,gun2,gun3,gun4,gun5,gun6,gun7;

    //GOD SAVE YOUR SOUL IF YOU WANT TO READ THIS
    // https://www.youtube.com/watch?v=haW_ruZ_Be8&list=RDa_426RiwST8&index=25

    //THIS CODE IS HORENDOUSE BUT IT WORKS 
    public void BuySlot(int id)
    {
        //all this does is remove money from the player and make the drop down disapear
        
        switch (id)
        {
            case 0:
                switch(Slot2Drop.value)
                {
                    case 0:
                        Debug.Log("MINIGUN");
                        Slot2.text = 200.ToString();
                        if(MovePlayer.instance.MONEY - 200 >= 0 && !a)
                        {
                            MovePlayer.instance.MONEY -= 200;
                            Slot2text.text = "MiniGun";
                            Slot2Drop.gameObject.SetActive(false);
                            a = true;
                            gun1 = GunTypes.minigun;


                        }
                        break;
                    case 1:
                        Debug.Log("GrenadeLauncher");
                        Slot2.text = 400.ToString();
                        if (MovePlayer.instance.MONEY - 400 >= 0 && !a)
                        {
                            MovePlayer.instance.MONEY -= 400;
                            Slot2text.text = "Grenade";
                            Slot2Drop.gameObject.SetActive(false);
                            a = true;
                            gun1 = GunTypes.grenadelauncher;
                        }
                        break;
                    case 2:
                        Debug.Log("FlameThrower");
                        Slot2.text = 150.ToString();
                        if (MovePlayer.instance.MONEY - 150 >= 0 && !a)
                        {
                            MovePlayer.instance.MONEY -= 150;
                            Slot2text.text = "Flame";
                            Slot2Drop.gameObject.SetActive(false);
                            a = true;
                            gun1 = GunTypes.flamerthrower;
                        }
                        break;
                    case 3:
                        Debug.Log("Shotgun");
                        Slot2.text = 250.ToString();
                        if (MovePlayer.instance.MONEY - 250 >= 0 && !a)
                        {
                            MovePlayer.instance.MONEY -= 250;
                            Slot2text.text = "Shotgun";
                            Slot2Drop.gameObject.SetActive(false);
                            a = true;
                            gun1 = GunTypes.shotgun;
                        }
                        break;
                }
                
                break;

            case 1:
                switch (Slot3Drop.value)
                {
                    case 0:
                        Debug.Log("MINIGUN");
                        Slot3.text = 200.ToString();
                        if (MovePlayer.instance.MONEY - 200 >= 0 && !b)
                        {
                            MovePlayer.instance.MONEY -= 200;
                            Slot3text.text = "MiniGun";
                            Slot3Drop.gameObject.SetActive(false);
                            b = true;
                            gun2 = GunTypes.minigun;
                        }
                        break;
                    case 1:
                        Debug.Log("GrenadeLauncher");
                        Slot3.text = 400.ToString();
                        if (MovePlayer.instance.MONEY - 400 >= 0 && !b)
                        {
                            MovePlayer.instance.MONEY -= 400;
                            Slot3text.text = "Grenade";
                            Slot3Drop.gameObject.SetActive(false);
                            b = true;
                            gun2 = GunTypes.grenadelauncher;
                        }
                        break;
                    case 2:
                        Debug.Log("FlameThrower");
                        Slot3.text = 150.ToString();
                        if (MovePlayer.instance.MONEY - 150 >= 0 && !b)
                        {
                            MovePlayer.instance.MONEY -= 150;
                            Slot3text.text = "Flame";
                            Slot3Drop.gameObject.SetActive(false);
                            b = true;
                            gun2 = GunTypes.flamerthrower;
                        }
                        break;
                    case 3:
                        Debug.Log("Shotgun");
                        Slot3.text = 250.ToString();
                        if (MovePlayer.instance.MONEY - 250 >= 0 && !b)
                        {
                            MovePlayer.instance.MONEY -= 250;
                            Slot3text.text = "Shotgun";
                            Slot3Drop.gameObject.SetActive(false);
                            b = true;
                            gun2 = GunTypes.shotgun;
                        }
                        break;
                }

                break;

            case 2:
                switch (Slot4Drop.value)
                {
                    case 0:
                        Debug.Log("MINIGUN");
                        Slot4.text = 200.ToString();
                        if (MovePlayer.instance.MONEY - 200 >= 0 && !c)
                        {
                            MovePlayer.instance.MONEY -= 200;
                            Slot4text.text = "MiniGun";
                            Slot4Drop.gameObject.SetActive(false);
                            c = true;
                            gun3 = GunTypes.minigun;
                        }
                        break;
                    case 1:
                        Debug.Log("GrenadeLauncher");
                        Slot4.text = 400.ToString();
                        if (MovePlayer.instance.MONEY - 400 >= 0 && !c)
                        {
                            MovePlayer.instance.MONEY -= 400;
                            Slot4text.text = "Grenade";
                            Slot4Drop.gameObject.SetActive(false);
                            c = true;
                            gun3 = GunTypes.grenadelauncher;
                        }
                        break;
                    case 2:
                        Debug.Log("FlameThrower");
                        Slot4.text = 150.ToString();
                        if (MovePlayer.instance.MONEY - 150 >= 0 && !c)
                        {
                            MovePlayer.instance.MONEY -= 150;
                            Slot4text.text = "Flame";
                            Slot4Drop.gameObject.SetActive(false);
                            c = true;
                            gun3 = GunTypes.flamerthrower;
                        }
                        break;
                    case 3:
                        Debug.Log("Shotgun");
                        Slot4.text = 250.ToString();
                        if (MovePlayer.instance.MONEY - 250 >= 0 && !c)
                        {
                            MovePlayer.instance.MONEY -= 250;
                            Slot4text.text = "Shotgun";
                            Slot4Drop.gameObject.SetActive(false);
                            c = true;
                            gun3 = GunTypes.shotgun;
                        }
                        break;
                }

                break;

            case 3:
                switch (Slot5Drop.value)
                {
                    case 0:
                        Debug.Log("MINIGUN");
                        Slot5.text = 200.ToString();
                        if (MovePlayer.instance.MONEY - 200 >= 0 && !d)
                        {
                            MovePlayer.instance.MONEY -= 200;
                            Slot5text.text = "MiniGun";
                            Slot5Drop.gameObject.SetActive(false);
                            d = true;
                            gun4 = GunTypes.minigun;
                        }
                        break;
                    case 1:
                        Debug.Log("GrenadeLauncher");
                        Slot5.text = 400.ToString();
                        if (MovePlayer.instance.MONEY - 400 >= 0 && !d)
                        {
                            MovePlayer.instance.MONEY -= 400;
                            Slot5text.text = "Grenade";
                            Slot5Drop.gameObject.SetActive(false);
                            d = true;
                            gun4 = GunTypes.grenadelauncher;
                        }
                        break;
                    case 2:
                        Debug.Log("FlameThrower");
                        Slot5.text = 150.ToString();
                        if (MovePlayer.instance.MONEY - 150 >= 0 && !d)
                        {
                            MovePlayer.instance.MONEY -= 150;
                            Slot5text.text = "Flame";
                            Slot5Drop.gameObject.SetActive(false);
                            d = true;
                            gun4 = GunTypes.flamerthrower;
                        }
                        break;
                    case 3:
                        Debug.Log("Shotgun");
                        Slot5.text = 250.ToString();
                        if (MovePlayer.instance.MONEY - 250 >= 0 && !d)
                        {
                            MovePlayer.instance.MONEY -= 250;
                            Slot5text.text = "Shotgun";
                            Slot5Drop.gameObject.SetActive(false);
                            d = true;
                            gun4 = GunTypes.shotgun;
                        }
                        break;
                }

                break;

            case 4:
                switch (Slot6Drop.value)
                {
                    case 0:
                        Debug.Log("MINIGUN");
                        Slot6.text = 200.ToString();
                        if (MovePlayer.instance.MONEY - 200 >= 0 && !f)
                        {
                            MovePlayer.instance.MONEY -= 200;
                            Slot6text.text = "MiniGun";
                            Slot6Drop.gameObject.SetActive(false);
                            f = true;
                            gun5 = GunTypes.minigun;
                        }
                        break;
                    case 1:
                        Debug.Log("GrenadeLauncher");
                        Slot6.text = 400.ToString();
                        if (MovePlayer.instance.MONEY - 400 >= 0 && !f)
                        {
                            MovePlayer.instance.MONEY -= 400;
                            Slot6text.text = "Grenade";
                            Slot6Drop.gameObject.SetActive(false);
                            f= true;
                            gun5 = GunTypes.grenadelauncher;
                        }
                        break;
                    case 2:
                        Debug.Log("FlameThrower");
                        Slot6.text = 150.ToString();
                        if (MovePlayer.instance.MONEY - 150 >= 0 && !f)
                        {
                            MovePlayer.instance.MONEY -= 150;
                            Slot6text.text = "Flame";
                            Slot6Drop.gameObject.SetActive(false);
                            f= true;
                            gun5 = GunTypes.flamerthrower;
                        }
                        break;
                    case 3:
                        Debug.Log("Shotgun");
                        Slot6.text = 250.ToString();
                        if (MovePlayer.instance.MONEY - 250 >= 0 && !f)
                        {
                            MovePlayer.instance.MONEY -= 250;
                            Slot6text.text = "Shotgun";
                            Slot6Drop.gameObject.SetActive(false);
                            f = true;
                            gun5 = GunTypes.shotgun;
                        }
                        break;
                }

                break;

            case 5:
                switch (Slot7Drop.value)
                {
                    case 0:
                        Debug.Log("MINIGUN");
                        Slot7.text = 200.ToString();
                        if (MovePlayer.instance.MONEY - 200 >= 0 && !g)
                        {
                            MovePlayer.instance.MONEY -= 200;
                            Slot7text.text = "MiniGun";
                            Slot7Drop.gameObject.SetActive(false);
                            g = true;
                            gun6 = GunTypes.minigun;
                        }
                        break;
                    case 1:
                        Debug.Log("GrenadeLauncher");
                        Slot7.text = 400.ToString();
                        if (MovePlayer.instance.MONEY - 400 >= 0 && !g)
                        {
                            MovePlayer.instance.MONEY -= 400;
                            Slot7text.text = "Grenade";
                            Slot7Drop.gameObject.SetActive(false);
                            g = true;
                            gun6 = GunTypes.grenadelauncher;
                        }
                        break;
                    case 2:
                        Debug.Log("FlameThrower");
                        Slot7.text = 150.ToString();
                        if (MovePlayer.instance.MONEY - 150 >= 0 && !g)
                        {
                            MovePlayer.instance.MONEY -= 150;
                            Slot7text.text = "Flame";
                            Slot7Drop.gameObject.SetActive(false);
                            g = true;
                            gun6 = GunTypes.flamerthrower;
                        }
                        break;
                    case 3:
                        Debug.Log("Shotgun");
                        Slot7.text = 250.ToString();
                        if (MovePlayer.instance.MONEY - 250 >= 0 && !g)
                        {
                            MovePlayer.instance.MONEY -= 250;
                            Slot7text.text = "Shotgun";
                            Slot7Drop.gameObject.SetActive(false);
                            g = true;
                            gun6 = GunTypes.shotgun;
                        }
                        break;
                }

                break;

            case 6:
                switch (Slot8Drop.value)
                {
                    case 0:
                        Debug.Log("MINIGUN");
                        Slot8.text = 200.ToString();
                        if (MovePlayer.instance.MONEY - 200 >= 0 && !h)
                        {
                            MovePlayer.instance.MONEY -= 200;
                            Slot8text.text = "MiniGun";
                            Slot8Drop.gameObject.SetActive(false);
                            h = true;
                            gun7 = GunTypes.minigun;
                        }
                        break;
                    case 1:
                        Debug.Log("GrenadeLauncher");
                        Slot8.text = 400.ToString();
                        if (MovePlayer.instance.MONEY - 400 >= 0 && !h)
                        {
                            MovePlayer.instance.MONEY -= 400;
                            Slot8text.text = "Grenade";
                            Slot8Drop.gameObject.SetActive(false);
                            h = true;
                              gun7 = GunTypes.grenadelauncher;
                        }
                        break;
                    case 2:
                        Debug.Log("FlameThrower");
                        Slot8.text = 150.ToString();
                        if (MovePlayer.instance.MONEY - 150 >= 0 && !h)
                        {
                            MovePlayer.instance.MONEY -= 150;
                            Slot8text.text = "Flame";
                            Slot8Drop.gameObject.SetActive(false);
                               h = true;
                            gun7 = GunTypes.flamerthrower;
                        }
                        break;
                    case 3:
                        Debug.Log("Shotgun");
                        Slot8.text = 250.ToString();
                        if (MovePlayer.instance.MONEY - 250 >= 0 && !h)
                        {
                            MovePlayer.instance.MONEY -= 250;
                            Slot8text.text = "Shotgun";
                            Slot8Drop.gameObject.SetActive(false);
                                h = true;
                            gun7 = GunTypes.shotgun;
                        }
                        break;
                }

                break;


        }
    }

    private void Start()
    {
        instance = this;
    }

    void Update()
    {


        switch (Slot2Drop.value)
        {
            case 0:
                Slot2.text = 200.ToString();
                break;
            case 1:
                Slot2.text = 400.ToString();
                break;
            case 2:
                Slot2.text = 150.ToString();
                break;
            case 3:
                Slot2.text = 250.ToString();
                break;
        }

        switch (Slot3Drop.value)
        {
            case 0:
                Slot3.text = 200.ToString();
                break;
            case 1:
                Slot3.text = 400.ToString();
                break;
            case 2:
                Slot3.text = 150.ToString();
                break;
            case 3:
                Slot3.text = 250.ToString();
                break;
        }

        switch (Slot4Drop.value)
        {
            case 0:
                Slot4.text = 200.ToString();
                break;
            case 1:
                Slot4.text = 400.ToString();
                break;
            case 2:
                Slot4.text = 150.ToString();
                break;
            case 3:
                Slot4.text = 250.ToString();
                break;
        }

        switch (Slot5Drop.value)
        {
            case 0:
                Slot5.text = 200.ToString();
                break;
            case 1:
                Slot5.text = 400.ToString();
                break;
            case 2:
               
                Slot5.text = 150.ToString();
                break;
            case 3:
             
                Slot5.text = 250.ToString();
                break;
        }

        switch (Slot6Drop.value)
        {
            case 0:
               
                Slot6.text = 200.ToString();
                break;
            case 1:
         
                Slot6.text = 400.ToString();
                break;
            case 2:
              
                Slot6.text = 150.ToString();
                break;
            case 3:
        
                Slot6.text = 250.ToString();
                break;
        }

        switch (Slot7Drop.value)
        {
            case 0:
               
                Slot7.text = 200.ToString();
                break;
            case 1:
               
                Slot7.text = 400.ToString();
                break;
            case 2:
             
                Slot7.text = 150.ToString();
                break;
            case 3:
              
                Slot7.text = 250.ToString();
                break;
        }

        switch (Slot8Drop.value)
        {
            case 0:
          
                Slot8.text = 200.ToString();
                break;
            case 1:
              
                Slot8.text = 400.ToString();
                break;
            case 2:
             
                Slot8.text = 150.ToString();
                break;
            case 3:
            
                Slot8.text = 250.ToString();
                break;
        }


        if (Input.GetKeyDown(KeyCode.P) && !ShopUI.activeInHierarchy)
        {
            ShopUI.SetActive(true);
            Time.timeScale = 0f;

        }
        else if (Input.GetKeyDown(KeyCode.P) && ShopUI.activeInHierarchy)
        {
            ShopUI.SetActive(false);
            Time.timeScale = 1;
        }

    }
}
