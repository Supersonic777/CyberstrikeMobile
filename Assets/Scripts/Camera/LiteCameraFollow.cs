using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiteCameraFollow : MonoBehaviour
{
    public GameObject objectToFollow;
    private float posX;
    private float posY;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        posX = objectToFollow.transform.position.x;
        posY = objectToFollow.transform.position.y;
        gameObject.transform.position = new Vector3(posX,posY,-10);
    }
}
