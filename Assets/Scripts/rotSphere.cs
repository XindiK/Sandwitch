﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotSphere : MonoBehaviour
{
    public float rotSpeed;
    float myTime;
    float mult;
    public GameObject Mic;
    private myMixer _myMixer;
    private float rotationPitch;

    // Start is called before the first frame update
    void Start()
    {
        Mic = GameObject.Find("Mic");
        myTime = Time.deltaTime;
        _myMixer = Mic.GetComponent<myMixer>();
    }

    // Update is called once per frame


    void Update()
    {
        //rotationPitch = GetComponent<myMixer>().rotationPitch * 10;

        rotationPitch = _myMixer.getPitchFromRotation();
        mult = _myMixer.Remap(rotationPitch, 0.75f, 1.5f, 1, 360);
        //mult = _myMixer.normRot;
        rotSpeed = mult * 2f * myTime;
        //Debug.Log("rotSpeed:" + rotSpeed);
        //Debug.Log("rp" + rotationPitch);
        transform.Rotate(new Vector3(0, rotSpeed, 0));
        
    }
}
