using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPack : MonoBehaviour
{
    private GameObject gun;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
           gun = GameObject.FindGameObjectWithTag("Gun");
           gun.GetComponent<GunController>().allAmmo += gun.GetComponent<GunController>().ammoInMag;
           Destroy(gameObject);
        }
    }
}
