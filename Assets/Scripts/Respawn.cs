using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation.Samples;

public class Respawn : MonoBehaviour
{
    public GameObject camera;
    GameObject bunny;
    float distance = 1;
    

    // Start is called before the first frame update
    void Start()
    {
        bunny = PlaceMultipleObjectsOnPlane.spawnedObject;
    }

    public void RespawnObject()
    {
        Vector3 newPos = new Vector3(0, PlaceMultipleObjectsOnPlane.hitPose.position.y, 0);
        bunny.transform.position = camera.transform.position + newPos + camera.transform.forward * distance;
        bunny.transform.Rotate(0, 0, 0, Space.World);

    }

}
