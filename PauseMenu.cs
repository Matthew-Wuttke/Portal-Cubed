using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {
    public GameObject player;   //holds player gameObject
    private GameObject pMenu;   //holds pause menu gameObject
    private bool isPaused;       //holds if game is paused
	// Use this for initialization
	void Start () {
        pMenu = transform.GetChild(0).gameObject;
        isPaused = false;
    }
	
	// Update is called once per frame
	void Update () {        
        Cursor.visible = false;
        if (player == null)
            player = GameObject.FindGameObjectWithTag("Player");

		if(Input.GetButtonDown("Cancel"))
        {
            isPaused = !isPaused;
        }
        //if game is paused, hide player and show pause menu
        if (isPaused)
        {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
            player.SetActive(false);
            pMenu.SetActive(true);
        }
        //if game is not paused, show player and hide pause menu
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            pMenu.SetActive(false);
            player.SetActive(true);            
        }
	}
}
