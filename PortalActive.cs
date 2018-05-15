using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class PortalActive : MonoBehaviour {
    protected static bool canPort = true;   //holds if the player can port through it
    protected Transform exit;               //holds the exit
    

    protected void OnTriggerEnter(Collider other)
    {
        //if the player walks into it, turn off the ability to port.
        if (other.CompareTag("Player"))
        {
            if (exit != null)
            {
                canPort = false;
                other.transform.position = exit.position;
                if (exit.parent.transform.rotation.y == transform.rotation.y)
                {
                    other.transform.Rotate(other.transform.eulerAngles.x, (other.transform.eulerAngles.y +180), other.transform.eulerAngles.z);
                }
                else
                {             
                    other.transform.rotation = transform.rotation;
                }                
            }
        }
    }
    protected void OnTriggerExit(Collider other)
    {
        //if the player walks out of the portal, they can port back
        if (other.CompareTag("Player"))
        {
            canPort = true;
        }
    }
}
