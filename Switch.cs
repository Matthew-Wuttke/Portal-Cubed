using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour {

    private bool activated;     //is the switch activated
    
    void Start () {
         activated = false;
    }
    
    //turn activation on
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("CompCube"))
        {
            activated = true;
        }
    }
    
    //turn activation off
    private void OnTriggerExit(Collider other)
    {
        activated = false;
    }
    
    //allow scripts to access activation
    public bool getActivation()
    {
        return activated;
    }
}
