using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kamikaze : Enemy
{
  public GameObject pointLight;
    // Start is called before the first frame update
  void Start()
  {
    player = GameObject.FindGameObjectWithTag("Player");
    target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        
  }

  // Update is called once per frame
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
    if(health > 0)
    {
      if(collision.gameObject.tag == "Player")
      {
        Destroy(gameObject);
        player.GetComponent<PlayerController>().playerHealth -= damage;
      }
    }
    else
    {
      pointLight.SetActive(false);
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

