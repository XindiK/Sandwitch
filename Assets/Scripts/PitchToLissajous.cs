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
    public float mult;

    // Start is called before the first frame update
    void Start()
    {
        mytime = Time.deltaTime;

        Mic = GameObject.Find("Mic");
        _myMixer = Mic.GetComponent<myMixer>();
    }

    // Update is called once per frame
    void Update()
    {


        rotationPitch = Round(_myMixer.getPitchFromRotation(),1); //ratio between 0.5 to 2 (granularity = 2 decimal places; round to 1 decimal)
        float RatioFromPitch = _myMixer.Remap(rotationPitch, 0.5f, 2, 0.05f, 10); //lissajous ratio

        //Lissajous formula:  particleSpeed/diskRotateSpeed = rotationPitch ratio
        particleSpeed = 100;
        diskRotateSpeed = particleSpeed * RatioFromPitch;
        Debug.Log("rotaionPitch:" + rotationPitch);
        Debug.Log("rotaionPitch:" + rotationPitch);
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
