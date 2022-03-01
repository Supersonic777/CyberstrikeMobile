using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageArea : MonoBehaviour
{
    private GameObject target;
    private float pHealth;
    private int enemyDamage;
    // Start is called before the first frame update
    void Start()
    {
      enemyDamage = GetComponentInParent<Enemy>().damage;
      target = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(GetComponentInParent<Enemy>().health <= 0)
        {
          gameObject.SetActive(false);
        }
    }
    void OnTriggerStay2D(Collider2D player)
    {
      if (player.gameObject.tag == "Player")
      target.GetComponent<PlayerController>().playerHealth -= (enemyDamage * Time.deltaTime);
      //ToDamage();
    }
    void ToDamage()
    {
    //Отнимаем 1ед здоровья пока здоровье есть или пока корутина не будет остановлена
      //target.GetComponent<PlayerController>().playerHealth -= (enemyDamage * Time.deltaTime);
    }
}
