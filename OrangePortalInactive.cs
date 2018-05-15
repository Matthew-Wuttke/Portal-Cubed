using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrangePortalInactive : MonoBehaviour {
    public GameObject audioBox;       //gameObject to play sounds
    public GameObject orangeActive;   //gameObject to hold active portal

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
        //find blue portal and if found change to active
        GameObject blue = GameObject.FindGameObjectWithTag("bluePortal");
        if (blue)
        {
            Instantiate(orangeActive, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
