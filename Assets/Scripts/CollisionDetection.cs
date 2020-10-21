using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
  
    public static bool gameend = false;
    // Start is called before the first frame update
  


    private void OnTriggerEnter(Collider other)
    {

        if(other.gameObject.tag =="Enemy")


        
            gameend = true;
        
 

    }
}
