using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToPlayer : MonoBehaviour
{
    public float rotationSpeed;
    private bool childIsDestroyed = false;
    private GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(GetComponent<Enemy>().health > 0 )
        {
           Vector2 direction = target.transform.position - transform.position;
           float angle = Mathf.Atan2(direction.y,direction.x) * Mathf.Rad2Deg;
           Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
           transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
        }
        else
        {
           if(childIsDestroyed == false)Destroy(transform.GetChild(0).gameObject);
           childIsDestroyed = true;
        }
    }
}
