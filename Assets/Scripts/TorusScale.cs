using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorusScale : MonoBehaviour
{
    public GameObject Torus;
    public GameObject Mic;
    public float mult;
    private myMixer _myMixer;
    private float rotationPitch;

    // Start is called before the first frame update
    void Start()
    {
        Mic = GameObject.Find("Mic");
        _myMixer = Mic.GetComponent<myMixer>();
    }

    // Update is called once per frame
    void Update()
    {
        rotationPitch = _myMixer.getPitchFromRotation();
        mult = _myMixer.Remap(rotationPitch, 0.75f, 1.5f, 0.1f, 1);
        transform.localScale = new Vector3(mult, mult, mult);
    }
}
