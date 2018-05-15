using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuLoadLevel : MonoBehaviour {
    //loads a scene from manager
    public void loadLevel(int level)
    {
        SceneManager.LoadScene(level);
    }
}
