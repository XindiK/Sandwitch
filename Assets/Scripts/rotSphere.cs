using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotSphere : MonoBehaviour
{
    float rotSpeed;
    float myTime;
    float mult;
    public GameObject Mic;
    private myMixer _myMixer;

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

        mult = _myMixer.normRot;
        rotSpeed = mult * 2f * myTime;
        Debug.Log("rotSpeed:" + rotSpeed);
        Debug.Log("rp" + _myMixer.normRot);
        transform.Rotate(new Vector3(0, rotSpeed, 0));
        
    }
}
