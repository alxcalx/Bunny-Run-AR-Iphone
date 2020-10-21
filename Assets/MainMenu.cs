using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour

{
    public GameObject nickname;
    public InputField input;
    //static string nickname_text;
    public GameObject mainmenu_buttons;

    // Start is called before the first frame update
   public void MainScene()
    {
        SceneManager.LoadScene("Main Scene");

    }

    public void MainMenuScene()
    {
        Debug.Log("Main Menu");
        SceneManager.LoadScene("Main Menu");
    }

    public void GIFSearch()
    {

        SceneManager.LoadScene("Search GIF");
    }

    public void Leaderboard()
    {
        SceneManager.LoadScene("Leaderboard");

    }


   public void Quit()
    {
        Application.Quit();

    }


    public void Nickname()
    {

        nickname.SetActive(true);

        mainmenu_buttons.SetActive(false);


    }

/*
    public void Submit_Nickname()
    {
        input.text = nickname_text;


    }

    */
}
