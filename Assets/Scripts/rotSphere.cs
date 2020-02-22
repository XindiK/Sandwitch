using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotSphere : MonoBehaviour
{
    float rotSpeed;
    float myTime;
    //float rotationPitch;
    public float mult;

    // Start is called before the first frame update
    void Start()
    {
        myTime = Time.deltaTime;
    }

    // Update is called once per frame


    void Update()
    {
        //rotationPitch = GetComponent<myMixer>().rotationPitch * 10;


        rotSpeed = mult * 10f * myTime;
        Debug.Log("rotSpeed:" + rotSpeed);
        Debug.Log("rp1" + myMixer.rotationPitch);
        //Debug.Log("rp2" + myMixer.getPitchFromRotation());
        transform.Rotate(new Vector3(0, rotSpeed, 0));
        
    }
}
