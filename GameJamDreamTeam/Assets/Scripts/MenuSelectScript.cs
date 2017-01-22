using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class MenuSelectScript : MonoBehaviour
{

    public void ButtonMenu(Button button)
    {
        if (button.name == "level1")
        {
            Application.LoadLevel("niveau1bis");
        }
        else if (button.name == "level2")
        {
            Application.LoadLevel("niveau2");
        }
        else if (button.name == "level3")
        {
            Application.LoadLevel("niveau3");
        }
        else if (button.name == "back")
        {
            Application.LoadLevel("MainMenu");
        }
    }
}
