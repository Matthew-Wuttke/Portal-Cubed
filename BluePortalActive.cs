using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BluePortalActive :PortalActive {
    public GameObject audioBox; //gameObject to play sounds
    private GameObject orange;  //gameObject to hold exit


    // Update is called once per frame
    void Update()
    {
        //set exit when entered to orange portal
        orange = GameObject.FindGameObjectWithTag("orangePortal");
        if(orange.transform.childCount > 0)
        {
            exit = orange.transform.GetChild(0);
        }
    }
}
