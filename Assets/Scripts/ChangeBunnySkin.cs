using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeBunnySkin : MonoBehaviour
{
    public Material[] material;
    static Renderer rend;
    int index;
    public GameObject gamescreen;
    public GameObject introscreen;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = material[PlayerPrefs.GetInt("color index")];
    }

    // Update is called once per frame

    public void ChangeToPreviousSkin()
    {
        index--;

        if (index < 0)
        {
            index = 7;
            
            
        }

        rend.sharedMaterial = material[index];
    }
   
    public void ChangeToNextSkin()
    {
        index++;

        if (index > 7)
        {
            index = 0;
           
            
        }

        rend.sharedMaterial = material[index];

    }

    public void SelectColor()
    {

      
        
        PlayerPrefs.SetInt("color index", index);
        SceneManager.LoadScene("Main Scene");
        


    }

}
