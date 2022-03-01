using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Medkit : MonoBehaviour
{
    public int HP = 25;
    private GameObject playerHP;
    void Start()
    {

    }

    void Update()
    {
        playerHP = GameObject.FindGameObjectWithTag("Player");
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
         if(collision.gameObject.tag == "Player")
         {
               if(playerHP.GetComponent<PlayerController>().playerHealth < 75)
               {
                playerHP.GetComponent<PlayerController>().playerHealth +=HP;
                Destroy(gameObject);
               }
               if(playerHP.GetComponent<PlayerController>().playerHealth >= 75 && playerHP.GetComponent<PlayerController>().playerHealth < 100)
               {
                   playerHP.GetComponent<PlayerController>().playerHealth += 100-playerHP.GetComponent<PlayerController>().playerHealth;
                   Destroy(gameObject);
               }

         }
    }
}
