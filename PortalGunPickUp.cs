using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class PortalGunPickUp : MonoBehaviour {
    public GameObject playerwGun;   //holds a gameObject of player
	
	// Update is called once per frame
	void Update () {
        //rotate in world space
        transform.Rotate(new Vector3(100f, 0f, 0f)*Time.deltaTime);
	}
    private void OnTriggerEnter(Collider other)
    {
        //if player collides with it swap the player model out
        if(other.CompareTag("Player"))
        {
            Component compdestroy = other.GetComponent<RigidbodyFirstPersonController>();
            Destroy(compdestroy);
            other.GetComponent<PickupObject>().dropObject();
            Destroy(other.transform.GetChild(0).gameObject);            
            Destroy(other.gameObject);
            Instantiate(playerwGun, other.transform.position, other.transform.rotation);
            Destroy(gameObject);
        }
    }
}
