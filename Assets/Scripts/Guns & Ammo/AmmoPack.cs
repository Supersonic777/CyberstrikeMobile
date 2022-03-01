using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPack : MonoBehaviour
{
    public int giveAmmo;
    private GameObject gun;
    void Start()
    {
       gun = GameObject.FindGameObjectWithTag("Gun");
       giveAmmo = gun.GetComponent<GunController>().ammoInMag;
    }

    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            gun.GetComponent<GunController>().allAmmo += giveAmmo;
        }
    }
}
