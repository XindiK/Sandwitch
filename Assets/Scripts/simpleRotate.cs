using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class simpleRotate : MonoBehaviour
{
    float mytime;
    public float speed1;
    // Start is called before the first frame update
    void Start()
    {
        mytime = Time.deltaTime;
        speed1 = 600f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, speed1 * mytime, 0));
    }
}
