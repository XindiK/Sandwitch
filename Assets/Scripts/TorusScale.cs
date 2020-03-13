using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorusScale : MonoBehaviour
{
    public GameObject mixerObject;
    public float mult;
    private myMixer _myMixer;
    private float diskX;
    private float diskY;
    private float diskZ;

    // Start is called before the first frame update
    void Start()
    {
        mixerObject = GameObject.Find("LissajousDisk");
        _myMixer = mixerObject.GetComponent<myMixer>();
        diskX = transform.localScale.x;
        diskY = transform.localScale.y;
        diskZ = transform.localScale.z;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("room from rot " + _myMixer.getRotationRoomForVisual());
        mult = _myMixer.getRotationRoomForVisual();
        transform.localScale = new Vector3(diskX*mult, diskY * mult, diskZ * mult);
    }
}
