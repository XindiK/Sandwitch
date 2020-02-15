using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PitchSlide : MonoBehaviour
{
    AudioSource audioSource;
    public int startingPitch = 1;
    [Range(-10, 10)]
    public int pitchChange;


    private void Start()
    {
        //Fetch the AudioSource from the GameObject
        audioSource = GetComponent<AudioSource>();

        //Initialize the pitch
        audioSource.pitch = transform.position.x;
    }

    void Update()
    {
        //While the pitch is over 0, decrease it as time passes.
        if (audioSource.pitch > 0)
        {
            audioSource.pitch = startingPitch + pitchChange;
        }
    }


}
