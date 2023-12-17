using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SesKontrol : MonoBehaviour
{
    public AudioClip button;
    public AudioClip fire;

    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void Button()
    {
        audioSource.clip = button; 
        audioSource.Play();
    }

    public void Fire()
    {
        audioSource.clip = fire;
        audioSource.Play();
    }

}
