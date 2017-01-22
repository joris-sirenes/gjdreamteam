using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

    public void ButtonMenu(Button button)
    {
        if(button.name == "Button_new")
        {
            Application.LoadLevel("niveau1bis");
        }
        else if(button.name == "Button_select")
        {
            Application.LoadLevel("MenuSelectLevel");
        }
        else if(button.name == "Button_quit")
        {
            Application.Quit();
        }
    }
}
