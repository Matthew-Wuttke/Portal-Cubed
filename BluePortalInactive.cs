using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BluePortalInactive : MonoBehaviour {
    public GameObject audioBox;     //gameObject to play sounds
    public GameObject blueActive;   //gameObject to hold active portal
    
    // Use this for initialization
    void Start()
    {
        //play open portal sound
        GameObject clone = Instantiate(audioBox, transform.position, transform.rotation);
        clone.GetComponent<AudioBox>().PlaySoundAtPoint(1);
    }

    // Update is called once per frame
    void Update()
    {
        //find orange portal and if found change to active
        GameObject orange = GameObject.FindGameObjectWithTag("orangePortal");
        if (orange)
        {
            Instantiate(blueActive, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
