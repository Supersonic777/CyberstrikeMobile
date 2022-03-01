using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
  public enum enemyTypeList
  {
  Light,
  Medium,
  Heavy,
  SuperHeavy
  };
  public enemyTypeList enemyType;
  public float speed;
  public float armor;
  public float health;
  public int damage = 5;
  public float damageRate;
  public float attackDistance;
  public int givePointsWhenDie;
  public float timeToSelfDestroy;
  public GameObject blood;

  private GameObject player;
  private Transform target;
    //private PlayerController giveDamage = new PlayerController();
  void Start()
  {
    switch (enemyType)
    {
      case enemyTypeList.Light:
      givePointsWhenDie +=1;
      break;
      case enemyTypeList.Medium:
      givePointsWhenDie +=3;
      break;
      case enemyTypeList.Heavy:
      givePointsWhenDie +=8;
      break;
      case enemyTypeList.SuperHeavy:
      givePointsWhenDie +=20;
      break;
    }
    player = GameObject.FindGameObjectWithTag("Player");
    target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
  }

  void Update()
  {
    if(health > 0)
    {
      if(Vector2.Distance(transform.position, target.position) > attackDistance)
      {
      transform.position = Vector2.MoveTowards(transform.position,target.position ,speed * Time.deltaTime);
      }
    }
  }
  void OnCollisionEnter2D(Collision2D collision)
  {
    if(collision.gameObject.tag == "Bullet")
    {
      if(health <=0)
      {
      player.GetComponent<HightScore>().score += givePointsWhenDie;
      gameObject.GetComponent<CircleCollider2D>().enabled = false;
      gameObject.GetComponent<SpriteRenderer>().color = Color.grey;
      gameObject.GetComponent<SpriteRenderer>().sortingOrder -= 1;
      Invoke("DestroyEnemy", timeToSelfDestroy);
      //В параметре следующиго инвока предусморенно /2 по причине что исчезновение начнётся в середине
      //общего времени до уничтожения объекта 
      InvokeRepeating("HideEnemy", timeToSelfDestroy/2, timeToSelfDestroy/60/1.6f/2);
      }
      blood.transform.position = gameObject.transform.position;
      blood.transform.Rotate(0,0,Random.Range(-180,180));
      Instantiate(blood, gameObject.transform.position, blood.transform.rotation);
    }
  }
  void FarDamage()
  {

  }
  //destroy enemy object when work
  void HideEnemy()
  {
    gameObject.GetComponent<SpriteRenderer>().color -= new Color(0,0,0,0.01f);
  }
  void DestroyEnemy()
  {
    Destroy(gameObject);
  }
}

