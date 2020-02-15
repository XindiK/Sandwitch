using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class myaudio : MonoBehaviour
{
    public Transform hi;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(hi.rotation);
    }



    //Creates a sinewave
    public float CreateSine(int timeIndex, float frequency, float sampleRate, float amplitude)
    {
        return Mathf.Sin(2 * Mathf.PI * timeIndex * frequency / sampleRate) * amplitude;
    }
}
