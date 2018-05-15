using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPlayerPrefs : MonoBehaviour {
    public GameObject[] levels = new GameObject[3];

	// Use this for initialization
	void Start () {
        //set up buttons on panel
        levels[0].SetActive(true);
        if (PlayerPrefs.GetInt("Level2") == 1)
        {
            levels[1].SetActive(true);
        }
        if (PlayerPrefs.GetInt("Level3") == 1)
        {            
            levels[2].SetActive(true);
        }
    }
}