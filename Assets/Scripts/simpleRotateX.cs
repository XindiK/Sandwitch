using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class simpleRotateX : MonoBehaviour
{
    float mytime;
    public float speed2;
    // Start is called before the first frame update
    void Start()
    {
        mytime = Time.deltaTime;
        speed2 = 600f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(speed2 * mytime, 0, 0));
    }
}
