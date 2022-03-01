using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float spawnInSecounds = 3.0f;
    //public Transform spawnPosition;
    public GameObject objectToSpawn;
    public Transform[] transformList;
    private int transformListLenght;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnGO());
        transformListLenght = transformList.Length;
    }
    void Repeat()
    {
        StartCoroutine(SpawnGO());
    }

    IEnumerator SpawnGO()
    {
        yield return new WaitForSeconds(spawnInSecounds);
        Instantiate(objectToSpawn, transformList[Random.Range(0,transformListLenght-1)].position, Quaternion.identity);
        Repeat();
    }
}
