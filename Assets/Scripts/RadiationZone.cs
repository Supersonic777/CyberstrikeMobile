using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadiationZone : MonoBehaviour
{
    public float radiationZoneDamage;
    private GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerStay2D(Collider2D collision)
    {
       if(collision.gameObject.tag == "Player")
       {
          target.GetComponent<PlayerController>().playerHealth -= (radiationZoneDamage * Time.deltaTime);
       }
    }
}
