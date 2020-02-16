using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FMsynth : MonoBehaviour
{
    public static float audioX;
    public float micFrequency;
    
    [Range(0, 1)]
    public float amplitude1;
    [Range(0, .1f)]
    public float amplitude2;

    int timeIndex = 0;

    public void Update()
    {
        AudioSource audioSource;
        audioSource = GetComponent<AudioSource>();
        audioX = audioSource.transform.position.x;
        micFrequency = GetComponent<MicrophoneInput>().GetFundamentalFrequency();
    }

    void OnAudioFilterRead(float[] data, int channels)
    {
        
        for (int i = 0; i < data.Length; i += channels)
        {
            float fmfreq = audioX * CreateSine(timeIndex, micFrequency, 44100, amplitude2);
            data[i] = CreateSine(timeIndex, fmfreq, 44100, amplitude1);

            if (channels == 2)
                data[i + 1] = data[i];

            timeIndex++;
        }
        Debug.Log(audioX);
    }


    //Creates a sinewave
    public float CreateSine(int timeIndex, float frequency, float sampleRate, float amplitude)
    {
        return Mathf.Sin(2 * Mathf.PI * timeIndex * frequency / sampleRate) * amplitude;
    }

}
