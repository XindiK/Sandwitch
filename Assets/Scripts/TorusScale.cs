using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorusScale : MonoBehaviour
{
    public GameObject Prefab;
    public GameObject Mic;
    public float mult;
    private myMixer _myMixer;
    private float rotationPitch;
    private float diskX;
    private float diskY;
    private float diskZ;
    private float rotationRoom;

    // Start is called before the first frame update
    void Start()
    {
        Mic = GameObject.Find("Mic");
        _myMixer = Mic.GetComponent<myMixer>();
        diskX = Prefab.transform.localScale.x;
        diskY = Prefab.transform.localScale.y;
        diskZ = Prefab.transform.localScale.z;

    }

    // Update is called once per frame
    void Update()
    {
        //doesn't work :(
        rotationRoom = _myMixer.rotationRoom;
        mult = _myMixer.Remap(rotationRoom, -10000, 0, 0.5f, 20);
        transform.localScale = new Vector3(diskX*mult, diskY * mult, diskZ * mult);
    }
}
