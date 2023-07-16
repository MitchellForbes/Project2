using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChange : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("hit collider");
        if (other.CompareTag("Player"))
        {
            Debug.Log("load shop");
            SceneManager.LoadScene("Shop");
        }
    }
}
