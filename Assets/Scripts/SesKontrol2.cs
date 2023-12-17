using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SesKontrol2 : MonoBehaviour
{
    public AudioClip boom;

    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void Boom()
    {
        audioSource.clip = boom; 
        audioSource.Play();
    }
}
