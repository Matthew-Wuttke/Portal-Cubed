using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalGun : MonoBehaviour {
    public GameObject orangeProjectile;     //holds orange projectile
    public GameObject blueProjectile;       //holds blue projectile
    public Transform gunEnd;                //holds end of gun
    private bool canShoot = true;           //can the player shoot
    GameObject mainCamera;                  //hold a camera
    public GameObject audioBox;             //gameObject to play sound
  
	// Update is called once per frame
	void Update () {
        //set main camer if null
        if (mainCamera == null)
        {
            mainCamera = GameObject.FindWithTag("MainCamera");
        }
        //if player can shoot check for button pressed and instantiate the projectile
        if (canShoot)
        {
            if (Input.GetButtonDown("FireOrange"))
            {
                GameObject proj;
                proj = GameObject.FindGameObjectWithTag("orangeProj");
                if (proj == null)
                {
                    Instantiate(orangeProjectile, gunEnd.position, mainCamera.transform.rotation);
                    GameObject clone = Instantiate(audioBox, transform.position, transform.rotation);
                    clone.GetComponent<AudioBox>().PlaySound(3);
                }

            }
            if (Input.GetButtonDown("FireBlue"))
            {
                GameObject proj;
                proj = GameObject.FindGameObjectWithTag("blueProj");
                if (proj == null)
                {
                    if (blueProjectile)
                    {
                        Instantiate(blueProjectile, gunEnd.position, mainCamera.transform.rotation);
                        GameObject clone = Instantiate(audioBox, transform.position, transform.rotation);
                        clone.GetComponent<AudioBox>().PlaySound(3);
                    }

                }
            }
        }
    }
    //allows others access to change canShoot
    public void setCanShoot(bool able)
    {
        canShoot = able;
    }
}
