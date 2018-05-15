using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioBox : MonoBehaviour
{
    public AudioClip[] audioClips = new AudioClip[1]; //Array of audioClips

    //plays a sound based on index to every audio listener
    public void PlaySound(int i)
    {
        CheckSound(i);
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = audioClips[i];
        audio.Play();            
        StartCoroutine(SoundPlay(audioClips[i].length));
      
    }

    //plays a sound based on index to at a specific location
    public void PlaySoundAtPoint(int i)
    {
        CheckSound(i);
        AudioSource.PlayClipAtPoint(audioClips[i], transform.position);
        StartCoroutine(SoundPlay(audioClips[i].length));
    }
    
    //check if a sound exists
    private void CheckSound(int i)
    {
        if (i > audioClips.Length - 1 || i < 0)
        {
            print("No Sound could be found");
            Destroy(gameObject);
        }
    }
    //Destroy Sound after the time
    IEnumerator SoundPlay(float leng) {
        yield return new WaitForSeconds(leng);
        Destroy(gameObject);
    }
}
	

