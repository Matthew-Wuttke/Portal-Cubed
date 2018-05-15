using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupAble : MonoBehaviour {
    Vector3 position; //holds position of gameObject
	// Use this for initialization
	void Start () {
        position = transform.position; //set position to starting position
    }

    public void Reset()
    {
        //reset position to starting position
        if(transform.parent != null)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            player.GetComponent<PickupObject>().dropObject();
            transform.position = position;
        }
    }
}
