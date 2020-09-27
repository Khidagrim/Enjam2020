using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeopleVoiceHandler : Singleton<PeopleVoiceHandler>
{
    public AudioClip[] bouh;
    public AudioClip[] yeah;

    public AudioSource outputSound;

    void Start()
    {
        GetComponent<AudioSource>();
    }

    public void PlayBouh()
    {
        outputSound.clip = bouh[Random.Range(0,bouh.Length - 1)];
        outputSound.Play();
    }

    public void PlayYeah()
    {
        outputSound.clip = bouh[Random.Range(0,yeah.Length - 1)];
        outputSound.Play();
    }
}
