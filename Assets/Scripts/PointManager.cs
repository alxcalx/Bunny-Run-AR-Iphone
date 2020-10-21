using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointManager : MonoBehaviour


{
    public GameObject scoreText;
    public static int points = 0;

    void Update()
    {
        scoreText.GetComponent<Text>().text = points.ToString();

       

    }
}
