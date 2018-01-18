using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrumTrigger : MonoBehaviour
{

    public AudioClip drumSound;
    AudioSource audioSource;

    private float fxTiimer;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (fxTiimer < 0)
        {
            audioSource.PlayOneShot(drumSound, 0.7F);
            fxTiimer = 0.1f;
        }
    }

    private void Update()
    {
        fxTiimer -= Time.deltaTime;
    }
}


