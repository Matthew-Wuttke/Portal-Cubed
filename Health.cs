using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    private int maxHealth = 100;        //holds player's max health
    public float currentHealth = 100;   //holds player's current health
    private float lastHit;              //time of last hit

    // Use this for initialization
    void Start()
    {
        lastHit = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        //sets visual for when damage or healing is done
        float visHealth = (maxHealth - currentHealth) / 100f;
        Color temp = transform.GetComponent<Renderer>().material.color;
        temp.a = visHealth;
        transform.GetComponent<Renderer>().material.color = temp;
        if ((transform.GetComponent<Renderer>().material.color.a < 1f) && (currentHealth < maxHealth) && (Time.time - lastHit) > 5)
        {
            Heal();
        }
    }

    public void Damage(int d)
    {
        //calculate current health
        currentHealth = currentHealth - d;
        lastHit = Time.time;
        
        //if player's health drops to 0 or less, reload scene.
        if (currentHealth <= 0)
        {
           SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
    
    //how health is restored
    public void Heal()
    {       
       currentHealth += .5f;        
    }
}
