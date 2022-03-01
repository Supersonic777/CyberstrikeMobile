using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyDrink : MonoBehaviour
{
    public float giveStamina = 0.25f;
    public GameObject PlayerStamina;

    void Start()
    {
      PlayerStamina = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if(PlayerStamina.GetComponent<PlayerController>().staminaFill < 0.75f)
            {
            PlayerStamina.GetComponent<PlayerController>().staminaFill +=giveStamina;
            Destroy(gameObject);
            }
            if(PlayerStamina.GetComponent<PlayerController>().staminaFill >= 0.75f && PlayerStamina.GetComponent<PlayerController>().staminaFill < 1.0f)
            {
            PlayerStamina.GetComponent<PlayerController>().staminaFill += PlayerStamina.GetComponent<PlayerController>().staminaFill;
            Destroy(gameObject);
            }

        }
    }
}
