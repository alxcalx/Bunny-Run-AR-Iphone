using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    public Text highscore_text;

    // Start is called before the first frame update
    void Start()
    {
      string highscore_string = PlayerPrefs.GetInt("bestscore").ToString();
      highscore_text.text = highscore_string;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
