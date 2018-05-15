using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blocker : MonoBehaviour {
    public GameObject audioBox;     //gameObject to play sounds
    GameObject[] switches;          //list of gameObjects to determine the turn off
    GameObject blocker;             //what is hidden after switches are turned on
    int counter = 0;                
 
	// Use this for initialization
	void Start () {
        switches = GameObject.FindGameObjectsWithTag("Button");
        blocker = transform.GetChild(0).gameObject;
	}
	
	// Update is called once per frame
	void Update () {
        //if all switches are true, deactivate door
		if(checkSwitches()== true)
        {
            counter++;
            if(counter == 1)
            {
                GameObject clone = Instantiate(audioBox, transform.position, transform.rotation);
                clone.GetComponent<AudioBox>().PlaySound(4);
            }
            blocker.SetActive(false);
        }
        else
        {
            counter = 0;
            blocker.SetActive(true);
        }
	}

    //are all switches activated
    bool checkSwitches()
    {
        Switch check;
        foreach (GameObject s in switches)
        {
            check = s.GetComponent<Switch>();
            if (check.getActivation() != true)
            {
                return false;
            }
        }
        return true;
    }
}
