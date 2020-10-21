using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.ARFoundation.Samples;

public class GameOver : MonoBehaviour
{
    public GameObject continebutton;
    public GameObject gameoverUI;
    public GameObject playermovement;
   
 

    // Update is called once per frame
    void Update()
    {
         
       if(CollisionDetection.gameend == true && Ad.WatchMax == 0)
        {
          
            
                gameoverUI.SetActive(true);
                continebutton.SetActive(true);

            
          
      
            playermovement.SetActive(false);

            if (PointManager.points > PlayerPrefs.GetInt("bestscore"))
            {
                PlayerPrefs.SetInt("bestscore", PointManager.points);

            }


            
            
            
        }

        if (CollisionDetection.gameend == true && Ad.WatchMax == 1)
        {


            gameoverUI.SetActive(true);
            continebutton.SetActive(false);




            playermovement.SetActive(false);

            if (PointManager.points > PlayerPrefs.GetInt("bestscore"))
            {
                PlayerPrefs.SetInt("bestscore", PointManager.points);

            }





        }

        if (CollisionDetection.gameend == false)
        {

            playermovement.SetActive(true);
            gameoverUI.SetActive(false);
            continebutton.SetActive(false);

            


        }

       
    }


    public void QuitGame()
    {

        Ad.ShowInterstitialAd();
        Ad.WatchMax = 0;
        SceneManager.LoadScene("Main Menu");
        PointManager.points = 0;
        CollisionDetection.gameend = false;
    }

    public void TryAgain()
    {
        Ad.ShowInterstitialAd();
        Ad.WatchMax = 0;
        SceneManager.LoadScene("Main Scene");
        PointManager.points = 0;
        CollisionDetection.gameend = false;
    }


}
