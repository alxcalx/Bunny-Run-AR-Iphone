using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoringSystem : MonoBehaviour
{
    PointManager PointManager;
    


  

    private void OnTriggerEnter(Collider other)
    {

        PointManager.points++;

        Destroy(gameObject);

        
 
       




    }

}
