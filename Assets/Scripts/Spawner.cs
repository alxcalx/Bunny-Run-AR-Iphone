using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Vector3 spawnValues;
    public GameObject carrot;
    public float spawnWait;
    public float spawnMostWait;
    public float spawnLeastWait;
    public int startwait;

   


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(waitSpawner());
    }

    // Update is called once per frame
    void Update()
    {
        spawnWait = Random.Range(spawnLeastWait, spawnMostWait);
    }


    IEnumerator waitSpawner()
    {
        yield return new WaitForSeconds(startwait);

        while (true)
        {
            
            Vector3 spawnposition = new Vector3 ((Random.Range(-spawnValues.x, spawnValues.x)),(Random.Range(0, 1)),(Random.Range(-spawnValues.z, spawnValues.z))) ;

            Instantiate(carrot, spawnposition + transform.TransformPoint(0, 0, 0), gameObject.transform.rotation);

            yield return new WaitForSeconds(spawnWait);

        }

    }
}
