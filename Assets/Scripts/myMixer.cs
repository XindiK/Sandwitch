using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class myMixer : MonoBehaviour
{
    public float rotationPitch;
    public float normRot;

    private Vector3 rotation;
    private AudioMixer audioMixer;
    private AudioSource audioSource;

    public Transform prefab;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        rotation = GetComponent<Transform>().rotation.eulerAngles;
        normRot = Mathf.Abs(rotation.x) % 360;
        //float rotationX = Remap(Mathf.Abs(rotation[0]) % 360, 0, 360, 0.5f,2.0f);
        float rotationPitch = getPitchFromRotation();

        Debug.Log("rotationPitch: " + rotationPitch);
        //Debug.Log("rotation: " + rotation);
        //Debug.Log("rotation.x: " + rotation.x);
        //Debug.Log("abs: " + Mathf.Abs(rotation[0]));
        //Debug.Log("normRot: " + normRot);
        audioSource.outputAudioMixerGroup.audioMixer.SetFloat("myPitch", rotationPitch);

    }

    public float getPitchFromRotation()
    {
        if (normRot >= 0 && normRot <= 180){
            return Remap(normRot, 0, 180, 1.0f, 2.0f);
        }
        else //bwtn 180 - 360
        {
            return Remap(normRot, 180, 360, 0.5f, 1.0f);
        }
    }

    public float Remap(float value, float a1, float b1, float a2, float b2)
    {
        return (value - a1) / (b1 - a1) * (b2 - a2) + a2;
    }
}
