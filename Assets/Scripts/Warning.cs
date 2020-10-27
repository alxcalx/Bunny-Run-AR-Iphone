using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Warning : MonoBehaviour
{
    public GameObject warning;
    public GameObject screenspaceUI;
    // Start is called before the first frame update


    public void WarningDialog()
    {
        warning.SetActive(false);
        screenspaceUI.SetActive(true);

    }
}
