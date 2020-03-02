using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class myMixer : MonoBehaviour
{
    public float rotationPitch;
    public float rotationRoom;
    public float rotationDecay = 1;
    public float normX;
    public float normY;
    public float normZ;

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
        normX = Mathf.Abs(rotation.x) % 360;
        normY = Mathf.Abs(rotation.y) % 360;
        normZ = Mathf.Abs(rotation.z) % 360;

        //float rotationX = Remap(Mathf.Abs(rotation[0]) % 360, 0, 360, 0.5f,2.0f);
        float rotationPitch = getPitchFromRotation();
        float rotationRoom = Remap(normY, 1, 360, -10000, 0);

        Debug.Log("rotationPitch: " + rotationPitch);
        //Debug.Log("rotation: " + rotation);
        //Debug.Log("rotation.x: " + rotation.x);
        //Debug.Log("abs: " + Mathf.Abs(rotation[0]));
        //Debug.Log("normX: " + normX);
        audioSource.outputAudioMixerGroup.audioMixer.SetFloat("myPitch", rotationPitch);
        audioSource.outputAudioMixerGroup.audioMixer.SetFloat("myRoom", rotationRoom);
        audioSource.outputAudioMixerGroup.audioMixer.SetFloat("myDecay", rotationDecay);

    }

    public float getPitchFromRotation()
    {
        if (normX >= 0 && normX <= 180){
            return Remap(normX, 0, 180, 1.0f, 2.0f);
        }
        else //bwtn 180 - 360
        {
            return Remap(normX, 180, 360, 0.5f, 1.0f);
        }
    }


    public float Remap(float value, float a1, float b1, float a2, float b2)
    {
        return (value - a1) / (b1 - a1) * (b2 - a2) + a2;
    }
}
