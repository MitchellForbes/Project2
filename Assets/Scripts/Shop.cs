using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Shop : MonoBehaviour
{

    public void shopload()
    {
        GameObject[] State;
        Debug.Log("load shop");
        SceneManager.LoadScene("Shop");
        State = GameObject.FindGameObjectsWithTag("Player");
        State[0].SetActive(false);
    }
}
