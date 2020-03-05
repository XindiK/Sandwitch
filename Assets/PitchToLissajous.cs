using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PitchToLissajous : MonoBehaviour
{
    public float particleSpeed;
    public float diskRotateSpeed;
    public GameObject particleRotationObject;
    float mytime;

    public GameObject Mic;
    private myMixer _myMixer;
    float rotationPitch;

    // Start is called before the first frame update
    void Start()
    {
        mytime = Time.deltaTime;

        Mic = GameObject.Find("Mic");
        _myMixer = Mic.GetComponent<myMixer>();
        rotationPitch = _myMixer.getPitchFromRotation(); //ratio between 0.5 to 2 (granularity = 2 decimal places)
        float RatioFromPitch = rotationPitch * 10;//lissajous ratio

        //Lissajous formula:  particleSpeed/diskRotateSpeed = rotationPitch ratio
        particleSpeed = 100;
        diskRotateSpeed = particleSpeed * RatioFromPitch;

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(diskRotateSpeed * mytime, 0, 0));
        particleRotationObject.transform.Rotate(new Vector3(0, particleSpeed * mytime, 0));

    }

    //round rotationPitch ratio to 1 decimal place to minimize 'jitter'
    private static float Round(float value, int digits)
    {
        float mult = Mathf.Pow(10.0f, (float)digits);
        return Mathf.Round(value * mult) / mult;
    }

}
