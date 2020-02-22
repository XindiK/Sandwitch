using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    float rotSpeed;
    public float mult;
    // Start is called before the first frame update
    void Start()
    {

        rotSpeed = mult * 10f * Time.deltaTime;
    }

    // Update is called once per frame


    void Update()
    {
        transform.Rotate(new Vector3(0, rotSpeed, 0));
    }
}
