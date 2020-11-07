using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation.Samples;
public class Enemy : MonoBehaviour
{
    GameObject player;
    public static float speed = .3f;
   

   

    // Start is called before the first frame update
    void Start()
    {

        player = PlaceMultipleObjectsOnPlane.spawnedObject;
     // speed = Mathf.Log(PointManager.points);
        

    }

    // Update is called once per frame
    void Update()
    {
if(Instructions.startgame == true){

        if (CollisionDetection.gameend == false)
        {
            speed = .3f;
            //the movement of the enemy
            transform.LookAt(player.transform);
            Quaternion targetRotation = Quaternion.LookRotation(player.transform.position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 1 * Time.deltaTime);
            transform.position += transform.forward * speed * Time.deltaTime;

        }

        if(CollisionDetection.gameend == true )
        {
            speed = 0;

            transform.Rotate(0, 0, 0, Space.World);

            
        }}

else {
 speed = 0;
}

      

     



        

   


       
        
    }

  
    
}
