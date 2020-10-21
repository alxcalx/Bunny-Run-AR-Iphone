using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scanning : MonoBehaviour
{
    public GameObject movedeviceanimation;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!movedeviceanimation.GetComponent<Animator>().isActiveAndEnabled)
        {
            GetComponent<Text>().enabled = false;

        }
    }
}
