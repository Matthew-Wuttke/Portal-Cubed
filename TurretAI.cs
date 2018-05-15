using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretAI : MonoBehaviour {
    public GameObject audioBox;             //gameObject that plays sound

    //if the player walks into the collider, play a sound
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if (audioBox)
            {
                GetComponent<AudioSource>().Play();
            }
        }
    }
    //if the player stays in the collider, play a sound and deal damage
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!GetComponent<AudioSource>().isPlaying)
            {
                if (audioBox)
                {
                    GameObject clone = Instantiate(audioBox, transform.position, transform.rotation);
                    clone.GetComponent<AudioBox>().PlaySound(12);
                }
                Health health = other.transform.GetComponentInChildren<Health>();
                health.Damage(1);
            }           
        }
    }
    //if the player walks out of the collider, play a sound
    private void OnTriggerExit(Collider other)
    {
        {
            if (other.CompareTag("Player"))
            {
                if (audioBox)
                {
                    GameObject clone = Instantiate(audioBox, transform.position, transform.rotation);
                    clone.GetComponent<AudioBox>().PlaySound(13);
                }
            }
        }
    }
}
