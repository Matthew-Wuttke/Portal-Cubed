using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuOnClick : MonoBehaviour
{
    //load to MainMenu
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
