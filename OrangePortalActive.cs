using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrangePortalActive : PortalActive
{
    public GameObject audioBox;  //gameObject to play sounds
    private GameObject blue;     //gameObject to hold exit for orange portal

    // Update is called once per frame
    void Update()
    {
        //find blue portal and set it as exit
        blue = GameObject.FindGameObjectWithTag("bluePortal");
        if(blue.transform.childCount > 0)
        {
            exit = blue.transform.GetChild(0);
        }        
    }
}