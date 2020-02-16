using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class myMixer : MonoBehaviour
{
    private AudioMixer audioMixer;
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        audioSource.outputAudioMixerGroup.audioMixer.SetFloat("myPitch", 0.5f);
    }
}
