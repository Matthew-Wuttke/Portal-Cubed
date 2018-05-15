using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueProj : MonoBehaviour
{
    public GameObject bPortal;      //holds the inactive blue portal
    public float speed;             //speed of projectile
    public GameObject audioBox;     //gameObject to play sounds

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }
    private void OnTriggerEnter(Collider other)
    {
        //check what it collides with
        switch (other.tag)
        {
            case "PortalGun":
            case "Player":
            case "gunEnd":
                return;
            case "orangePortal":
            case "bluePortal":
                CheckPortal();
                Destroy(other.gameObject);
                Instantiate(bPortal, other.transform.position, other.transform.rotation);                
                Destroy(gameObject);
                return;
            case "PortableWall":            
                CheckPortal();
                Instantiate(bPortal, transform.position, other.transform.rotation);
                Destroy(gameObject);
                break;

            default:
                if (audioBox)
                {
                    GameObject clone = Instantiate(audioBox, transform.position, transform.rotation);
                    clone.GetComponent<AudioBox>().PlaySound(2);
                }
                Destroy(gameObject);
                break;
        }
    }
    
    //check to see if a blue portal already exists, if so destroy it
    void CheckPortal()
    {
        GameObject[] temp = GameObject.FindGameObjectsWithTag("bluePortal");
        foreach (GameObject p in temp)
        {
            Destroy(p);
        }
    }
}