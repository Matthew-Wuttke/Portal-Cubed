using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupObject : MonoBehaviour {
    public float distance;       //distance from the camera to the object
    GameObject mainCamera;       //holds the camera
    bool carrying;               //am I carrying something
    GameObject carriedObject;    //what am I carrying
    PortalGun pGun;              //holds the portal gun

	// Use this for initialization
	void Start () {
        mainCamera = GameObject.FindWithTag("MainCamera");  //set the main camera
        pGun = gameObject.GetComponent<PortalGun>();        //set the portal gun
    }
	
	// Update is called once per frame
	void Update () {
        if (carrying)   //if I am carrying 
        {
            carry(carriedObject);
            Physics.IgnoreCollision(carriedObject.transform.GetComponent<Collider>(), GetComponent<Collider>());
            checkDrop();
        }
        else            //otherwise check to see if they can pickup
        {
            pickup();
        }	
	}
    void carry(GameObject go) //set position of object to be distance away from camera
    {
        go.GetComponent<Rigidbody>().position = mainCamera.transform.position + mainCamera.transform.forward * distance;
        
    }

    void pickup()
    {
        if (Input.GetButtonUp("Interaction"))   //if they pushed the button, 
        {
            if(mainCamera == null) //check for camera
            {
                mainCamera = GameObject.FindWithTag("MainCamera");
            }                
            int x = Screen.width / 2;
            int y = Screen.height / 2;
            Ray ray = mainCamera.GetComponent<Camera>().ScreenPointToRay(new Vector3(x, y));
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit)) //did the raycast hit anything
            {
                PickupAble p = hit.collider.GetComponent<PickupAble>();
                if (p != null)
                {
                    carrying = true;
                    p.gameObject.GetComponent<Rigidbody>().useGravity = false;
                    carriedObject = p.gameObject;                 
                    Physics.IgnoreCollision(carriedObject.transform.GetComponent<Collider>(), GetComponent<Collider>());
                    if (pGun)
                    { pGun.setCanShoot(false); }
                }
            }
        }
    }

    //if the button was pressed, drop the object
    void checkDrop()
    {
        if (Input.GetButtonUp("Interaction"))
        {
            dropObject();
        }
    }

    //reset back to not carrying an object
    public void dropObject()
    {
        carrying = false;
        if(carriedObject)
        {
            carriedObject.gameObject.GetComponent<Rigidbody>().useGravity = true;
            Physics.IgnoreCollision(carriedObject.transform.GetComponent<Collider>(), GetComponent<Collider>(), false);
            carriedObject = null;
        }      
        if (pGun)
        { pGun.setCanShoot(true); }
    }
}
