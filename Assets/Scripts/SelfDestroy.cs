using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestroy : MonoBehaviour
{
    private float timeToDestroy = 180;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Invoke("Destroy", timeToDestroy);
    }
    void Hide() 
    {
        gameObject.GetComponent<SpriteRenderer>().color -= new Color(0,0,0,0.01f);
    }
    void Destroy()
    {
        Destroy(gameObject);
    }
}
