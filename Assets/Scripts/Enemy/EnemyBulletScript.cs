using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletScript : MonoBehaviour
{
   public GameObject hitEffect;//назначаем объект который выступит эффектом после попадания
   private float damage;

   void Start()
   {
      damage = GameObject.FindGameObjectWithTag("Gun").GetComponent<GunController>().gunDamage;
   }
   
   void OnCollisionEnter2D(Collision2D collision)
   {
      if(collision.gameObject.tag != "Bullet" && collision.gameObject.tag != "Player")
      {
        if(collision.gameObject.tag == "Player")
        {
           collision.gameObject.GetComponent<PlayerController>().playerHealth -= damage;
        }
        GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);//местоположение возникновения эффекта
        Destroy(effect, 0.1f);//уничтожаем эффект после данного количества времени
        Destroy(gameObject);
      }

   }
   void Update()
   {
      Destroy(gameObject, 2.0f); //предполагается удаление объекта если он не попал в цель
   }
}
