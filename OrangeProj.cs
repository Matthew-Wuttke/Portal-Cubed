using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrangeProj : MonoBehaviour
{
    public GameObject oPortal;  //holds inactive orange portal
    public float speed;         //holds speed of projectile
    public GameObject audioBox; //gameObject to play sounds

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
                break;
            case "bluePortal":
            case "orangePortal":
                CheckPortal();
                Destroy(other.gameObject);
                Instantiate(oPortal, other.transform.position, other.transform.rotation);
                Destroy(gameObject);
                return;
            case "PortableWall":
                CheckPortal();
                Instantiate(oPortal, transform.position, other.transform.rotation);
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
    //check to see if an orange portal already exists, if so destroy it
    void CheckPortal()
    {
        GameObject[] temp = GameObject.FindGameObjectsWithTag("orangePortal");
        foreach(GameObject p in temp)
        {
            Destroy(p);           
        }
    }
}
