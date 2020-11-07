using UnityEngine;
using System.Collections;
using UnityEngine.iOS;
using UnityEngine.XR.ARFoundation.Samples;

public class Instructions : MonoBehaviour
{
public GameObject panel;
public static bool startgame;
int gameopen;


void Start() {

if(PlayerPrefs.GetInt("GameOpen") == 0){

panel.SetActive(true);
startgame = false;
}






}



public void StartGame(){

gameopen ++;panel.SetActive(false);
startgame = true; 
PlayerPrefs.SetInt("GameOpen", gameopen);

}
}
