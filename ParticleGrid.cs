using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleGrid : MonoBehaviour {

    public float gridSpeed;     //speed of grid
    public GameObject audioBox; //gameObject to play sounds
    void Update()
    {
        gameObject.GetComponent<Renderer>().material.SetTextureOffset("_MainTex", new Vector2(Time.time * gridSpeed,0));
    }
    private void OnTriggerEnter(Collider other)
    {
        //if collider is player, deactivate portals and play a fizz sound
        if (other.CompareTag("Player"))
        {

            List<GameObject> destroyPortals = new List<GameObject>();
            destroyPortals.Add(GameObject.FindGameObjectWithTag("bluePortal"));
            destroyPortals.Add(GameObject.FindGameObjectWithTag("orangePortal"));
            foreach(GameObject p in destroyPortals)
            {
                Destroy(p);
            }
            GameObject clone = Instantiate(audioBox, transform.position, transform.rotation);
            clone.GetComponent<AudioBox>().PlaySound(0);

        }
        //if collider is a companion cube, reset its position and play a fizz sound
        if (other.CompareTag("CompCube"))
        {
            PickupAble pa = other.GetComponent<PickupAble>();
            pa.Reset(); 
            GameObject clone = Instantiate(audioBox, transform.position, transform.rotation);
            clone.GetComponent<AudioBox>().PlaySound(0);
        }
    }
}
