using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{

    public GameObject restartDialog;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void openrestartDialog()
    {

        restartDialog.SetActive(true);

    }

    public void closerestartDialog()
    {

        restartDialog.SetActive(false);
    }

    public void restartScene()
    {
        closerestartDialog();
        SceneManager.LoadScene("Main Scene");
        PointManager.points = 0;

    }

    
}
