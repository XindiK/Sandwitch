using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class myMixer : MonoBehaviour
{
    public GameObject Mic;
    public float rotationPitch;
    public float rotationRoom;
    public float rotationDecay = 1;
    public float normX;
    public float normY;
    public float normZ;
    public float mult;

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
        Mic = GameObject.Find("Mic");
        rotation = Mic.GetComponent<Transform>().rotation.eulerAngles;
        //rotation = GetComponent<Transform>().rotation.eulerAngles;
        normX = Mathf.Abs(rotation.x) % 360;
        normY = Mathf.Abs(rotation.y) % 360;
        normZ = Mathf.Abs(rotation.z) % 360;

        //float rotationX = Remap(Mathf.Abs(rotation[0]) % 360, 0, 360, 0.5f,2.0f);
        float rotationPitch = getPitchFromRotation();
        float rotPitchMult = rotationPitch * mult;
        float rotationRoom = Remap(normY, 1, 360, -10000, 0);

        Debug.Log("rotPitch: "+ rotationPitch);

        audioSource.outputAudioMixerGroup.audioMixer.SetFloat("myPitch", rotPitchMult);

        Debug.Log("mult: " + mult);

        audioSource.outputAudioMixerGroup.audioMixer.SetFloat("myRoom", rotationRoom);
        //audioSource.outputAudioMixerGroup.audioMixer.SetFloat("myDecay", rotationDecay);

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
